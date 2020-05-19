using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEntity
{
    class Program
    {

        static IProvider.InfraEstructura _dp;

        static void Main(string[] args)
        {

            _dp = new ProviderMySql.Provider();
            var r01 = _dp.Inicializa();
            if (r01.Result == DTO.EnumResult.isError)
            {
                Console.WriteLine(r01.Mensaje);
                Console.ReadKey();
                Environment.Exit(0);
            }

            ////var filtros = new DTO.CtaxCobrar.Documentos.Pagos.Filtro() {};
            ////var r02 = _dp.CtaxCobrar_Documentos_Pagos(filtros);
            ////if (r02.Result == DTO.EnumResult.isError)
            ////{
            ////    Console.WriteLine(r02.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}

            ////var ficha = new DTO.CtaxCobrar.Pago.Anular() { IdPago ="0000000908", Notas="" };
            ////var r02 = _dp.CtaxCobrar_Pago_Anular(ficha);
            ////if (r02.Result == DTO.EnumResult.isError)
            ////{
            ////    Console.WriteLine(r02.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}

            ////var filtros = new DTO.Reportes.CtaxCobrar.Documentos.Filtro() { IdCliente="0000000003" };
            ////var r02 = _dp.Reporte_CtaxCobrar_Documentos_Pendientes(filtros);
            ////if (r02.Result == DTO.EnumResult.isError)
            ////{
            ////    Console.WriteLine(r02.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}

            ////var r02 = _dp.Cliente_Get_ById ("0000000347");
            ////if (r02.Result == DTO.EnumResult.isError)
            ////{
            ////    Console.WriteLine(r02.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}

            ////var filtro = new DTO.Clientes.Cliente.Filtro()
            ////{
            ////    Cadena="17613609",
            ////};
            ////var r02 = _dp.Cliente_Lista(filtro);
            ////if (r02.Result == DTO.EnumResult.isError)
            ////{
            ////    Console.WriteLine(r02.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}

            ////var filtro = new DTO.CtaxCobrar.Documentos.Pendientes.Filtro()
            ////{
            ////    IdCliente = "0000000347",
            ////    PorVencimiento = DTO.CtaxCobrar.Enumerados.PorVencimiento.Todos,
            ////    PorTipoDocumento= DTO.CtaxCobrar.Enumerados.PorTipoDocumento.SinDefinir,
            ////};
            ////var r02 = _dp.CtaxCobrar_Documentos_Pendientes(filtro);
            ////if (r02.Result == DTO.EnumResult.isError)
            ////{
            ////    Console.WriteLine(r02.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}


            //// BANCOS Y MOVIMIENTOS CONCEPTOS 
            ////var r02 = _dp.InsertarContableBancos();
            ////if (r02.Result == DTO.EnumResult.isError)
            ////{
            ////    Console.WriteLine(r02.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}

            ////var r03 = _dp.InsertarContableBancoConceptos();
            ////if (r03.Result == DTO.EnumResult.isError)
            ////{
            ////    Console.WriteLine(r03.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}

            /////////////////////////////



            ////var r02 = _dp.Bancos_Movimiento_GetById("0000002149");
            ////if (r02.Result == DTO.EnumResult.isError)
            ////{
            ////    Console.WriteLine(r02.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}

            ////var r02 = _dp.Contable_Cuenta_GetSaldoAl(529, new DateTime(2019,03,31));
            ////if (r02.Result == DTO.EnumResult.isError)
            ////{
            ////    Console.WriteLine(r02.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}

            ////var filtro = new DTO.Productos.LibroInventario.Filtro() 
            ////{
            ////    Desde= new DateTime(2019,04,01),
            ////    Hasta= new DateTime(2019,04,30),
            ////    IdDepartamento="0000000004",
            ////};
            ////var r02 = _dp.Producto_LibroInventario(filtro);
            ////if (r02.Result == DTO.EnumResult.isError)
            ////{
            ////    Console.WriteLine(r02.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}


            ////var filtro = new DTO.Productos.Producto.Filtro(){ IdProveedor="0000000104"};
            ////var r02 = _dp.Producto_Lista(filtro);
            ////if (r02.Result == DTO.EnumResult.isError)
            ////{
            ////    Console.WriteLine(r02.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}

            ////var r03 = _dp.Producto_GetById("0000000010");
            ////if (r03.Result == DTO.EnumResult.isError)
            ////{
            ////    Console.WriteLine(r03.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}
            
            //////// REVERSO DEL MES 
            ////var idPeriodoActual=5;
            ////var r02 = _dp.Contable_Perido_Reversar(idPeriodoActual);
            ////if (r02.Result == DTO.EnumResult.isError)
            ////{
            ////    Console.WriteLine(r02.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}


            ////// CIERRE DEL MES
            ////var r02 = _dp.Contable_Perido_Utilidad();
            ////if (r02.Result == DTO.EnumResult.isError)
            ////{
            ////    Console.WriteLine(r02.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}

            ////var utilidad = 0.0m;
            ////var ingresos =0.0m;
            ////var costos=0.0m;
            ////var gastos=0.0m;
            ////var otrosIngresos=0.0m;
            ////var otros=0.0m;

            ////foreach (var it in r02.Lista)
            ////{
            ////    var saldo = Math.Abs(it.Debe + it.Haber);
            ////    switch (it.Codigo)
            ////    {
            ////        case "4":
            ////            ingresos = saldo ;
            ////            break;
            ////        case "5":
            ////            costos = saldo ;
            ////            break;
            ////        case "6":
            ////            gastos = saldo ;
            ////            break;
            ////        case "7":
            ////            otrosIngresos = saldo ;
            ////            break;
            ////        case "8":
            ////            otros = saldo ;
            ////            break;
            ////    }
            ////}
            ////utilidad = ingresos - (costos + gastos + otrosIngresos + otros);


            ////var ficha = new DTO.Contable.Periodo.Cerrar()
            ////{
            ////    IdPeriodoActual = 1,
            ////    MesActual = 3,
            ////    AnoActual = 2019,
            ////    UtilidadPeriodo = utilidad,
            ////    IdCtaCierre = 600,
            ////};
            ////var r03 = _dp.Contable_Perido_Cerrar(ficha);
            ////if (r03.Result == DTO.EnumResult.isError)
            ////{
            ////    Console.WriteLine(r02.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}

            ////// FIN CIERRE DEL MES


            ////var filt = new DTO.Reportes.Balances.General .Filtro() { };
            ////var r02 = _dp.Reporte_Balance_General(filt);
            ////if (r02.Result == DTO.EnumResult.isError)
            ////{
            ////    Console.WriteLine(r02.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}

            ////var filt = new DTO.Reportes.Balances.GananciaPerdida.Filtro() { };
            ////var r02 = _dp.Reporte_Balance_GananciaPerdida(filt);
            ////if (r02.Result == DTO.EnumResult.isError)
            ////{
            ////    Console.WriteLine(r02.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}

            ////var filt = new DTO.Reportes.Balances.Comprobacion.Filtro() { Desde = new DateTime(2019, 04, 01), Hasta = new DateTime(2019, 04, 30) };
            ////var r02 = _dp.Reporte_Balance_Comprobacion(filt);
            ////if (r02.Result == DTO.EnumResult.isError)
            ////{
            ////    Console.WriteLine(r02.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}


            //////ASIGNAR PADRE Y NIVEL AL PLAN DE CTA
            ////var busq = new DTO.Contable.PlanCta.Busqueda();
            ////var r02 = _dp.Contable_PlanCta_Lista(busq);
            ////if (r02.Result == DTO.EnumResult.isError) 
            ////{
            ////    Console.WriteLine(r02.Mensaje);
            ////    Console.ReadKey();
            ////    Environment.Exit(0);
            ////}

            ////foreach (var cta in r02.Lista) 
            ////{
            ////    var r001 = _dp.Contable_PlanCta_GetPadre(cta.Codigo);
            ////    if (r001.Result== DTO.EnumResult.isError)
            ////    {
            ////        return ;
            ////    }

            ////    var idPadre=r001.Entidad.Id ;
            ////    var nivel=r001.Entidad.Nivel  ;

            ////    var r002 = _dp.Contable_PlanCta_AsignarCtaPadre(cta.Id, idPadre, nivel);
            ////    if (r002.Result == DTO.EnumResult.isError)
            ////    {
            ////        return;
            ////    }
            ////}
            //////ASIGNAR PADRE Y NIVEL AL PLAN DE CTA

            //var r02 = _dp.RestarInventario() ;
            //if (r02.Result == DTO.EnumResult.isError)
            //{
            //    Console.WriteLine(r02.Mensaje);
            //    Console.ReadKey();
            //    Environment.Exit(0);
            //}

            //var r02 = _dp.AsignarProductoDeposito("0000000009");
            //if (r02.Result == DTO.EnumResult.isError)
            //{
            //    Console.WriteLine(r02.Mensaje);
            //    Console.ReadKey();
            //    Environment.Exit(0);
            //}


            Console.WriteLine("ok");
            //Console.WriteLine(r02.Entidad);
            Console.ReadKey();
        }
    }
}