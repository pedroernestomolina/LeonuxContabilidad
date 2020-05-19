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


namespace FormContable.Asiento.Apertura
{

    public partial class Agregar : Form
    {

        public event EventHandler GuardarOk;
        public event EventHandler<int> EditarOk;
        enum Modo { AgregarFicha = 1, EditarFicha, ExportarFicha };
        enum EnumGuardarComo { Preview=1, Contabilizado }


        //
        private BindingSource bs;
        private BindingList<Detalle> items;
        private decimal MDebe;
        private decimal MHaber;
        private decimal Diferencia;
        private OOB.Contable.PlanCta.Enumerados.Naturaleza DiferenciaModo;
        private OOB.Contable.Contadores.Ficha Contadores;
        private OOB.Contable.Periodo.Ficha Periodo;
        private OOB.Contable.Asiento.Ficha Asiento;
        private Modo ModoFicha;
        private int IdAsientoEditarExportar;
        private EnumGuardarComo GuardarComo;
        private bool salirOk;
        //


        public Agregar(OOB.Contable.Periodo.Ficha periodo)
        {
            InitializeComponent();

            MDebe = 0.0m;
            MHaber = 0.0m;
            Diferencia = 0.0m;
            this.Periodo = periodo;
            GuardarComo = EnumGuardarComo.Contabilizado;
        }

        public void Nuevo()
        {
            ModoFicha = Modo.AgregarFicha ;
        }

        public void Editar(int idAsiento )
        {
            ModoFicha = Modo.EditarFicha;
            this.IdAsientoEditarExportar = idAsiento;
        }

        public void Exportar(int idAsiento, OOB.Contable.Periodo.Ficha periodo)
        {
            ModoFicha = Modo.ExportarFicha;
            this.IdAsientoEditarExportar = idAsiento;
            this.Periodo = periodo;
        }
        
        private void items_ListChanged(object sender, ListChangedEventArgs e)
        {
            ActualizarSaldos();
        }

