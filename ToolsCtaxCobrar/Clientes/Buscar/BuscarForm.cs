using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ToolsCtaxCobrar.Clientes.Buscar
{

    public partial class BuscarForm : Form
    {

        public event EventHandler<OOB.Clientes.Cliente.Ficha> ItemSeleccionadoOk;
        private BindingSource bs;
        private BindingList<OOB.Clientes.Cliente.Ficha> Clientes;


        public BuscarForm()
        {
            InitializeComponent();
            bs = new BindingSource();
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void BuscarCliente()
        {
            var filtro = new OOB.Clientes.Cliente.Filtro();
            if (!string.IsNullOrEmpty(TB_BUSCAR.Text.Trim()))
            {
                filtro.Cadena = TB_BUSCAR.Text.Trim();
            }
            var r01 = Globals.MyData.Cliente_Lista(filtro);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Clientes = new BindingList<OOB.Clientes.Cliente.Ficha>(r01.Lista.OrderBy(c => c.RazonSocial).ToList());
            bs.DataSource = Clientes;
            DGV.DataSource = bs;
            L_ITEMS.Text = Clientes.Count().ToString();
        }

        private void BuscarForm_Load(object sender, EventArgs e)
        {
            L_ITEMS.Text = "0";

            DGV.AllowUserToAddRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.ReadOnly = true;

            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 9, FontStyle.Regular);
            var f2 = new Font("Serif", 8, FontStyle.Bold);

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Codigo";
            c1.HeaderText = "Codigo";
            c1.Visible = true;
            c1.Width = 80;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "RazonSocial";
            c2.HeaderText = "Nombre /Razon Social";
            c2.Visible = true;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f2;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "CiRif";
            c3.HeaderText = "Rif/CI";
            c3.Visible = true;
            c3.Width = 120;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           if (e.RowIndex != -1)
           {
               var ficha =(OOB.Clientes.Cliente.Ficha) bs.Current;
               EventHandler<OOB.Clientes.Cliente.Ficha> handler = ItemSeleccionadoOk;
               if (handler != null) 
               {
                   Visible = false;
                   handler(this, ficha);
               }
           }
        }

    }

}