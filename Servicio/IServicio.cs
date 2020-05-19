using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{

    public interface IServicio: IClienteServicio,ICtaxCobrarServicio, IBancoServicio, IVendedorServicio, IEmpresaServicio, 
        IVentaServicio, IReportServicio
    {

        //SERVIDOR
        ResultadoEntidad<DateTime> Servidor_Get_Fecha();
        ResultadoEntidad<string> Servidor_Get_Datos();

        //CONTADORES
        ResultadoEntidad<DTO.Contable.Contador.Ficha> Contable_Contadores_Get();

        //CONFIGURACION
        Resultado Contable_Configuracion_CuentaCierre_Editar(DTO.Contable.Configuracion.EditarCtasCierre ficha);
        ResultadoEntidad<DTO.Contable.Configuracion.CuentasCierre> Contable_Configuracion_CuentasCierre_Get();

        //PERIODO
        ResultadoEntidad<DTO.Contable.Periodo.Actual > Contable_PeriodoActual_Get();
        ResultadoLista<DTO.Contable.Periodo.CuentaTotales> Contable_Periodo_CalculoUtilidad();
        Resultado Contable_Periodo_CerrarMes(DTO.Contable.Periodo.Cerrar ficha);
        Resultado Contable_Periodo_Reversar(int IdPeriodoActual);
        ResultadoLista<DTO.Contable.Periodo.Ficha> Contable_Periodo_Lista();
        ResultadoLista<DTO.Contable.Periodo.Ficha> Contable_Utilidad_Acumulada();

        //TIPO DOCUMENTO
        ResultadoLista<DTO.Contable.TipoDocumento.Ficha> Contable_TipoDocumento_Lista();
        ResultadoId Contable_TipoDocumento_Insertar(DTO.Contable.TipoDocumento.Insertar ficha);
        Resultado Contable_TipoDocumento_Editar(DTO.Contable.TipoDocumento.Editar ficha);
        Resultado Contable_TipoDocumento_Eliminar(DTO.Contable.TipoDocumento.Eliminar ficha);
        ResultadoEntidad <DTO.Contable.TipoDocumento.Ficha> Contable_TipoDocumento_Get(int id);

        //PLAN DE CUENTA
        ResultadoEntidad<DTO.Contable.PlanCta.Ficha> Contable_PlanCta_GetById(int id);
        ResultadoLista<DTO.Contable.PlanCta.FichaResumen> Contable_PlanCta_Lista(DTO.Contable.PlanCta.Busqueda busq);
        ResultadoId Contable_PlanCta_Insertar(DTO.Contable.PlanCta.Insertar insertar);
        Resultado Contable_PlanCta_Editar(DTO.Contable.PlanCta.Editar editar);
        Resultado Contable_PlanCta_Eliminar(int id);
        ResultadoEntidad<DTO.Contable.PlanCta.Padre> Contable_PlanCta_GetPadre(string codigoCta);

        //CUENTA
        ResultadoLista<DTO.Contable.Cuenta.Movimiento> Contable_Cuenta_GetMovimiento(DTO.Contable.Cuenta.Filtro filt);
        ResultadoLista<DTO.Contable.Cuenta.Balance> Contable_Cuenta_GetBalance(DTO.Contable.Cuenta.Filtro filt);
        ResultadoEntidad<Decimal> Contable_Cuenta_GetSaldoAl(DTO.Contable.Cuenta.SaldoAl ficha);

        //ASIENTO
        ResultadoLista<DTO.Contable.Asiento.Resumen> Contable_Asiento_Lista(DTO.Contable.Asiento.Busqueda busq);
        ResultadoLista<DTO.Contable.Asiento.Generar.Ficha> Contable_Asiento_Generar(DTO.Contable.Asiento.Generar.Filtros filt);
        ResultadoId Contable_Asiento_Insertar_Integracion(DTO.Contable.Asiento.Generar.Insertar ficha);
        Resultado Contable_Asiento_EditarPreview_Integracion(DTO.Contable.Asiento.Generar.Editar ficha);
        //ASIENTO/
        ResultadoEntidad<DTO.Contable.Asiento.Ficha> Contable_Asiento_GetById(int id);
        ResultadoId Contable_Asiento_Guardar(DTO.Contable.Asiento.Insertar ficha);
        Resultado Contable_Asiento_Anular(DTO.Contable.Asiento.Anular ficha);
        //ASIENTO/APERTURA
        ResultadoEntidad<bool> Contable_Asiento_Apertura_IsOk();
        ResultadoEntidad<int> Contable_Asiento_Apertura_Get_ID();
        Resultado Contable_Asiento_Apertura_Guardar(DTO.Contable.Asiento.Apertura.Insertar ficha);

        //INTEGRACIONESS
        ResultadoLista<DTO.Contable.Integracion.Resumen> Contable_Integracion_Lista(DTO.Contable.Integracion.Filtro filt);
        ResultadoEntidad<DTO.Contable.Integracion.Ficha> Contable_Integracion_GetBy(DTO.Contable.Integracion.FiltroID filtro);
        Resultado Contable_Integracion_Anular(int id);

        //COMPRAS 
        ResultadoEntidad<DTO.Compras.Compra.Ficha> Compra_Documento_GetById(string autoDoc);
        Resultado Compra_ActualizarData (DTO.Compras.Compra.ActualizarData ficha);

        //COMPRAS -RETENCION IVA
        ResultadoEntidad<DTO.Compras.RetencionIva.Ficha> Compra_RetencionIva_GetById(string autoDoc);

        //COMPRAS -RETENCION ISLR
        ResultadoEntidad<DTO.Compras.RetencionIslr.Ficha> Compra_RetencionIslr_GetById(string autoDoc);

        //PROVEEDORES 
        ResultadoLista<DTO.Proveedores.Proveedor.Resumen> Proveedores_Proveedor_Lista(DTO.Proveedores.Proveedor.Filtro filtro);

        //CTAxPAGAR - RECIBO
        ResultadoEntidad<DTO.CtaxPagar.Recibo.Ficha> CtaxPagar_Recibo_GetById(string autoRecibo);

        //PRODUCTO - MOVIMIENTO
        ResultadoEntidad<DTO.Productos.Movimiento.Ficha> Productos_Movimiento_GetById(string autoDoc);
              
    }

}