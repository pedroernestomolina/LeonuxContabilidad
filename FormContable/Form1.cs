using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormContable
{
    public partial class Form1 : Form
    {

        private OOB.Contable.Periodo.Ficha PeriodoActual;
        private OOB.Empresa.DatosNegocio.Ficha DatosNegocio;
        private bool AsientoAperturaIsOk;

        public Form1()
        {
            InitializeComponent();
        }

        private void MenuManagerPlanCta_Click(object sender, EventArgs e)
        {
            var fplanCta = new PlanCta.Manager();
            fplanCta.ShowDialog();
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }
       
        private void Salir()
        {
            Close();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            L_VERSION.Text = "Gestión Contable. Ver " + Application.ProductVersion;
            L_PERIODO_MES.Text = "";
            L_PERIODO_ANO.Text = "";
            L_SERVIDOR_DATOS.Text= "";
            CargarData();
        }

        private void CargarData()
        {
            var r01 = Globals.MyData.Contadores_PeriodoActual_Get();
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var r02 = Globals.MyData.Servidor_GetDatos ();
            if (r02.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }

            var r03 = Globals.MyData.Asiento_Apertura_IsOk ();
            if (r03.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return;
            }

            var r04 = Globals.MyData.Empresa_DatosNegocio();
            if (r04.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return;
            }

            DatosNegocio = r04.Entidad;
            PeriodoActual = r01.Entidad;
            L_PERIODO_MES.Text = PeriodoActual.MesActualDesc;
            L_PERIODO_ANO.Text = PeriodoActual.AnoActualDesc;
            L_SERVIDOR_DATOS.Text = r02.Entidad;
            AsientoAperturaIsOk = false ;
            MenuAsientoApertura.Enabled = !AsientoAperturaIsOk;
        }

        private void MenuAsiento_Integracion_Click(object sender, EventArgs e)
        {
            var fGenerar = new Operaciones.Generar(PeriodoActual);
            fGenerar.Nuevo();
            fGenerar.ShowDialog();
        }

        private void MenuAsientoApertura_Click(object sender, EventArgs e)
        {
          //  AsientoApertura();
        }

        private void MenuAsiento_Manual_Click(object sender, EventArgs e)
        {
            var fagregarAsiento = new Asiento.Agregar(PeriodoActual);
            fagregarAsiento.Nuevo();
            fagregarAsiento.ShowDialog();
        }

        private void MenuAdministradorIntegraciones_Click(object sender, EventArgs e)
        {
            var fIntegraciones = new Integraciones.Manager();
            fIntegraciones.ShowDialog();
        }

        private void MenuAdministradorAsiento_Click(object sender, EventArgs e)
        {
            var fAsiento = new Asiento.Manager(PeriodoActual);
            fAsiento.ShowDialog();
        }

        private void MenuInvDepartamentos_Click(object sender, EventArgs e)
        {
            CnfInvDepartamentos();
        }

        private void MenuCompraConceptos_Click(object sender, EventArgs e)
        {
            CnfCompraConceptos();
        }

        private void MenuBanco_Click(object sender, EventArgs e)
        {
            CnfBanco();
        }

        private void CnfInvDepartamentos()
        {
            var fDep = new Configuracion.Departamentos.Manager();
            fDep.ShowDialog();
        }

        private void CnfCompraConceptos()
        {
            var fConcepto= new Configuracion.Conceptos.Manager();
            fConcepto.ShowDialog();
        }

        private void CnfBanco()
        {
            var fBanco = new Configuracion.Banco.Manager();
            fBanco.ShowDialog();
        }

        private void MenuMaestroDocumentos_Click(object sender, EventArgs e)
        {
            MaestroDocumentos();
        }

        private void MaestroDocumentos()
        {
            var fDocumentos = new Maestros.TipoDocumento.Manager();
            fDocumentos.ShowDialog();
        }

        private void AsientoApertura()
        {
            var r01 = Globals.MyData.Asiento_Apertura_Get_ID();
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var IdAsientoApertura = r01.Entidad;
            if (IdAsientoApertura==-1)
            {
                var fApertura = new Asiento.Apertura.Agregar(PeriodoActual);
                fApertura.GuardarOk+=fApertura_GuardarOk;
                fApertura.Nuevo();
                fApertura.ShowDialog();
            }
            else 
            {
                var fApertura  = new Asiento.Apertura.Agregar(PeriodoActual);
                fApertura.GuardarOk += fApertura_GuardarOk;
                fApertura.Editar(IdAsientoApertura);
                fApertura.ShowDialog();
            }
        }

        private void fApertura_GuardarOk(object sender, EventArgs e)
        {
            var r01 = Globals.MyData.Asiento_Apertura_IsOk();
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            AsientoAperturaIsOk = r01.Entidad;
            MenuAsientoApertura.Enabled = !AsientoAperturaIsOk;
        }

        private void MenuReporteBalanceComprobacion_Click(object sender, EventArgs e)
        {
            ReporteBalanceComprobacion();
        }

        private void MenuReporteGananciaPerdida_Click(object sender, EventArgs e)
        {
            ReporteBalanceGananciaPerdida();
        }

        private void MenuReporteBalanceGeneral_Click(object sender, EventArgs e)
        {
            ReporteBalanceGeneral();
        }

        private void ReporteBalanceComprobacion()
        {
            var filtro = new OOB.Reportes.Balances.Comprobacion.Filtro();
            var r01 = Globals.MyData.Reportes_Balance_Comprobacion(filtro);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Globals.MyReports.Balance_Comprobacion(r01.Lista, PeriodoActual,DatosNegocio);
        }
        
        private void ReporteBalanceGananciaPerdida()
        {
            var filtro = new OOB.Reportes.Balances.GananciaPerdida.Filtro();
            var r01 = Globals.MyData.Reportes_Balance_GananciaPerdida(filtro);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Globals.MyReports.Balance_GananciaPerdida(r01.Lista.Where(d => d.Saldo != 0), PeriodoActual, DatosNegocio);
        }

        private void ReporteBalanceGeneral()
        {
            //UTILIDAD DEL PERIODO
            var r01 = Globals.MyData.Periodo_Utilidad();
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            //CUAL ES LA CUENTA DE UTILIDAD DEL EJERCICIO
            var r02 = Globals.MyData.Configuracion_CtasCierre();
            if (r02.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }

            //SALDO DE CUENTA UTILIDAD DEL EJERCICIO
            var r02_01 = Globals.MyData.PlanCta_GetById(r02.Entidad.CtaCierreMes.Id);  
            if (r02_01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_01.Mensaje);
                return;
            }

            //UTILIDAD ACUMULADA MES ANTERIOR
            var utilidadAcumulada = 0.0m;
            var r03 = Globals.MyData.Utilidad_Acumulada();
            if (r03.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return;
            }
            utilidadAcumulada = r03.Entidad*(-1);  // LA UTILIDAD SIEMPRE ES NEGATIVA, POR LA NATURALEZA DE LA CUENTE

            var filtro = new OOB.Reportes.Balances.General.Filtro();
            filtro.CuentaCierreMes = r02_01.Entidad;
            filtro.UtilidadPeriodo = (r01.Entidad + utilidadAcumulada);
            filtro.SaldoCtaCierre = r02_01.Entidad.Saldo*(-1); 

            var r04 = Globals.MyData.Reportes_Balance_General(filtro);
            if (r04.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return;
            }

            Globals.MyReports.Balance_General(r04.Lista, PeriodoActual, DatosNegocio);
        }

        private void MenuCerrarAbrirMes_Click(object sender, EventArgs e)
        {
            CerrarMes();
        }

        private void CerrarMes()
        {
            var fCerrar = new Periodo.CerrarMes(PeriodoActual);
            fCerrar.CerrarOk+=fCerrar_CerrarOk;
            fCerrar.ShowDialog();
        }

        private void fCerrar_CerrarOk(object sender, EventArgs e)
        {
            var r04 = Globals.MyData.Contadores_PeriodoActual_Get();
            if (r04.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return;
            }

            PeriodoActual = r04.Entidad;
            L_PERIODO_MES.Text = PeriodoActual.MesActualDesc;
            L_PERIODO_ANO.Text = PeriodoActual.AnoActualDesc;
        }

        private void MenuCierreReversoMes_Click(object sender, EventArgs e)
        {
            ReversarMes();
        }

        private void ReversarMes()
        {
            var fReversar = new Periodo.ReversarMes(PeriodoActual);
            fReversar.RevesarOk += fReversar_RevesarOk;
            fReversar.ShowDialog();
        }

        private void fReversar_RevesarOk(object sender, EventArgs e)
        {
            var r02 = Globals.MyData.Contadores_PeriodoActual_Get();
            if (r02.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }

            PeriodoActual = r02.Entidad;
            L_PERIODO_MES.Text = PeriodoActual.MesActualDesc;
            L_PERIODO_ANO.Text = PeriodoActual.AnoActualDesc;
        }

        private void MenuReporteHistoricoBalanceComprobacion_Click(object sender, EventArgs e)
        {
            ReporteHistoricoBalanceComprobacion();
        }

        private void ReporteHistoricoBalanceComprobacion()
        {
            var fperiodo = new Periodo.SeleccionarPeriodo();
            fperiodo.PeriodoSeleccionadoOk +=fperiodo_PeriodoSeleccionadoOk;
            fperiodo.ShowDialog();
        }

        private void fperiodo_PeriodoSeleccionadoOk(object sender, Periodo.PeriodoSeleccion e)
        {
            var filtro = new OOB.Reportes.Balances.Comprobacion.Filtro();
            filtro.Desde = e.Desde ;
            filtro.Hasta = e.Hasta;
            var r01 = Globals.MyData.Reportes_Balance_Comprobacion(filtro);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Globals.MyReports.Balance_Comprobacion(r01.Lista, e.Hasta , DatosNegocio);
        }

        private void MenuReporteHistoricoGananciaPerdida_Click(object sender, EventArgs e)
        {
            ReporteHistoricoGananciaPerdida();
        }

        private void ReporteHistoricoGananciaPerdida()
        {
            var fperiodo = new Periodo.SeleccionarPeriodo();
            fperiodo.PeriodoSeleccionadoOk += fperiodo_PeriodoSeleccionadoOk_GananciaPerdida;
            fperiodo.ShowDialog();
        }

        private void fperiodo_PeriodoSeleccionadoOk_GananciaPerdida(object sender, Periodo.PeriodoSeleccion e)
        {
            var filtro = new OOB.Reportes.Balances.GananciaPerdida.Filtro();
            filtro.Desde = e.Desde;
            filtro.Hasta = e.Hasta;
            var r01 = Globals.MyData.Reportes_Balance_GananciaPerdida(filtro);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Globals.MyReports.Balance_GananciaPerdida(r01.Lista.Where(d => d.Saldo != 0), e.Hasta , DatosNegocio);
        }

        private void MenuReporteHistoricoBalanceGeneral_Click(object sender, EventArgs e)
        {
            ReporteHistoricoBalanceGeneral();
        }

        private void ReporteHistoricoBalanceGeneral()
        {
            var fperiodo = new Periodo.SeleccionarPeriodo();
            fperiodo.PeriodoSeleccionadoOk += fperiodo_PeriodoSeleccionadoOk_BalanceGeneral;
            fperiodo.ShowDialog();
        }

        private void fperiodo_PeriodoSeleccionadoOk_BalanceGeneral(object sender, Periodo.PeriodoSeleccion e)
       {
            var r02 = Globals.MyData.Configuracion_CtasCierre();
            if (r02.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }
                     
            var r03 = Globals.MyData.Utilidad_Acumulada_Hasta_Periodo(e.Hasta);
            if (r03.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return;
            }

            var filtro = new OOB.Reportes.Balances.General.Filtro();
            filtro.CuentaCierreMes = r02.Entidad.CtaCierreMes;
            filtro.UtilidadPeriodo = (r03.Entidad);
            filtro.Desde = e.Desde;
            filtro.Hasta = e.Hasta;

            var r04 = Globals.MyData.Reportes_Balance_General(filtro);
            if (r04.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return;
            }

            Globals.MyReports.Balance_General(r04.Lista, e.Hasta , DatosNegocio);
        }

        private void MenuConfiguracionContable_Click(object sender, EventArgs e)
        {
            ConfiguracionContable();
        }

        private void ConfiguracionContable()
        {
            var fConf = new Configuracion.Contable.Manager ();
            fConf.ShowDialog();
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    
    }

}