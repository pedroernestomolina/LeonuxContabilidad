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

    public partial class Visualizar : Form
    {

        private BindingSource bs;
        private BindingSource bsDet;
        private BindingList<Documento> Documentos;
        private BindingList<Detalle> Detalles;
        private List<Resumen> Resumen;
        private int IdAsiento;


        public Visualizar()
        {
            InitializeComponent();
            Inicializa();

            bs = new BindingSource();
            bsDet = new BindingSource();
            bs.CurrentChanged += bs_CurrentChanged;
        }

        private void Visualizar_Load(object sender, EventArgs e)
        {
        }

        public void Cargar(OOB.Contable.Integracion.Ficha ficha)
        {
            IdAsiento = ficha.IdAsiento;
            var r01 = Globals.MyData.Asiento_GetById(ficha.IdAsiento);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var listDocumentos = r01.Entidad.Documentos.Select(d =>
            {
                return new Documento()
                {
                    DescripcionDoc = d.Descripcion,
                    DocumentoRef = d.Documento,
                    FechaDoc = d.Fecha,
                    Detalles = d.Cuentas.Select(dt =>
                    {
                        return new Detalle()
                        {
                            CodigoCta = dt.Cuenta.CodigoCta,
                            DescripcionCta = dt.Cuenta.DescripcionCta,
                            MontoDebe = dt.MontoDebe,
                            MontoHaber = dt.MontoHaber
                        };
                    }
                    ).ToList()
                };
            }
            ).ToList();

            Resumen = r01.Entidad.Resumen.Select(r =>
            {
                return new Resumen()
                {
                    CodigoCta = r.Cuenta.CodigoCta,
                    DescripcionCta = r.Cuenta.DescripcionCta,
                    MontoDebe = r.MontoDebe,
                    MontoHaber = r.MontoHaber
                };
            }
            ).ToList();

            //
            L_ASIENTO.Text = "Asiento #"+ Environment.NewLine+ r01.Entidad.Comprobante;
            L_DESDE.Text = ficha.Desde;
            L_HASTA.Text = ficha.Hasta;
            L_MODULO.Text = ficha.ModuloAfecta;
            L_TDOC.Text = listDocumentos.Count().ToString().Trim();
            L_NOTAS.Text = ficha.Descripcion;

            //DOCUMENTOS
            Documentos = new BindingList<Documento>(listDocumentos);
            bs.DataSource = Documentos;
            DGV.DataSource = bs;

            //DETALLES
            this.Detalles = new BindingList<Detalle>();  
            bsDet.DataSource = this.Detalles;
            DGV_DETALLE.DataSource = bsDet;

            //RESUMEN
            var mdebe = Resumen.Sum(d => d.MontoDebe);
            var mhaber = Resumen.Sum(d => d.MontoHaber);
            var difer = mdebe - mhaber;
            L_R_DEBE.Text = mdebe.ToString("n2");
            L_R_HABER.Text = mhaber.ToString("n2");
            DGV_RESUMEN.DataSource = Resumen;

            tabControl1.SelectedIndex = 1;
            ShowDialog();
        }

        private void bs_CurrentChanged(object sender, EventArgs e)
        {
            if (Detalles != null)
            {
                Limpiar_AsientoDetalles();
            }
        }

        private void Inicializa()
        {

            //DOCUMENTOS
            DGV.AllowUserToAddRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.ReadOnly = true;
            DGV.CellClick += DGV_CellClick;

            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 9, FontStyle.Regular);
            var c0 = new DataGridViewTextBoxColumn();
            c0.DataPropertyName = "DocumentoRef";
            c0.HeaderText = "Documento";
            c0.Visible = true;
            c0.Width = 100;
            c0.HeaderCell.Style.Font = f;
            c0.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "FechaDoc";
            c2.HeaderText = "Fecha";
            c2.Visible = true;
            c2.Width = 90;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "DescripcionDoc";
            c3.HeaderText = "Descripción";
            c3.Visible = true;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c5 = new DataGridViewImageColumn();
            c5.Width = 30;
            c5.Visible = true;
            c5.Image = Properties.Resources.ver;

            DGV.Columns.Add(c0);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c5);


            //DETALLES
            DGV_DETALLE.AllowUserToAddRows = false;
            DGV_DETALLE.AutoGenerateColumns = false;
            DGV_DETALLE.AllowUserToResizeRows = false;
            DGV_DETALLE.AllowUserToResizeColumns = false;
            DGV_DETALLE.AllowUserToOrderColumns = false;
            DGV_DETALLE.ReadOnly = true;

            var c1d = new DataGridViewTextBoxColumn();
            c1d.DataPropertyName = "CodigoCta";
            c1d.HeaderText = "Código";
            c1d.Visible = true;
            c1d.Width = 100;

            var c2d = new DataGridViewTextBoxColumn();
            c2d.DataPropertyName = "DescripcionCta";
            c2d.HeaderText = "Descripción";
            c2d.Visible = true;
            c2d.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var fd = new Font("Serif", 10, FontStyle.Bold);
            var c3d = new DataGridViewTextBoxColumn();
            c3d.DefaultCellStyle.BackColor = Color.Blue;
            c3d.DataPropertyName = "MontoDebe";
            c3d.HeaderText = "Debe";
            c3d.Visible = true;
            c3d.Width = 120;
            c3d.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3d.DefaultCellStyle.ForeColor = Color.White;
            c3d.DefaultCellStyle.Font = fd;
            c3d.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3d.DefaultCellStyle.Format = "n2";

            var c4d = new DataGridViewTextBoxColumn();
            c4d.DefaultCellStyle.BackColor = Color.Red;
            c4d.DataPropertyName = "MontoHaber";
            c4d.HeaderText = "Haber";
            c4d.Visible = true;
            c4d.Width = 120;
            c4d.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4d.DefaultCellStyle.ForeColor = Color.White;
            c4d.DefaultCellStyle.Font = fd;
            c4d.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4d.DefaultCellStyle.Format = "n2";

            DGV_DETALLE.Columns.Add(c1d);
            DGV_DETALLE.Columns.Add(c2d);
            DGV_DETALLE.Columns.Add(c3d);
            DGV_DETALLE.Columns.Add(c4d);


            //RESUMEN
            DGV_RESUMEN.AllowUserToAddRows = false;
            DGV_RESUMEN.AutoGenerateColumns = false;
            DGV_RESUMEN.AllowUserToResizeRows = false;
            DGV_RESUMEN.AllowUserToResizeColumns = false;
            DGV_RESUMEN.AllowUserToOrderColumns = false;
            DGV_RESUMEN.ReadOnly = true;

            var c1r = new DataGridViewTextBoxColumn();
            c1r.DataPropertyName = "CodigoCta";
            c1r.HeaderText = "Código";
            c1r.Visible = true;
            c1r.Width = 100;

            var c2r = new DataGridViewTextBoxColumn();
            c2r.DataPropertyName = "DescripcionCta";
            c2r.HeaderText = "Descripción";
            c2r.Visible = true;
            c2r.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var fr = new Font("Serif", 10, FontStyle.Bold);
            var c3r = new DataGridViewTextBoxColumn();
            c3r.DefaultCellStyle.BackColor = Color.Blue;
            c3r.DataPropertyName = "MontoDebe";
            c3r.HeaderText = "Debe";
            c3r.Visible = true;
            c3r.Width = 150;
            c3r.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3r.DefaultCellStyle.ForeColor = Color.White;
            c3r.DefaultCellStyle.Font = fr;
            c3r.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3r.DefaultCellStyle.Format = "n2";

            var c4r = new DataGridViewTextBoxColumn();
            c4r.DefaultCellStyle.BackColor = Color.Red;
            c4r.DataPropertyName = "MontoHaber";
            c4r.HeaderText = "Haber";
            c4r.Visible = true;
            c4r.Width = 150;
            c4r.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4r.DefaultCellStyle.ForeColor = Color.White;
            c4r.DefaultCellStyle.Font = fr;
            c4r.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4r.DefaultCellStyle.Format = "n2";

            DGV_RESUMEN.Columns.Add(c1r);
            DGV_RESUMEN.Columns.Add(c2r);
            DGV_RESUMEN.Columns.Add(c3r);
            DGV_RESUMEN.Columns.Add(c4r);
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (bs != null && bs.Current != null)
                {
                    Limpiar_AsientoDetalles();

                    var doc = (Documento)bs.Current;
                    foreach (var dt in doc.Detalles) 
                    {
                        Detalles.Add(dt);
                    }

                    L_DEBE.Text = Detalles.Sum(d => d.MontoDebe).ToString("n2");
                    L_HABER.Text = Detalles.Sum(d => d.MontoHaber).ToString("n2");
                }
            }
        }

        private void Limpiar_AsientoDetalles()
        {
            Detalles.Clear();
            L_DEBE.Text = "0.0";
            L_HABER.Text = "0.0";
        }

        private void MenuCalculadora_Click(object sender, EventArgs e)
        {
            Helpers.Utilitis.Calculadora();
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            Close();
        }

        private void Menu_Reporte_ImprimirComprobante_Click(object sender, EventArgs e)
        {
            Helpers.Utilitis.ImprimirComprobante(IdAsiento);
        }

    }

}