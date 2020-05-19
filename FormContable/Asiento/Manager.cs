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

    public partial class Manager : Form
    {
        BindingSource bs;
        BindingList<OOB.Contable.Asiento.Ficha> Asientos;
        private OOB.Contable.Periodo.Ficha Periodo;


        public Manager(OOB.Contable.Periodo.Ficha periodo)
        {
            InitializeComponent();
            bs = new BindingSource();
            bs.CurrentChanged += bs_CurrentChanged;
            Asientos = new BindingList<OOB.Contable.Asiento.Ficha>();
            bs.DataSource = Asientos;
            this.Periodo = periodo;
        }

        private void bs_CurrentChanged(object sender, EventArgs e)
        {
            var d = (OOB.Contable.Asiento.Ficha)bs.Current;
            if (d != null )
            {
                L_DESCRIPCION.Text=d.Detalle;
                if (d.EstaProcesado == false)
                {
                    L_PENDIENTE.Visible = true;
                }
                else
                {
                    L_PENDIENTE.Visible = false;
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

        private void Manager_Load(object sender, EventArgs e)
        {
            L_DESCRIPCION.Text = "";
            L_PENDIENTE.Text = "";

            DGV.AllowUserToAddRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.ReadOnly = true;
            DGV.DataSource = bs;

            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 9, FontStyle.Regular);

            var c0 = new DataGridViewTextBoxColumn();
            c0.DataPropertyName = "Comprobante";
            c0.HeaderText = "Comp/Nro";
            c0.Visible = true;
            c0.Width = 90;
            c0.HeaderCell.Style.Font = f;
            c0.DefaultCellStyle.Font = f1;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "TipoAsientoDesc";
            c1.HeaderText = "Asiento";
            c1.Visible = true;
            c1.Width = 80;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "FechaEmision";
            c2.HeaderText = "Fecha";
            c2.Visible = true;
            c2.Width = 80;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "TipoDocumentoDescripcion";
            c3.HeaderText = "Documento";
            c3.Visible = true;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Importe";
            c4.HeaderText = "Importe";
            c4.Visible = true;
            c4.Width = 100;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format = "n2";

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "EstaAnulado";
            c6.Name = "Anulado";
            c6.HeaderText = "";
            c6.Visible = false;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "ReglaAplica";
            c7.HeaderText = "ORIGEN";
            c7.Visible = true;
            c7.Width = 140;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "MesAnoRelacion";
            c8.HeaderText = "Periodo";
            c8.Visible = true;
            c8.Width = 60;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;

            DGV.Columns.Add(c0);
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c8);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c6);
        }

        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                row.DefaultCellStyle.ForeColor = (bool)row.Cells["Anulado"].Value ? Color.Red : Color.Black;
            }
        }


        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        async private void Buscar()
        {
            var result = await Globals.MyData.Asiento_Lista();
            var l = result.Lista.OrderByDescending(d => d.Comprobante).ToList();

            Asientos.Clear();
            foreach (var it in l)
            {
                Asientos.Add(it);
            }
        }

        private void BT_ELIMINAR_Click(object sender, EventArgs e)
        {
            EliminarAsiento();
        }

        private void EliminarAsiento()
        {
            if (bs.Current == null)
            {
                return;
            }

            var ficha = (OOB.Contable.Asiento.Ficha)bs.Current;
            if (ficha.EstaAnulado)
            {
                Helpers.Msg.Error("FICHA YA ANULADA !!!");
                return;
            }

            var msg = MessageBox.Show("Anular Asiento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                var r01 = Globals.MyData.Asiento_Anular(ficha);
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

        private void BT_EDITAR_Click(object sender, EventArgs e)
        {
            VisualizarEditarAsiento();
        }

        private void VisualizarEditarAsiento()
        {
            if (bs.Current != null)
            {
                var it = (OOB.Contable.Asiento.Ficha)bs.Current;
                if (it.EstaAnulado == false)
                {
                    if (it.AutoGenerado)
                    {
                    }
                    else if (it.TipoAsiento == OOB.Contable.Asiento.Enumerados.Tipo.Apertura) 
                    {
                        var fEditarApertura = new Asiento.Apertura.Agregar (Periodo);
                        fEditarApertura.EditarOk += fEditarAsiento_EditarOk;
                        fEditarApertura.Editar(it.Id);
                        fEditarApertura.ShowDialog();
                    }
                    else
                    {
                        var fEditarAsiento = new Asiento.Agregar(Periodo);
                        fEditarAsiento.EditarOk += fEditarAsiento_EditarOk;
                        fEditarAsiento.Editar(it.Id);
                        fEditarAsiento.ShowDialog();
                    }
                }
                else
                {
                    Helpers.Msg.Alerta("!! COMPROBANTE SE ENCUENTRA ANULADO !!");
                }
            }
        }

        private void fEditarAsiento_EditarOk(object sender, int e)
        {
            var it = (OOB.Contable.Asiento.Ficha)bs.Current;
            var r01 = Globals.MyData.Asiento_GetById(e);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            it.Id = r01.Entidad.Id;
            it.Comprobante = r01.Entidad.Comprobante;
            it.Detalle = r01.Entidad.Detalle;
            it.FechaEmision = r01.Entidad.FechaEmision;
            it.TipoAsiento = r01.Entidad.TipoAsiento;
            it.EstaAnulado = r01.Entidad.EstaAnulado;
            it.EstaProcesado = r01.Entidad.EstaProcesado;
            it.AutoGenerado = r01.Entidad.AutoGenerado;
            it.Importe = r01.Entidad.Importe;
            it.TipoDocumento = r01.Entidad.TipoDocumento;

            if (it.EstaProcesado == false)
            {
                L_PENDIENTE.Visible = true;
            }
            else
            {
                L_PENDIENTE.Visible = false;
            }

            DGV.Refresh();
        }

        private void BT_EXPORTAR_Click(object sender, EventArgs e)
        {
            ExportarItem();
        }

        private void ExportarItem()
        {
            if (bs.Current != null)
            {
                var it = (OOB.Contable.Asiento.Ficha)bs.Current;
                if (it.AutoGenerado)
                {
                }
                else
                {
                    var fEditarAsiento = new Asiento.Agregar(Periodo);
                    fEditarAsiento.Exportar(it.Id);
                    fEditarAsiento.ShowDialog();
                }
            }
        }

        private void BT_VISUALIZAR_Click(object sender, EventArgs e)
        {
            VisualizarAsiento();
        }

        private void VisualizarAsiento()
        {
            if (bs.Current != null)
            {
                var it = (OOB.Contable.Asiento.Ficha)bs.Current;
                {
                    if (!it.AutoGenerado)
                    {
                        var fVerAsiento = new Asiento.Visualizar();
                        fVerAsiento.Cargar(it.Id);
                        fVerAsiento.ShowDialog();
                    }
                    else 
                    {

                        var ficha = (OOB.Contable.Asiento.Ficha)bs.Current;
                        var r01 = Globals.MyData.Integracion_GetBy(null, ficha);
                        if (r01.Result == OOB.Resultado.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r01.Mensaje);
                            return;
                        }

                        var fVisualizar = new Integraciones.Visualizar();
                        fVisualizar.Cargar(r01.Entidad);
                    }
                }
            }
        }

        private void BT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            ImprimirComprobante();
        }

        private void ImprimirComprobante()
        {
            if (bs.Current != null)
            {
                var it = (OOB.Contable.Asiento.Ficha)bs.Current;
                {
                    Helpers.Utilitis.ImprimirComprobante(it.Id);
                }
            }
        }
     
    }

}