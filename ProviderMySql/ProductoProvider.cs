using DTO;
using EntityMySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderMySql
{

    public partial class Provider : IProvider.InfraEstructura
    {

        //MOVIMIENTO
        public DTO.ResultadoEntidad<DTO.Productos.Movimiento.Ficha> Productos_Movimiento_GetById(string autoDoc)
        {
            var result = new ResultadoEntidad<DTO.Productos.Movimiento.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.productos_movimientos.Find(autoDoc);
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] MOVIMIENTO NO ENCONTRADO";
                        result.Result = DTO.EnumResult.isError;
                        result.Entidad = null;
                        return result;
                    }

                    var entDet = ctx.productos_movimientos_detalle.Where(d => d.auto_documento == autoDoc).ToList();
                    var doc = new DTO.Productos.Movimiento.Ficha()
                    {
                        DocumentoNro=ent.documento,
                        DocumentoCodigo=ent.tipo,
                        DocumentoDesc=ent.documento_nombre,
                        Fecha=ent.fecha,
                        Hora=ent.hora,
                        Usuario=ent.usuario,
                        Estacion=ent.estacion,
                        ConceptoCodigo=ent.codigo_concepto,
                        ConceptoDesc=ent.concepto,
                        DepositoCodigo=ent.codigo_deposito,
                        DepositoDesc=ent.deposito,
                        Nota=ent.nota,
                        Renglones=ent.renglones,
                        Importe=ent.total
                    };

                    if (entDet.Count() > 0)
                    {
                        var det = entDet.Select((d) =>
                        {
                            var dep_nombre = "";
                            var dep_codigo = "";
                            var dep = ctx.empresa_departamentos.Find(d.productos.auto_departamento);
                            if (dep != null) 
                            {
                                dep_nombre=dep.nombre;
                                dep_codigo=dep.codigo;
                            };

                            return new DTO.Productos.Movimiento.Detalle()
                            {
                                PrdCodigo=d.codigo,
                                PrdDescripcion=d.nombre,
                                DepartamentoCodigo=dep_codigo,
                                DepartamentoDesc=dep_nombre,
                                Cantidad=d.cantidad,
                                Empaque=d.empaque,
                                Contenido=d.contenido_empaque,
                                CantidadUnidades=d.cantidad_und,
                                CostoCompra=d.costo_compra,
                                CostoUnd=d.costo_und,
                                Importe=d.total,
                                Signo=d.signo
                            };
                        }).ToList();
                        doc.Detalles = det;
                    }

                    result.Entidad = doc;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
                result.Entidad = null;
            }

            return result;
        }


        //PRODUCTO
        public ResultadoLista<DTO.Productos.Producto.Resumen> Producto_Lista(DTO.Productos.Producto.Filtro filtro)
        {
            var result = new ResultadoLista<DTO.Productos.Producto.Resumen>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.productos.ToList();

                    if (filtro.IdProveedor!="") 
                    {
                       var idProv = filtro.IdProveedor;
                       q = ctx.productos_proveedor.Where(p => p.auto_proveedor == idProv).Select(s=>s.productos).ToList();
                    }

                    if (filtro.Cadena != "")
                    {
                        q = q.Where(p => 
                            p.codigo.Trim().ToUpper().Contains(filtro.Cadena) || 
                            p.nombre.Trim().ToUpper().Contains(filtro.Cadena) ||
                            p.modelo.Trim().ToUpper().Contains(filtro.Cadena))
                            .ToList();
                    }

                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            return new DTO.Productos.Producto.Resumen()
                            {
                                Id = d.auto ,
                                Codigo = d.codigo,
                                Descripcion = d.nombre,
                            };
                        }).ToList();
                        result.cntRegistro = list.Count();
                        result.Lista = list;
                    }
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
            }

            return result;
        }

        public ResultadoEntidad<DTO.Productos.Producto.Ficha> Producto_GetById(string Id)
        {
            var result = new ResultadoEntidad<DTO.Productos.Producto.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var ent = ctx.productos.Find(Id);
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] PRODUCTO NO ENCONTRADO";
                        result.Result = DTO.EnumResult.isError;
                        result.Entidad = null;
                        return result;
                    }

                    var r = new DTO.Productos.Producto.Ficha()
                    {
                         Id= ent.auto,
                         Codigo=ent.codigo,
                         Descripcion=ent.nombre,
                         Departamento=ent.empresa_departamentos.nombre,
                         Grupo=ent.productos_grupo.nombre ,
                         Marca=ent.productos_marca.nombre,
                         CaterogoriaAbc=ent.abc,
                         EmpaqueCompra= ent.productos_medida.nombre,
                         ContEmpaqueCompra=ent.contenido_compras ,
                         EsExento= (ent.auto_tasa=="0000000004"? true: false),
                         FechaAlta=ent.fecha_alta,
                         TasaIva=ent.tasa,
                         CostoPromedio = ent.costo_promedio,
                         UltimoCosto= ent.costo_proveedor,
                    };

                    result.Entidad = r;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
                result.Entidad = null;
            }

            return result;
        }


        //LIBRO INVENTARIO
        public ResultadoLista<DTO.Productos.LibroInventario.Ficha> Producto_LibroInventario(DTO.Productos.LibroInventario.Filtro filtro)
        {
            var result = new ResultadoLista<DTO.Productos.LibroInventario.Ficha>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.productos_kardex.Where(k=>
                        k.fecha>=filtro.Desde && 
                        k.fecha<=filtro.Hasta && 
                        k.estatus_anulado=="0").ToList();

                    if (q.Count > 0) 
                    {
                        var list = q.Select(s =>
                        {
                            var r = new DTO.Productos.LibroInventario.Ficha();
                            r.DepId = s.productos.auto_departamento;
                            r.DepNombre = s.productos.empresa_departamentos.nombre;

                            switch (s.auto_concepto)
                            {
                                case "0000000001": //VENTAS
                                    r.MontoPorSalida  = s.total;
                                    break;
                                case "0000000003": //DEV - VENTAS
                                    r.MontoPorSalida = s.total*(-1);
                                    break;
                                case "0000000002": //COMPRAS
                                    r.MontoPorEntrada = s.total;
                                    break;
                                case "0000000007": //AJUSTES
                                    if (s.codigo == "01") //CARGOS
                                    {
                                        r.MontoPorAjuste = s.total;
                                    }
                                    else if (s.codigo=="02") //DESCARGOS
                                    {
                                        r.MontoPorAjuste = s.total*(-1);
                                    }
                                    break;
                                case "0000000006": //DESCARGOS
                                    if (s.codigo == "02") //SALIDAS
                                    {
                                        r.MontoPorConsumoInterno = s.total;
                                    }
                                    break;
                                default:
                                    r = null;
                                    break;
                            }
                            return r;
                        }).ToList();

                        list=list.Where(l=> l!=null).ToList();
                        list = list.GroupBy(g => new { key = g.DepId, g.DepNombre }).
                            Select(s =>
                            {
                                return new DTO.Productos.LibroInventario.Ficha()
                                {
                                    DepNombre = s.Key.DepNombre,
                                    MontoPorEntrada = s.Sum(t => t.MontoPorEntrada),
                                    MontoPorSalida = s.Sum(t => t.MontoPorSalida),
                                    MontoPorAjuste = s.Sum(t => t.MontoPorAjuste),
                                    MontoPorConsumoInterno = s.Sum(t => t.MontoPorConsumoInterno)
                                };
                            }).ToList();

                        result.cntRegistro = list.Count();
                        result.Lista = list;
                        var sal = list.Sum(t => t.MontoPorSalida);
                        var ent = list.Sum(t => t.MontoPorEntrada);
                        var aju = list.Sum(t => t.MontoPorAjuste);
                        var con = list.Sum(t => t.MontoPorConsumoInterno);
                    }
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.EnumResult.isError;
            }

            return result;
        }

    }

}