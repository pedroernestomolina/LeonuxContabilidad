using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormContable.Integraciones
{

    public partial class Manager : Form
    {

        BindingSource bs;
        BindingList<OOB.Contable.Integracion.Ficha> ListIntegr;

        public Manager()
        {
            InitializeComponent();
            bs = new BindingSource();
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            DGV.AllowUserToAddRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.ReadOnly = true;
            DGV.CellFormatting += DGV_CellFormatting;

            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Fecha";
            c1.HeaderText = "Fecha";
            c1.Visible = true;
            c1.Width = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "ModuloAfecta";
            c2.HeaderText = "Módulo";
            c2.Visible = true;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new  DataGridViewTextBoxColumn();
            c3.DataPropertyName = "EstaAnulado";
            c3.Visible = false;
            c3.Width = 0;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            CargarData();
        }

        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                row.DefaultCellStyle.ForeColor = (bool)row.Cells[2].Value ? Color.Red : Color.Black;
            }
        }

        private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.ColumnIndex == 2)
            //{
            //    if ((bool)e.Value == true)
            //    {
            //        DGV.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            //    }
            //}
        }

        private void CargarData()
        {
            var filt = new OOB.Contable.Integracion.Filtro();
            var r01 = Globals.MyData.Integracion_Lista(filt);
            if (r01.Result == OOB.Resultado.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            ListIntegr = new BindingList<OOB.Contable.Integracion.Ficha>(r01.Lista.OrderByDescending(d=>d.Id).ToList());
            bs.DataSource = ListIntegr;
            DGV.DataSource = bs;

            TB_DESDE.DataBindings.Add("Text", bs, "Desde");
            TB_HASTA.DataBindings.Add("Text", bs, "Hasta");
            TB_MODULO.DataBindings.Add("Text", bs, "Descripcion");
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            Close();
        }

        private void BT_ELIMINAR_Click(object sender, EventArgs e)
        {
            EliminarFicha();
        }

        private void EliminarFicha()
        {
            if (bs.Current == null) 
            {
                return;
            }

            var ficha = (OOB.Contable.Integracion.Ficha)bs.Current;
            if (ficha.EstaAnulado)
            {
                Helpers.Msg.Error("FICHA YA ANULADA !!!");
                return;
            }

            var msg = MessageBox.Show("Anular Integración ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                var r01 = Globals.MyData.Integracion_Anular(ficha);
                if (r01.Result == OOB.Resultado.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                ficha.EstaAnulado = true;
                Helpers.Msg.EliminarOk();
                bs.CurrencyManager.Refresh();
            }
        }

        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            EliminarFicha();
        }

        private void BT_VISUALIZAR_Click(object sender, EventArgs e)
        {
            VisualizarFicha();
        }

        private void VisualizarFicha()
        {
            if (bs.Current == null)
            {
                return;
            }

            var ficha = (OOB.Contable.Integracion.Ficha) bs.Current;
            var r01 = Globals.MyData.Integracion_GetBy(ficha,null);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var fVisualizar = new Visualizar();
            fVisualizar.Cargar(r01.Entidad);
        }
    
    }

}