        private void Agregar_Load(object sender, EventArgs e)
        {
            DTP_FECHA.Select();
            L_NUMERO.Text = "";
            L_DIF_DEBE.Text = "";
            L_DIF_HABER.Text = "";

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

            if (ModoFicha== Modo.AgregarFicha)
            {
                CargarData();
                var it = new Detalle();
                items.Add(it);
            }
            else if (ModoFicha == Modo.EditarFicha)
            {
                L_MODO_FICHA.Visible = true;
                CargarDataAsiento(IdAsientoEditarExportar);
            }
            else
            {
                CargarDataExportar(IdAsientoEditarExportar);
            }
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
                        catch (Exception )
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
                    catch (Exception )
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
        
        private void ActualizarSaldos()
        {
            MDebe = items.Sum(i => i.Debe );
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

        private void CargarData()
        {
            var r01 = Globals.MyData.Contadores_Get();
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Contadores = r01.Entidad;
            L_NUMERO.Text = Contadores.CntAsiento;
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

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            var v = GuardarComo == EnumGuardarComo.Contabilizado ? true : false;
            Procesar(v);
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
      
        private void Procesar(bool Procesado=true)
        {
            if (MDebe == 0 && MHaber == 0) { return; }
            if (TB_DESCRIPCION.Text.Trim() == "") { return; }
            if (Procesado)
            {
                if (MDebe != MHaber) { return; }
            }

            var importe = 0.0m;
            if (Procesado)
            {
                importe = MDebe;
            }
            else
            {
                importe = MDebe > MHaber ? MDebe : MHaber;
            }

            var msg = MessageBox.Show("Procesar Asiento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                var ficha = new OOB.Contable.Asiento.Apertura.Insertar()
                {
                    Asiento= this.Asiento,
                    Periodo = this.Periodo,
                    Descripcion = TB_DESCRIPCION.Text,
                    Fecha = DTP_FECHA.Value,
                    IsPreview = !Procesado,
                    Importe = importe,
                    Detalles = items.Where(it => it.Cta != null && (it.Debe + it.Haber) > 0).Select(d =>
                    {
                        return new OOB.Contable.Asiento.Apertura.InsertarDetalles()
                        {
                            Cta = d.Cta,
                            Debe = d.Debe,
                            Haber = d.Haber
                        };
                    }).ToList()
                };
                Guardar(ficha);
            }
        }

        private void Editar(OOB.Contable.Asiento.Editar ficha)
        {
            //var result = Globals.MyData.Asiento_Editar(ficha);
            //if (result.Result == OOB.Resultado.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(result.Mensaje);
            //    return;
            //}

            //EventHandler<int> handler = EditarOk;
            //if (handler != null)
            //{
            //    handler(this, result.Id);
            //}

            //Helpers.Msg.EditarOk();
            //salirOk = true;
            //Close();
        }

        private void Guardar(OOB.Contable.Asiento.Apertura.Insertar ficha)
        {
            var result = Globals.MyData.Asiento_Apertura_Guardar(ficha);
            if (result.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(result.Mensaje);
                return;
            }

            EventHandler handler = GuardarOk;
            if (handler != null)
            {
                handler(this, null);
            }

            Helpers.Msg.AgregarOk();
            salirOk = true;
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

            var r03 = Globals.MyData.Contadores_Get();
            if (r03.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return;
            }

            Contadores = r03.Entidad;
            Asiento = r01.Entidad;
            if (Asiento.EstaProcesado)
            {
                MenuGuardarPreview.Enabled = false;
                MenuGuardarPreview.Checked = false;
            }
            else
            {
                MenuGuardarPreview.Enabled = true;
                MenuGuardarPreview.Checked = true;
            }

            var Documento = Asiento.Documentos.FirstOrDefault();
            TB_DESCRIPCION.Text = Documento.Descripcion;
            DTP_FECHA.Value = Documento.Fecha;
            
            var it = new Detalle();
            foreach (var cta in Documento.Cuentas)
            {
                var rt = Globals.MyData.PlanCta_GetById(cta.Cuenta.IdPlanCta);
                if (rt.Result == OOB.Resultado.EnumResult.isError)
                {
                    Helpers.Msg.Error(rt.Mensaje);
                    return;
                }

                var dt = new Detalle();
                dt.Cta = rt.Entidad;
                dt.Codigo=cta.Cuenta.CodigoCta;
                dt.Descripcion = cta.Cuenta.DescripcionCta;
                dt.Debe  = cta.MontoDebe;
                dt.Haber = cta.MontoHaber;
                items.Add(dt);
            }
        }

        private void CargarDataExportar(int IdAsientoEditarExportar)
        {
            var r01 = Globals.MyData.Asiento_GetById(IdAsientoEditarExportar);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var r02 = Globals.MyData.TipoDocumento_Lista();
            if (r02.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }

            var r03 = Globals.MyData.Contadores_Get();
            if (r03.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return;
            }

            Contadores = r03.Entidad;
            L_NUMERO.Text = Contadores.CntAsiento;

            Asiento = r01.Entidad;
            var Documento = Asiento.Documentos.FirstOrDefault();
            TB_DESCRIPCION.Text = Documento.Descripcion;
            DTP_FECHA.Value = Documento.Fecha;

            var it = new Detalle();
            items.Add(it);
            foreach (var cta in Documento.Cuentas)
            {
                var rt = Globals.MyData.PlanCta_GetById(cta.Cuenta.IdPlanCta);
                if (rt.Result == OOB.Resultado.EnumResult.isError)
                {
                    Helpers.Msg.Error(rt.Mensaje);
                    return;
                }

                var dt = new Detalle();
                dt.Cta = rt.Entidad;
                dt.Debe = cta.MontoDebe;
                dt.Haber = cta.MontoHaber;
                items.Add(dt);
            }
        }

        private void Agregar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (salirOk == false)
            {
                if (items == null || items.Count() == 0)
                {
                    e.Cancel = false;
                    return;
                }

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

        private void MenuGuardarPreview_CheckedChanged(object sender, EventArgs e)
        {
            var bt = (ToolStripMenuItem)sender;
            GuardarComo = bt.Checked ? EnumGuardarComo.Preview : EnumGuardarComo.Contabilizado;
            if (GuardarComo == EnumGuardarComo.Preview)
            {
                L_ASIENTO.Text = "";
                L_NUMERO.Text = "PREVIEW";
                //if (ModoFicha == Modo.AgregarFicha || ModoFicha== Modo.ExportarFicha)
                //{
                //    L_NUMERO.Text = Contadores.CntAsientoPreview;
                //}
                //else 
                //{
                //    L_NUMERO.Text = Asiento.Comprobante ;
                //}
            }
            else
            {
                L_ASIENTO.Text = "Asiento No";
                L_NUMERO.Text = Contadores.CntAsiento;
            }
        }

        private void DTP_FECHA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ProximoControl();
            }
        }

        private void TB_DESCRIPCION_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ProximoControl();
            }
        }

        private void ProximoControl()
        {
            SendKeys.Send("{TAB}");
        }
     
    }

}