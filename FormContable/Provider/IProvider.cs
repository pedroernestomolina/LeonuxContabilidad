using OOB.Resultado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormContable.Provider
{

    public interface IProvider: IEmpresaProvider, IProveedorProvider, ICompraProvider, IBancoProvider, IReportProvider
    {

        //SERVIDOR
        ResultadoEntidad<DateTime> Servidor_GetFecha();
        ResultadoEntidad<String> Servidor_GetDatos();


        //CONTADORES
        ResultadoEntidad<OOB.Contable.Contadores.Ficha> Contadores_Get();


        //CONFIGURACION 
        Resultado Configuracion_CtasCierre_Editar(OOB.Contable.Configuracion.CuentasCierre ficha);
        ResultadoEntidad<OOB.Contable.Configuracion.CuentasCierre> Configuracion_CtasCierre();


        //PERIODO
        ResultadoEntidad<OOB.Contable.Periodo.Ficha> Contadores_PeriodoActual_Get();
        ResultadoEntidad<decimal> Periodo_Utilidad();
        ResultadoEntidad<decimal> Utilidad_Acumulada();
        ResultadoEntidad<decimal> Utilidad_Acumulada_Hasta_Periodo(OOB.Contable.Periodo.Ficha ficha);
        Resultado Periodo_Cerrar(OOB.Contable.Periodo.CerrarMes ficha);
        Resultado Periodo_Reversar(OOB.Contable.Periodo.Ficha ficha);
        ResultadoLista<OOB.Contable.Periodo.Ficha> Periodo_Lista ();


        //TIPO DOCUMENTO
        ResultadoLista<OOB.Contable.TipoDocumento.Ficha> TipoDocumento_Lista();
        ResultadoId TipoDocumento_Insertar(OOB.Contable.TipoDocumento.Insertar ficha);
        Resultado TipoDocumento_Editar(OOB.Contable.TipoDocumento.Editar ficha);
        Resultado TipoDocumento_Eliminar(OOB.Contable.TipoDocumento.Eliminar ficha);
        ResultadoEntidad<OOB.Contable.TipoDocumento.Ficha> TipoDocumento_Get(int id);


        //PLAN DE CUENTA
        Task<ResultadoLista<OOB.Contable.PlanCta.Ficha>> PlanCta_Lista(OOB.Contable.PlanCta.Filtro filtro);
        ResultadoEntidad<OOB.Contable.PlanCta.Ficha> PlanCta_GetById(int id);
        ResultadoId PlanCta_Agregar(OOB.Contable.PlanCta.Agregar ficha);
        Resultado PlanCta_Editar(OOB.Contable.PlanCta.Editar ficha);
        Resultado PlanCta_Eliminar(OOB.Contable.PlanCta.Ficha ficha);
        ResultadoEntidad<OOB.Contable.PlanCta.Padre> PlanCta_GetPadre(string codigoCta);


        //CUENTA
        ResultadoLista<OOB.Contable.Cuenta.Movimiento> Cuenta_GetMovimiento(OOB.Contable.Cuenta.Filtro filt);
        ResultadoLista<OOB.Contable.Cuenta.Balance> Cuenta_GetBalance(OOB.Contable.Cuenta.Filtro filt);
        ResultadoEntidad<Decimal> Cuenta_GetSaldoAl(OOB.Contable.PlanCta.Ficha cta, DateTime al);


        //ASIENTO
        Task<ResultadoLista<OOB.Contable.Asiento.Ficha>> Asiento_Lista();
        Task<ResultadoLista<OOB.Contable.Asiento.Generar.Ficha>>  Asiento_Generar(OOB.Contable.Asiento.Generar.Filtro ficha);
        ResultadoId Asiento_Insertar_Integracion(OOB.Contable.Asiento.Generar.Insertar ficha);
        Resultado Asiento_Editar_Integracion(OOB.Contable.Asiento.Generar.Editar ficha);
        Resultado Asiento_Anular(OOB.Contable.Asiento.Ficha ficha);
        //ASIENTO/ASIENTO
        ResultadoEntidad<OOB.Contable.Asiento.Ficha> Asiento_GetById(int id);
        ResultadoId Asiento_Guardar(OOB.Contable.Asiento.Asiento.Guardar ficha);
        //ASIENTO APERTURA
        ResultadoEntidad<bool> Asiento_Apertura_IsOk();
        ResultadoEntidad<int> Asiento_Apertura_Get_ID();
        Resultado Asiento_Apertura_Guardar(OOB.Contable.Asiento.Apertura.Insertar ficha);


        //INTEGRACION 
        ResultadoLista<OOB.Contable.Integracion.Ficha> Integracion_Lista(OOB.Contable.Integracion.Filtro filt);
        ResultadoEntidad<OOB.Contable.Integracion.Ficha> Integracion_GetBy(OOB.Contable.Integracion.Ficha Integracion, OOB.Contable.Asiento.Ficha  Asiento);
        Resultado Integracion_Anular(OOB.Contable.Integracion.Ficha ficha);

        
        //VENTA
        ResultadoEntidad<OOB.Venta.Ficha> Venta_GetById(string autoDoc);

    
        //CTxPAGAR-RECIBO 
        ResultadoEntidad<OOB.CtxPagar.Recibo.Ficha> CtxPagar_Recibo_GetById(string autoDoc);

        
        //CTxCOBRAR-RECIBO 
        ResultadoEntidad<OOB.CtxCobrar.Recibo.Ficha> CtxCobrar_Recibo_GetById(string autoDoc);

        
        //PRODUCTOS-MOVIMIENTO
        ResultadoEntidad<OOB.Productos.Movimiento.Ficha > Productos_Movimiento_GetById(string autoDoc);
   
    }

}