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
    public partial class Manager : Form
    {

        BindingSource bs;
        BindingList<OOB.Contable.PlanCta.Ficha> Ctas;


        public Manager()
        {
            InitializeComponent();
            bs = new BindingSource();
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            TB_SALDO_APERTURA.Text = "0.0";
            TB_SALDO_ANTERIOR.Text = "0.0";
            TB_SALDO_DEBE.Text="0.0";
            TB_SALDO_HABER.Text = "0.0";
            TB_SALDO_MES.Text = "0.0";

            DGV.AllowUserToAddRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.ReadOnly = true;

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
            CargarPlanCta();
        }

        async private void CargarPlanCta()
        {
            var r01 = await Cargar("");
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var l = r01.Lista.OrderBy(d => d.Codigo).ToList();
            Ctas = new BindingList<OOB.Contable.PlanCta.Ficha>(l);
            bs.DataSource = Ctas;
            DGV.DataSource = bs;

            TB_CODIGO.DataBindings.Add("Text", bs, "Codigo");
            TB_DESCRIPCION.DataBindings.Add("Text", bs, "Nombre");
            TB_TIPO.DataBindings.Add("Text", bs, "TipoDescripcion");
            TB_NATURALEZA.DataBindings.Add("Text", bs, "NaturalezaDescripcion");
            TB_ESTADO.DataBindings.Add("Text", bs, "EstadoSituacionDescripcion");

            var bsaldo_apertura = new Binding("Text", bs, "SaldoActual.Apertura", true);
            bsaldo_apertura.FormatString = "n2";
            TB_SALDO_APERTURA.DataBindings.Add(bsaldo_apertura);

            var bsaldo_anterior = new Binding("Text", bs, "SaldoActual.Anterior", true);
            bsaldo_anterior.FormatString = "n2";
            TB_SALDO_ANTERIOR.DataBindings.Add(bsaldo_anterior);

            var bsaldo_debe = new Binding("Text", bs, "Debe",true);
            bsaldo_debe.FormatString = "n2";
            TB_SALDO_DEBE.DataBindings.Add(bsaldo_debe);

            var bsaldo_haber = new Binding("Text", bs, "Haber", true);
            bsaldo_haber.FormatString = "n2";
            TB_SALDO_HABER.DataBindings.Add(bsaldo_haber);

            var bsaldo_mes = new Binding("Text", bs, "Saldo",true);
            bsaldo_mes.FormatString = "n2";
            TB_SALDO_MES.DataBindings.Add(bsaldo_mes);
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
            this.Close();
        }

        private void MenuAgregar_Click(object sender, EventArgs e)
        {
            AgregarCta();
        }

        private void BT_AGREGAR_Click(object sender, EventArgs e)
        {
            AgregarCta();
        }

        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            EliminarCta();
        }

        private void BT_ELIMINAR_Click(object sender, EventArgs e)
        {
            EliminarCta();
        }

        private void MenuRefrescar_Click(object sender, EventArgs e)
        {
            RefrescarLista();
        }

        private void BT_REFRESH_Click(object sender, EventArgs e)
        {
            RefrescarLista();
        }

        Agregar fagregar = null;
        private void AgregarCta()
        {
            fagregar = new Agregar();
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
            ActualizarLista(e);
        }

        private void EliminarCta()
        {
            if (bs != null)
            {
                if (bs.Current != null)
                {
                    var ficha = (OOB.Contable.PlanCta.Ficha)bs.Current;
                    var eliminar = new Eliminar();
                    if (eliminar.Elimina(ficha))
                    {
                        bs.Remove(ficha);
                        Helpers.Msg.EliminarOk();
                    };
                }
            }
        }

        async private void RefrescarLista()
        {
            var r01 = await Cargar("");
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
        }

        private void BT_MOVIMIENTO_Click(object sender, EventArgs e)
        {
            Movimiento();
        }

        private void Movimiento()
        {
            var filt = new OOB.Contable.Cuenta.Filtro()
            {
                Cta = (OOB.Contable.PlanCta.Ficha)bs.Current,
                Desde = DTP_DESDE.Value.Date,
                Hasta = DTP_HASTA.Value.Date
            };

            var fMovimiento = new Movimiento(filt);
            fMovimiento.ShowDialog();
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        Busqueda.Buscar fBuscar;
        private void Buscar()
        {
            fBuscar = new Busqueda.Buscar();
            fBuscar.BuscarOk += fBuscar_BuscarOk;
            fBuscar.ShowDialog();
        }

        async private void fBuscar_BuscarOk(object sender, string e)
        {
            fBuscar.Close();

            var r01 = await Cargar(e);
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
        }

        async private Task<OOB.Resultado.ResultadoLista<OOB.Contable.PlanCta.Ficha>> Cargar(string cadena)
        {
            var filt = new OOB.Contable.PlanCta.Filtro() { Cadena = cadena };
            return await Globals.MyData.PlanCta_Lista(filt);
        }

        private void BT_EDITAR_Click(object sender, EventArgs e)
        {
            EditarCta();
        }

        private void MenuEditar_Click(object sender, EventArgs e)
        {
            EditarCta();
        }

        int Position = -1;
        private void EditarCta()
        {
            if (bs != null) 
            {
                if (bs.Current != null) 
                {
                    var ficha = (OOB.Contable.PlanCta.Ficha)bs.Current;
                    Position = bs.Position;
                    var fEditar = new Editar(ficha);
                    fEditar.EditarOk += fEditar_EditarOk;
                    fEditar.ShowDialog();
                }
            }
        }

        private void fEditar_EditarOk(object sender, int e)
        {
            var r = Ctas.FirstOrDefault(d => d.Id == e);
            if (r != null) 
            {
                Ctas.Remove(r);
                ActualizarLista(e);
                bs.Position = Position;
            }
        }

        private void ActualizarLista(int e)
        {
            var r01 = Globals.MyData.PlanCta_GetById(e);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Ctas.Add(r01.Entidad);
            var list = Ctas.OrderBy(d => d.Codigo).ToList();
            Ctas.Clear();
            foreach (var it in list)
            {
                Ctas.Add(it);
            }
        }

        private void BT_COMPROBACION_Click(object sender, EventArgs e)
        {
            Balance();
        }

        private void Balance()
        {
            var filt = new OOB.Contable.Cuenta.Filtro()
            {
                Cta = (OOB.Contable.PlanCta.Ficha)bs.Current,
                Desde = DTP_BALANCE_DESDE.Value.Date,
                Hasta = DTP_BALANCE_HASTA.Value.Date
            };

            var fBalance = new Balance (filt);
            fBalance.ShowDialog();
        }

        private void MenuReporteMaestroCta_Click(object sender, EventArgs e)
        {
            MenuReporteMaestroCtass();
        }
      
        private void maestroDeCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuReporteMaestroCtass();
        }

        private void MenuReporteMaestroCtass()
        {
            var r01 = Globals.MyData.Reportes_PlanCta_Maestro();
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Globals.MyReports.PlanCta_MaestroCta(r01.Lista);
        }
      
    }

}