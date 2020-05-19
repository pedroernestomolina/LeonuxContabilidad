using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormContable.Operaciones
{

    public partial class EditarAsiento : Form
    {

        public event EventHandler<List<Detalle>> AsientoDetalleOk;
        private BindingSource bs;
        private BindingList<Detalle> items;
        private decimal MDebe;
        private decimal MHaber;
        private decimal Diferencia;
        private OOB.Contable.PlanCta.Enumerados.Naturaleza DiferenciaModo;
        private OOB.Contable.Asiento.Generar.Ficha Asiento;
        private bool SalirOk;


        public EditarAsiento(OOB.Contable.Asiento.Generar.Ficha asiento)
        {
            InitializeComponent();

            this.Asiento = asiento;
            MDebe = 0.0m;
            MHaber = 0.0m;
            Diferencia = 0.0m;
            bs = new BindingSource();
            items = new BindingList<Detalle>();
            items.ListChanged += items_ListChanged;
        }

        private void CargarData(List<OOB.Contable.Asiento.Generar.FichaDetalle> list)
        {
            foreach (var it in list) 
            {
                var itm = new Detalle() 
                {
                     Cta= new OOB.Contable.PlanCta.Ficha()
                     {
                         Id=it.IdCta,
                         Codigo=it.CodigoCta,
                         Nombre=it.DescripcionCta,
                         Naturaleza=it.Naturaleza,
                     },
                     Codigo=it.CodigoCta,
                     Descripcion=it.DescripcionCta,
                     Debe=it.MontoDebe,
                     Haber=it.MontoHaber
                };
                items.Add(itm);
            }
        }

        private void items_ListChanged(object sender, ListChangedEventArgs e)
        {
            ActualizarSaldos();
        }

        private void Agregar_Load(object sender, EventArgs e)
        {

            TB_DOCUMENTO.Text=Asiento.DocumentoRef;
            TB_DESCRIPCION.Text=Asiento.DescripcionDoc;
            TB_FECHA.Text = Asiento.FechaDoc.ToShortDateString();

            //
            DGV.CellLeave += DGV_CellLeave;
            DGV.CellValidating += DGV_CellValidating;
            DGV.CellEndEdit += DGV_CellEndEdit;
            DGV.CellEnter += DGV_CellEnter;
            DGV.CellBeginEdit += DGV_CellBeginEdit;
            DGV.CellPainting += DGV_CellPainting;
            DGV.CellValueChanged += DGV_CellValueChanged;
            DGV.RowValidating += DGV_RowValidating;
            DGV.KeyDown += DGV_KeyDown;
            DGV.ColumnHeaderMouseDoubleClick += DGV_ColumnHeaderMouseDoubleClick;

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
            c1.ReadOnly = false;
            c1.Width = 140;
            c1.DefaultCellStyle.Font = f2;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Descripcion";
            c2.HeaderText = "Descripción";
            c2.Name = "descripcion";
            c2.Visible = true;
            c2.ReadOnly = false;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DefaultCellStyle.BackColor = Color.Blue;
            c3.DataPropertyName = "Debe";
            c3.HeaderText = "Debe";
            c3.Name = "debe";
            c3.Visible = true;
            c3.Width = 150;
            c3.ReadOnly = false;
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
            c4.ReadOnly = false;
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
            items.ListChanged += items_ListChanged;
            bs.DataSource = items;
            DGV.DataSource = bs;
            //

            CargarData(Asiento.Detalles);
        }


        private void DGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                var it = (Detalle)bs.Current;
                it.Haber = 0.0m;
            }
            if (e.ColumnIndex == 3)
            {
                var it = (Detalle)bs.Current;
                it.Debe = 0.0m;
            }
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

            if (e.KeyData == Keys.Delete)
            {
                if (items.Count() > 1)
                {
                    var item = (Detalle)bs.Current;
                    items.Remove(item);
                }
                else
                {
                    items.Clear();
                    items.Add(new Detalle());
                }
            }

            if (e.KeyData == Keys.Down)
            {
                if (bs.CurrencyManager.Position == items.Count - 1)
                {
                    var filaActual = bs.CurrencyManager.Position;
                    DataGridViewRow row = DGV.Rows[filaActual];
                    DataGridViewCell codigoCta = row.Cells[DGV.Columns["codigo"].Index];
                    DataGridViewCell montoDebe = row.Cells[DGV.Columns["debe"].Index];
                    DataGridViewCell montoHaber = row.Cells[DGV.Columns["haber"].Index];
                    if (IsCtaOk(codigoCta) && IsMontoOk(montoDebe, montoHaber))
                    {
                        var item = new Detalle();
                        items.Add(item);
                        DGV.CurrentCell = DGV[0, filaActual + 1];
                    }
                }
            }
        }

        private void DGV_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var item = (Detalle)bs.Current;
            if (item.Codigo == null)
            {
                e.Cancel = false;
            }
            else
            {
                DGV.Rows[e.RowIndex].ErrorText = string.Empty;
                DataGridViewRow row = DGV.Rows[e.RowIndex];
                DataGridViewCell codigoCta = row.Cells[DGV.Columns["codigo"].Index];
                DataGridViewCell montoDebe = row.Cells[DGV.Columns["debe"].Index];
                DataGridViewCell montoHaber = row.Cells[DGV.Columns["haber"].Index];
                e.Cancel = !(IsCtaOk(codigoCta) && IsMontoOk(montoDebe, montoHaber));
            }
        }

        private bool IsMontoOk(DataGridViewCell data1, DataGridViewCell data2)
        {
            decimal m1 = 0;
            decimal m2 = 0;
            var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            var culture = CultureInfo.CreateSpecificCulture("es-ES");
            Decimal.TryParse(data1.Value.ToString(), style, culture, out m1);
            Decimal.TryParse(data2.Value.ToString(), style, culture, out m2);

            if ((m1 + m2) <= 0)
            {
                DGV.Rows[filaActual].ErrorText = "FALTAN POR INTRODUCIR LOS MONTOS";
                return false;
            }

            return true;
        }

        private bool IsCtaOk(DataGridViewCell data)
        {
            if (data.Value == null || data.Value.ToString().Length == 0)
            {
                data.ErrorText = "CODIGO DE CUENTA INCORRECTO";
                DGV.Rows[data.RowIndex].ErrorText = "Por Favor, Introduzca Un Codigo De Cuenta Correcto";
                return false;
            }
            return true;
        }

        private void DGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // e.CellStyle.BackColor = Color.Yellow;
        }

        private void DGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell c = DGV.CurrentCell;
            c.Style.BackColor = Color.Black;
            c.Style.ForeColor = Color.White;
        }

        private void DGV_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell c = DGV.CurrentCell;
            if (e.ColumnIndex == 2)
            {
                c.Style.BackColor = Color.Blue;
                c.Style.ForeColor = Color.White;
            }
            else if (e.ColumnIndex == 3)
            {
                c.Style.BackColor = Color.Red;
                c.Style.ForeColor = Color.White;
            }
            else
            {
                c.Style.BackColor = Color.White;
                c.Style.ForeColor = Color.Black;
            }
        }

        private void DGV_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string msg = String.Format("Editing Cell at ({0}, {1})", e.ColumnIndex, e.RowIndex);
            this.Text = msg;
        }

        int filaActual;
        int columnaActual;
        private void DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string msg = "";
            this.Text = msg;

            filaActual = e.RowIndex;
            columnaActual = e.ColumnIndex;

            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                if (DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    var data = DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    Buscar(data);
                }
            }
            else
            {
                if (e.RowIndex == DGV.Rows.Count - 1)
                {
                    DataGridViewRow row = DGV.Rows[e.RowIndex];
                    DataGridViewCell codigoCta = row.Cells[DGV.Columns["codigo"].Index];
                    DataGridViewCell montoDebe = row.Cells[DGV.Columns["debe"].Index];
                    DataGridViewCell montoHaber = row.Cells[DGV.Columns["haber"].Index];
                    if (IsCtaOk(codigoCta) && IsMontoOk(montoDebe, montoHaber))
                    {
                        var item = new Detalle();
                        items.Add(item);
                        try
                        {
                            DGV.CurrentCell = DGV[0, e.RowIndex + 1];
                            ActualizarSaldos();
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                else
                {
                    try
                    {
                        DGV.CurrentCell = DGV[0, e.RowIndex + 1];
                        ActualizarSaldos();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void DGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                decimal mt = 0.0m;
                var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
                var culture = CultureInfo.CreateSpecificCulture("es-ES");
                if (!Decimal.TryParse(e.FormattedValue.ToString(), style, culture, out mt))
                {
                    e.Cancel = true;
                }
                else
                {
                    DGV.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            }
        }

        private void DGV_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var list = items.ToList().Where(d => d.Cta != null).OrderBy(d => d.Codigo);
                items.Clear();
                foreach (var t in list)
                {
                    items.Add(t);
                }
            }
        }



        private void Buscar(string data)
        {
            CargarPlanCta(data);
        }

        PlanCta.Lista fPlanCta;
        private void CargarPlanCta(string data)
        {
            fPlanCta = new PlanCta.Lista();
            fPlanCta.ItemSeleccionadoOk += fPlanCta_ItemSeleccionadoOk;
            fPlanCta.Buscar(data);
            fPlanCta.ShowDialog();
        }

        private void fPlanCta_ItemSeleccionadoOk(object sender, OOB.Contable.PlanCta.Ficha e)
        {
            if (e.Tipo == OOB.Contable.PlanCta.Enumerados.Tipo.Auxiliar)
            {
                fPlanCta.Close();

                var item = (Detalle)bs.Current;
                item.Cta = e;
                item.Codigo = e.Codigo;
                item.Descripcion = e.Nombre;

                DGV.Rows[filaActual].ErrorText = "";
                DGV.Rows[filaActual].Cells[columnaActual].ErrorText = "";
                int c = 2;
                if (e.Naturaleza == OOB.Contable.PlanCta.Enumerados.Naturaleza.Acreedora) { c = 3; }
                DGV.CurrentCell = DGV[c, filaActual];
            }
            else
            {
                Helpers.Msg.Error("Cuenta No Puede Ser Seleccionada. Debe Ser Una Cuenta Tipo Auxiliar");
            }
        }

        private void ActualizarSaldos()
        {
            MDebe = items.Sum(i => i.Debe);
            MHaber = items.Sum(i => i.Haber);
            L_DEBE.Text = MDebe.ToString("N2");
            L_HABER.Text = MHaber.ToString("N2");
            Diferencia = Math.Abs(MDebe - MHaber);
            DiferenciaModo = (MDebe < MHaber) ? OOB.Contable.PlanCta.Enumerados.Naturaleza.Deudora : OOB.Contable.PlanCta.Enumerados.Naturaleza.Acreedora;

            if (DiferenciaModo == OOB.Contable.PlanCta.Enumerados.Naturaleza.Deudora)
            {
                L_DIF_DEBE.Text = Diferencia.ToString("n2");
                L_DIF_DEBE.Visible = true;

                L_DIF_HABER.Text = "";
                L_DIF_HABER.Visible = false;
            }
            else
            {
                L_DIF_HABER.Text = Diferencia.ToString("n2");
                L_DIF_HABER.Visible = true;

                L_DIF_DEBE.Text = "";
                L_DIF_DEBE.Visible = false;
            }
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            if (MDebe != MHaber) { return; }
            if (MDebe == 0 && MHaber == 0) { return; }
            if (Diferencia != 0) { return; }

            EventHandler<List<Detalle>> handler = AsientoDetalleOk;
            if (handler != null)
            {
                handler(this, items.Where(d=>d.Cta!=null).ToList());
            }

            SalirOk = true;
            Close();
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void EditarAsiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SalirOk == false)
            {
                var msg = MessageBox.Show("Salir Sin Guardar Datos ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == System.Windows.Forms.DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

    }

    
    public class Detalle
    {
        public OOB.Contable.PlanCta.Ficha Cta { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
    }

}