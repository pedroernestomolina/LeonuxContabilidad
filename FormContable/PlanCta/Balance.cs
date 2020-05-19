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

    public partial class Balance : Form
    {

        private OOB.Empresa.DatosNegocio.Ficha DatosNegocio;
        private OOB.Contable.Cuenta.Filtro filtro;
        private OOB.Contable.PlanCta.Ficha Cta;
        private BindingSource bs;
        private decimal Saldo;


        public Balance(OOB.Contable.Cuenta.Filtro filt)
        {
            InitializeComponent();
            filtro = filt;
            Cta = filt.Cta;
            L_DESDE.Text = filt.Desde.ToShortDateString();
            L_HASTA.Text = filt.Hasta.ToShortDateString();
        }

        private void Balance_Load(object sender, EventArgs e)
        {
            L_DEBE.Text = "0.0";
            L_HABER.Text = "0.0";
            L_CTA_DESCRIPCION.Text = Cta.Cuenta;

            DGV.AllowUserToAddRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.ReadOnly = true;

            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            var c0 = new DataGridViewTextBoxColumn();
            c0.DataPropertyName = "Comprobante";
            c0.HeaderText = "Asiento Nro";
            c0.Visible = true;
            c0.Width = 120;
            c0.HeaderCell.Style.Font = f;
            c0.DefaultCellStyle.Font = f1;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Fecha";
            c1.HeaderText = "Fecha";
            c1.Visible = true;
            c1.Width = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "TipoAsiento";
            c2.HeaderText = "Tipo";
            c2.Visible = true;
            c2.Width = 120;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "TipoDocumento";
            c3.HeaderText = "Descripción";
            c3.Visible = true;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "MontoDebe";
            c4.HeaderText = "Debe";
            c4.Visible = true;
            c4.Width = 120;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format = "n2";

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "MontoHaber";
            c5.HeaderText = "Haber";
            c5.Visible = true;
            c5.Width = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            DGV.Columns.Add(c0);
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);

            CargarData();
        }

        private void CargarData()
        {
            var r01 = Globals.MyData.Cuenta_GetBalance(filtro);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var r02 = Globals.MyData.Empresa_DatosNegocio();
            if (r02.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }

            var r03 = Globals.MyData.Cuenta_GetSaldoAl(filtro.Cta, filtro.Desde.AddDays(-1));
            if (r03.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }

            DatosNegocio = r02.Entidad;
            Saldo = r03.Entidad;
            var debe = r01.Lista.Sum(d => d.MontoDebe);
            var haber = r01.Lista.Sum(d => d.MontoHaber);
            L_DEBE.Text = debe.ToString("n2");
            L_HABER.Text = haber.ToString("n2");

            bs = new BindingSource();
            bs.DataSource = r01.Lista.OrderBy(o=>o.Comprobante).ToList();
            DGV.DataSource = bs;
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

        private void BT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            if (bs != null)
            {
                if (bs.List != null)
                {
                    var ficha = new OOB.Reportes.Libro.Mayor.Ficha();
                    var ls = (List<OOB.Contable.Cuenta.Balance>)bs.List;
                    var data = ls.Select(m =>
                    {
                        return new OOB.Reportes.Libro.Mayor.Item()
                        {
                            Comprobante= m.Comprobante,
                            Fecha=m.Fecha,
                            TipoAsiento=m.TipoAsiento ,
                            MontoDebe = m.MontoDebe,
                            MontoHaber = m.MontoHaber,
                            TipoDocumento = m.TipoDocumento,
                        };
                    }
                    ).ToList();
                    ficha.Cuenta = filtro.Cta;
                    ficha.Data = data;
                    ficha.Desde = filtro.Desde;
                    ficha.Hasta = filtro.Hasta;
                    ficha.Saldo = Saldo;

                    Globals.MyReports.Libro_Mayor(ficha, DatosNegocio);
                }
            }
        }

    }

}