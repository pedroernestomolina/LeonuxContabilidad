using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormContable.PlanCta
{

    public partial class Lista : Form
    {

        public event EventHandler<OOB.Contable.PlanCta.Ficha> ItemSeleccionadoOk;
        BindingSource bs;
        BindingList<OOB.Contable.PlanCta.Ficha> Ctas;

        public Lista()
        {
            InitializeComponent();
            bs = new BindingSource();
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            var data = TB_BUSCAR.Text.Trim();
            Buscar(data);
        }

       async public void Buscar(string data)
        {
            var r01 = await Cargar(data);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var l = r01.Lista.OrderBy(d => d.Codigo).ToList();
            Ctas.Clear();
            foreach (var it in l)
            {
                Ctas.Add(it);
            }

            TB_BUSCAR.Text = "";
            DGV.Select();
        }

       async private Task<OOB.Resultado.ResultadoLista<OOB.Contable.PlanCta.Ficha>> Cargar(string cadena)
       {
           var filt = new OOB.Contable.PlanCta.Filtro() { Cadena = cadena };
           return await Globals.MyData.PlanCta_Lista(filt);
       }

       private void Lista_Load(object sender, EventArgs e)
       {
           TB_BUSCAR.Select();

           DGV.AllowUserToAddRows = false;
           DGV.AutoGenerateColumns = false;
           DGV.AllowUserToResizeRows = false;
           DGV.AllowUserToResizeColumns = false;
           DGV.AllowUserToOrderColumns = false;
           DGV.ReadOnly = true;
           DGV.CellDoubleClick +=DGV_CellDoubleClick;

           var f = new Font("Serif", 8, FontStyle.Bold);
           var f1 = new Font("Serif", 10, FontStyle.Regular);
           var c1 = new DataGridViewTextBoxColumn();
           c1.DataPropertyName = "Codigo";
           c1.HeaderText = "Código";
           c1.Visible = true;
           c1.Width = 120;
           c1.HeaderCell.Style.Font = f;
           c1.DefaultCellStyle.Font = f1;

           var c2 = new DataGridViewTextBoxColumn();
           c2.DataPropertyName = "Nombre";
           c2.HeaderText = "Descripción";
           c2.Visible = true;
           c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           c2.HeaderCell.Style.Font = f;
           c2.DefaultCellStyle.Font = f1;

           DGV.Columns.Add(c1);
           DGV.Columns.Add(c2);

           Ctas = new BindingList<OOB.Contable.PlanCta.Ficha>();
           bs.DataSource = Ctas;
           DGV.DataSource = bs;
       }

       private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
       {
           if (e.RowIndex != -1)
           {
               var ficha =(OOB.Contable.PlanCta.Ficha) bs.Current;
               EventHandler<OOB.Contable.PlanCta.Ficha> handler = ItemSeleccionadoOk;
               if (handler != null) 
               {
                   Visible = false;
                   handler(this, ficha);
               }
           }
       }

       private void MenuSalir_Click(object sender, EventArgs e)
       {
           Salir();
       }

       private void BT_SALIR_Click(object sender, EventArgs e)
       {
           Salir();
       }

       private void Salir()
       {
           Close(); 
       }

       private void MenuAgregarCuenta_Click(object sender, EventArgs e)
       {
           AgregarCuenta();
       }

       Agregar fagregar = null;
       private void AgregarCuenta()
       {
           fagregar = new PlanCta.Agregar();
           fagregar.SetReusarPlantilla=false;
           fagregar.AgregarOK += fagregar_AgregarOK;
           fagregar.CerrarOk += fagregar_CerrarOk;
           fagregar.ShowDialog();
       }

       private void fagregar_CerrarOk(object sender, EventArgs e)
       {
           fagregar.Close();
       }

       private void fagregar_AgregarOK(object sender, int e)
       {
           var result_01 = Globals.MyData.PlanCta_GetById(e);
           if (result_01.Result == OOB.Resultado.EnumResult.isError)
           {
               Helpers.Msg.Error(result_01.Mensaje);
               return;
           }

           Ctas.Add(result_01.Entidad);
           var list = Ctas.OrderBy(d => d.Codigo).ToList();

           Ctas.Clear();
           foreach (var it in list)
           {
               Ctas.Add(it);
           }
       }

       private void Lista_KeyDown(object sender, KeyEventArgs e)
       {
           Control nextControl;
           //Checks if the Enter Key was Pressed
           if (e.KeyCode == Keys.Enter)
           {
               //If so, it gets the next control and applies the focus to it
               nextControl = GetNextControl(ActiveControl, !e.Shift);
               if (nextControl == null)
               {
                   nextControl = GetNextControl(null, true);
               }
               nextControl.Focus();
               //Finally - it suppresses the Enter Key
               e.SuppressKeyPress = true;
           }

           if (e.KeyCode == Keys.Escape)
           {
               Salir();
           }
       }
     

    }
}