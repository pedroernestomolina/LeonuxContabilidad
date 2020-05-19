using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IProvider
{
    
    public interface InfraEstructura: IProducto, IProveedores, IReportes, ICtaxCobrar, ICliente, IVendedor, IEmpresa, IVenta
    {

        Resultado Inicializa();
        Resultado InsertarReglas();
        Resultado InsertarContableBancos();
        Resultado InsertarContableBancoConceptos();
        Resultado RestarInventario();
        Resultado AsignarProductoDeposito(string idDeposito);


        //SERVIDOR
        ResultadoEntidad<DateTime> FechaDelServidor();
        ResultadoEntidad<string> DatosDelServidor();

        //CONTADORES
        ResultadoEntidad<DTO.Contable.Contador.Ficha> Contable_Contadores_Get();

        //CONFIGURACION
        ResultadoEntidad<DTO.Contable.Configuracion.CuentasCierre> Contable_Configuracion_CuentasCierre_Get();
        Resultado Contable_Configuracion_CuentaCierre_Editar(DTO.Contable.Configuracion.EditarCtasCierre ficha);

        //PERIODO
        ResultadoEntidad<DTO.Contable.Periodo.Actual> Contable_PeridoActual_Get();
        ResultadoLista<DTO.Contable.Periodo.CuentaTotales> Contable_Perido_Utilidad();
        Resultado Contable_Perido_Cerrar(DTO.Contable.Periodo.Cerrar ficha);
        Resultado Contable_Perido_Reversar(int IdPeriodoActual);
        Resultado Contable_Periodo_VerificaSiHayMovimientos(int idPeriodo);
        ResultadoLista<DTO.Contable.Periodo.Ficha> Contable_Periodo_Lista();
        ResultadoLista<DTO.Contable.Periodo.Ficha> Contable_Utilidad_Acumulada();

        //TIPO DOCUMENTO
        ResultadoLista<DTO.Contable.TipoDocumento.Ficha> Contable_TipoDocumento_Lista();
        ResultadoId Contable_TipoDocumento_Insertar(DTO.Contable.TipoDocumento.Insertar ficha);
        Resultado Contable_TipoDocumento_Editar(DTO.Contable.TipoDocumento.Editar ficha);
        Resultado Contable_TipoDocumento_Eliminar(DTO.Contable.TipoDocumento.Eliminar ficha);
        ResultadoEntidad<DTO.Contable.TipoDocumento.Ficha> Contable_TipoDocumento_Get(int id);
        Resultado Contable_TipoDocumento_VerificarEliminar(int id);

        //PLAN CUENTA
        ResultadoLista<DTO.Contable.PlanCta.FichaResumen> Contable_PlanCta_Lista(DTO.Contable.PlanCta.Busqueda busq);
        ResultadoId Contable_PlanCta_Insertar(DTO.Contable.PlanCta.Insertar  insertar);
        Resultado Contable_PlanCta_Editar(DTO.Contable.PlanCta.Editar editar);
        Resultado Contable_PlanCta_Eliminar(int id);
        ResultadoEntidad<DTO.Contable.PlanCta.Ficha> Contable_PlanCta_GetById(int id );
        ResultadoEntidad<DTO.Contable.PlanCta.Padre> Contable_PlanCta_GetPadre(string codigoCta);
        Resultado Contable_PlanCta_VerificarInsertar(string codigoCta);
        Resultado Contable_PlanCta_VerificarEliminar(int id);
        Resultado Contable_PlanCta_AsignarCtaPadre(int idCta, int idPadre, int nivel);

        //CUENTA CONTABLE 
        ResultadoLista<DTO.Contable.Cuenta.Movimiento> Contable_Cuenta_GetMovimiento(DTO.Contable.Cuenta.Filtro filt);
        ResultadoLista<DTO.Contable.Cuenta.Balance> Contable_Cuenta_GetBalance(DTO.Contable.Cuenta.Filtro filt);
        ResultadoEntidad<decimal> Contable_Cuenta_GetSaldoAl(int id, DateTime fecha);

        //ASIENTO/INTEGRACION
        ResultadoLista<DTO.Contable.Asiento.Resumen> Contable_Asiento_Lista(DTO.Contable.Asiento.Busqueda busq);
        ResultadoLista<DTO.Contable.Asiento.Generar.Ficha> Contable_Asiento_Venta_Generar(DTO.Contable.Asiento.Generar.Filtros ficha);
        ResultadoLista<DTO.Contable.Asiento.Generar.Ficha> Contable_Asiento_Compra_Generar(DTO.Contable.Asiento.Generar.Filtros ficha);
        ResultadoLista<DTO.Contable.Asiento.Generar.Ficha> Contable_Asiento_CtasPorPagar_Generar(DTO.Contable.Asiento.Generar.Filtros ficha);
        ResultadoLista<DTO.Contable.Asiento.Generar.Ficha> Contable_Asiento_CtasPorCobrar_Generar(DTO.Contable.Asiento.Generar.Filtros ficha);
        ResultadoLista<DTO.Contable.Asiento.Generar.Ficha> Contable_Asiento_Inventario_Generar(DTO.Contable.Asiento.Generar.Filtros ficha);
        ResultadoLista<DTO.Contable.Asiento.Generar.Ficha> Contable_Asiento_Banco_Generar(DTO.Contable.Asiento.Generar.Filtros ficha);
        ResultadoId Contable_Asiento_Insertar_Integracion(DTO.Contable.Asiento.Generar.Insertar ficha);
        Resultado Contable_Asiento_Insertar_Integracion_Verificar(DTO.Contable.Asiento.Generar.Insertar ficha);

        Resultado Contable_Asiento_EditarPreview_Integracion(DTO.Contable.Asiento.Generar.Editar ficha);
        //ASIENTO/ASIENTO
        ResultadoId Contable_Asiento_Insertar(DTO.Contable.Asiento.Insertar ficha);
        ResultadoId Contable_Asiento_Editar(DTO.Contable.Asiento.Insertar ficha);
        ResultadoId Contable_Asiento_Preview(DTO.Contable.Asiento.Insertar ficha);
        ResultadoEntidad<DTO.Contable.Asiento.Ficha> Contable_Asiento_GetById(int id);
        Resultado Contable_Asiento_Anular(int idAsiento);
        Resultado Contable_Asiento_Anular_Preview(int idAsiento);
        Resultado Contable_Asiento_Anular_Apertura(int idAsiento);
        //ASIENTO/APERTURA
        ResultadoEntidad<bool> Contable_Asiento_Apertura_IsOk();
        ResultadoEntidad<int> Contable_Asiento_Apertura_Get_ID();
        Resultado Contable_Asiento_Apertura_Insertar(DTO.Contable.Asiento.Apertura.Insertar ficha);
        Resultado Contable_Asiento_Apertura_Preview(DTO.Contable.Asiento.Apertura.Insertar ficha);
        //ASIENTO/VERIFICAR
        Resultado Contable_Asiento_VerificarAnular(int idAsiento);
        Resultado Contable_Asiento_VerificarEditar(int idAsiento);
        
        //INTEGRACIONES 
        ResultadoLista<DTO.Contable.Integracion.Resumen> Contable_Integracion_Lista(DTO.Contable.Integracion.Filtro filt);
        ResultadoEntidad<DTO.Contable.Integracion.Ficha> Contable_Integracion_GetById(int id);
        ResultadoEntidad<DTO.Contable.Integracion.Ficha> Contable_Integracion_GetByIdAsiento(int idAsiento);
        Resultado Contable_Integracion_Anular(int id);
        Resultado Contable_Integracion_VerificarAnular(int id);
              
        //COMPRA
        ResultadoEntidad<DTO.Compras.Compra.Ficha> Compras_Compra_GetById(string autoDoc);
        Resultado Compras_Compra_ActualizarData (DTO.Compras.Compra.ActualizarData ficha);

        //COMPRA/RETENCION IVA
        ResultadoEntidad<DTO.Compras.RetencionIva.Ficha> Compras_RetencionIva_GetById(string autoDoc);

        //COMPRA/RETENCION ISLR
        ResultadoEntidad<DTO.Compras.RetencionIslr.Ficha> Compras_RetencionIslr_GetById(string autoDoc);

        //CTAxPAGAR/RECIBO
        ResultadoEntidad<DTO.CtaxPagar.Recibo.Ficha> CtaxPagar_Recibo_GetById(string autoDoc);

        //BANCO 
        ResultadoLista<DTO.Bancos.Banco.Resumen> Bancos_Banco_Lista();
        ResultadoLista<DTO.Bancos.Banco.Resumen> Bancos_Banco_Lista_Resumen();
        ResultadoEntidad<DTO.Bancos.Banco.Ficha> Bancos_Banco_GetById(string autoBanco);
        Resultado Bancos_Banco_Actualizar(DTO.Bancos.Banco.Actualizar ficha);
        Resultado Bancos_Banco_VerificaActualizar(DTO.Bancos.Banco.Actualizar ficha);

        //BANCO/MOVIMIENTO
        ResultadoEntidad<DTO.Bancos.Movimiento.Ficha> Bancos_Movimiento_GetById(string autoMov);

        //PRODUCTOS/MOVIMIENTO
        ResultadoEntidad<DTO.Productos.Movimiento.Ficha> Productos_Movimiento_GetById(string autoDoc);

        //BANCOS MOVIMIENTO CONCEPTOS
        ResultadoLista<DTO.Bancos.Conceptos.Resumen> Banco_Concepto_Lista(DTO.Bancos.Conceptos.Filtro filtros);
        ResultadoEntidad<DTO.Bancos.Conceptos.Ficha> Banco_Concepto_GetById(string autoConcepto);
        Resultado Banco_Concepto_Actualizar(DTO.Bancos.Conceptos.Actualizar ficha);

    }

}