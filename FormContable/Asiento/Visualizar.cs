using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormContable.Asiento
{

    public partial class Visualizar : Form
    {

        //
        private BindingSource bs;
        private BindingList<Detalle> items;
        private OOB.Contable.Asiento.Ficha Asiento;
        private int IdAsientoEditarExportar;
        //


        public Visualizar()
        {
            InitializeComponent();
            bs = new BindingSource();
            items = new BindingList<Detalle>();
        }

        private void Visualizar_Load_1(object sender, EventArgs e)
        {
            L_NUMERO.Text = "";
            L_DIF_DEBE.Text = "0.0";
            L_DIF_HABER.Text = "0.0";
            TB_TIPO_ASIENTO.Text = "";
            TB_TIPO_DOCUMENTO.Text = "";
            TB_DE_FECHA.Text = "";

            //

            DGV.KeyDown += DGV_KeyDown;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.ReadOnly = false;

            var f2 = new Font("Serif", 10, FontStyle.Bold);
            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Codigo";
            c1.HeaderText = "Código";
            c1.Name = "codigo";
            c1.Visible = true;
            c1.ReadOnly = true;
            c1.Width = 140;
            c1.DefaultCellStyle.Font = f2;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Descripcion";
            c2.HeaderText = "Descripción";
            c2.Name = "descripcion";
            c2.Visible = true;
            c2.ReadOnly = true;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DefaultCellStyle.BackColor = Color.Blue;
            c3.DataPropertyName = "Debe";
            c3.HeaderText = "Debe";
            c3.Name = "debe";
            c3.Visible = true;
            c3.Width = 150;
            c3.ReadOnly = true;
            c3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.ForeColor = Color.White;
            c3.DefaultCellStyle.Font = f2;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format = "n2";

            var c4 = new DataGridViewTextBoxColumn();
            c4.DefaultCellStyle.BackColor = Color.Red;
            c4.DataPropertyName = "Haber";
            c4.HeaderText = "Haber";
            c4.Name = "haber";
            c4.Visible = true;
            c4.Width = 150;
            c4.ReadOnly = true;
            c4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.ForeColor = Color.White;
            c4.DefaultCellStyle.Font = f2;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format = "n2";

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);

            bs = new BindingSource();
            items = new BindingList<Detalle>();
            bs.DataSource = items;
            DGV.DataSource = bs;

            //

            bs.DataSource = items;
            DGV.DataSource = bs;
            CargarDataAsiento(IdAsientoEditarExportar);
        }

        public void Cargar(int idAsiento)
        {
            this.IdAsientoEditarExportar = idAsiento;
        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Home)
            {
                if (bs.Count > 0)
                {
                    bs.CurrencyManager.Position = 0;
                }
            }

            if (e.KeyData == Keys.End)
            {
                if (bs.Count > 0)
                {
                    bs.CurrencyManager.Position = bs.Count - 1;
                }
            }
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            Close();
        }

        private void CargarDataAsiento(int idAsiento)
        {
            var r01 = Globals.MyData.Asiento_GetById(idAsiento);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
           
            Asiento = r01.Entidad;
            var Documento = Asiento.Documentos.FirstOrDefault();
            L_NUMERO.Text = Asiento.Comprobante;
            TB_DOCUMENTO.Text = Documento.Documento;
            TB_DESCRIPCION.Text = Documento.Descripcion;

            foreach (var cta in Documento.Cuentas.OrderBy(d=>d.Cuenta.CodigoCta).ToList())
            {
                var rt = Globals.MyData.PlanCta_GetById(cta.Cuenta.IdPlanCta);
                if (rt.Result == OOB.Resultado.EnumResult.isError)
                {
                    Helpers.Msg.Error(rt.Mensaje);
                    return;
                }

                var dt = new Detalle();
                dt.Cta = rt.Entidad;
                dt.Codigo = rt.Entidad.Codigo;
                dt.Descripcion = rt.Entidad.Nombre;
                dt.Debe = cta.MontoDebe;
                dt.Haber = cta.MontoHaber;
                items.Add(dt);
            }

            var debe=items.Sum(d=>d.Debe);
            var haber=items.Sum(d=>d.Haber);
            L_DIF_DEBE.Text= debe.ToString("n2");
            L_DIF_HABER.Text = haber.ToString("n2");
            TB_TIPO_ASIENTO.Text = Asiento.TipoAsientoDesc ;
            TB_TIPO_DOCUMENTO.Text = Asiento.TipoDocumentoDescripcion ;
            TB_DE_FECHA.Text = Asiento.FechaEmision.ToShortDateString() ;
        }

    }
}