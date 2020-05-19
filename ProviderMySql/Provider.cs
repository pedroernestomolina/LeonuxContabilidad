using DTO;
using EntityMySQL;
using IProvider;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;


namespace ProviderMySql
{

    public partial class Provider : InfraEstructura
    {

        EntityConnectionStringBuilder _cn;
        string _Instancia;
        string _BaseDatos;
        string _Usuario;
        string _Password;


        public Provider()
        {
            //Inicializa();
        }

        public Resultado Inicializa()
        {
            var result = new Resultado();

            var r1 = CargarXml();
            if (r1.Result == EnumResult.isError)
            {
                return r1;
            }

            _Usuario = "root";
            _Password = "123";
            _cn = new EntityConnectionStringBuilder();
            _cn.Metadata = "res://*/dBModel.csdl|res://*/dBModel.ssdl|res://*/dBModel.msl";
            _cn.Provider = "MySql.Data.MySqlClient";
            _cn.ProviderConnectionString = "data source=" + _Instancia + ";initial catalog=" + _BaseDatos + ";user id=" + _Usuario + ";Password=" + _Password + ";Convert Zero Datetime=True;";

            return result;
        }


        private Resultado CargarXml()
        {
            var result = new Resultado();

            try
            {
                var doc = new XmlDocument();
                doc.Load(AppDomain.CurrentDomain.BaseDirectory + @"\Conf.XML");

                if (doc.HasChildNodes)
                {
                    foreach (XmlNode nd in doc)
                    {
                        if (nd.LocalName.ToUpper().Trim() == "CONFIGURACION")
                        {
                            foreach (XmlNode nv in nd.ChildNodes)
                            {
                                if (nv.LocalName.ToUpper().Trim() == "SERVIDOR")
                                {
                                    foreach (XmlNode sv in nv.ChildNodes)
                                    {
                                        if (sv.LocalName.Trim().ToUpper() == "INSTANCIA")
                                        {
                                            _Instancia = sv.InnerText.Trim();
                                        }
                                        if (sv.LocalName.Trim().ToUpper() == "CATALOGO")
                                        {
                                            _BaseDatos = sv.InnerText.Trim();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Result = EnumResult.isError;
                result.Mensaje = e.Message;
            }

            return result;
        }


        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>

        public Resultado InsertarReglas()
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {

                        //var entLista = ctx.bancos_movimientos_conceptos.Where(m => m.clase.Trim().ToUpper() == "EGRESO" &&
                        //    m.idPlanCtaPago.Value != null).
                        //    GroupBy(g=> new {idplanCta=g.idPlanCtaPago}).
                        //    ToList();

                        //foreach (var conc in entLista)
                        //{
                        //    var ent = new contabilidad_reglas_integracion_detalle()
                        //    {
                        //        idReglaIntegracion = 2,
                        //        idPlanCta = conc.Key.idplanCta.Value,
                        //        signo = -1,
                        //        referencia = "MONTO POR PAGAR",
                        //    };
                        //    ctx.contabilidad_reglas_integracion_detalle.Add(ent);
                        //    ctx.SaveChanges();
                        //}

                        //var entLista = ctx.bancos_movimientos_conceptos.Where(m => m.clase.Trim().ToUpper() == "EGRESO" &&
                        //   m.idPlanCta.Value != null).
                        //   GroupBy(g => new { idplanCta = g.idPlanCta }).
                        //   ToList();

                        //foreach (var conc in entLista)
                        //{
                        //    var ent = new contabilidad_reglas_integracion_detalle()
                        //    {
                        //        idReglaIntegracion = 2,
                        //        idPlanCta = conc.Key.idplanCta.Value,
                        //        signo = 1,
                        //        referencia = "GASTO",
                        //    };
                        //    ctx.contabilidad_reglas_integracion_detalle.Add(ent);
                        //    ctx.SaveChanges();
                        //}

                        //var entLista = ctx.bancos_movimientos_conceptos.Where(m => m.clase.Trim().ToUpper() == "EGRESO" &&
                        //    m.idPlanCta.Value != null).
                        //    GroupBy(g => new { idplanCta = g.idPlanCta }).
                        //    ToList();

                        //foreach (var conc in entLista)
                        //{
                        //    var ent = new contabilidad_reglas_integracion_detalle()
                        //    {
                        //        idReglaIntegracion = 3,
                        //        idPlanCta = conc.Key.idplanCta.Value,
                        //        signo = -1,
                        //        referencia = "MONTO PAGADO",
                        //    };
                        //    ctx.contabilidad_reglas_integracion_detalle.Add(ent);
                        //    ctx.SaveChanges();
                        //}

                        ts.Complete();
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

        public Resultado InsertarContableBancos()
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {

                        var entLista = ctx.bancos.ToList();
                        foreach (var cp in entLista)
                        {
                            var r = 0;
                            var ent = new contabilidad_banco
                            {
                                idPlanCta = -1,
                                auto_banco = cp.auto
                            };

                            if (cp.idPlanCta.HasValue) { ent.idPlanCta = cp.idPlanCta.Value; r = 1; }

                            if (r == 1)
                            {
                                ctx.contabilidad_banco.Add(ent);
                                ctx.SaveChanges();
                            }
                        }

                        ts.Complete();
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

        public Resultado InsertarContableBancoConceptos()
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {

                        var entLista = ctx.bancos_movimientos_conceptos.ToList();
                        foreach (var cp in entLista)
                        {
                            var r = 0;
                            var ent = new contabilidad_banco_conceptos
                            {
                                idCtaPasivo = -1,
                                idCtaGasto = -1,
                                idCtaBanco = -1,
                                autoMovimientoConcepto = cp.auto
                            };

                            if (cp.idPlanCta.HasValue) { ent.idCtaGasto  = cp.idPlanCta.Value; r = 1; }
                            if (cp.idPlanCtaPago.HasValue) { ent.idCtaPasivo  = cp.idPlanCtaPago.Value; r = 1; }

                            if (r == 1)
                            {
                                ctx.contabilidad_banco_conceptos.Add(ent);
                                ctx.SaveChanges();
                            }
                        }

                        ts.Complete();
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

        public Resultado RestarInventario()
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = new TransactionScope())
                    {
                        var list = ctx.productos_kardex_resumen.Where(d => d.auto_producto == "0000000008").ToList();
                        foreach (var it in list)
                        {
                            var prdDep = ctx.productos_deposito.FirstOrDefault(d => d.auto_producto == it.auto_producto && d.auto_deposito == "0000000001");
                            if (prdDep != null)
                            {
                                var fisica = prdDep.fisica;
                                var dispon = prdDep.disponible;

                                prdDep.fisica -= it.cnt;
                                prdDep.disponible -= it.cnt;
                            }
                            ctx.SaveChanges();
                        }

                        ts.Complete();
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

        public Resultado AsignarProductoDeposito(string idDeposito)
        {
            var result = new Resultado();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    using (var ts = ctx.Database.BeginTransaction())
                    {
                        var list = ctx.productos_deposito.Where(pd=>pd.auto_deposito!=idDeposito).Select(s=>s.productos).Distinct().ToList();
                        var xit = 0;
                        var listPrdDep=new List<productos_deposito>();

                        foreach (var it in list)
                        {
                            var prdDep = new productos_deposito()
                            {
                                auto_producto = it.auto,
                                auto_deposito = idDeposito,
                                fisica = 0.0m,
                                reservada = 0.0m,
                                disponible = 0.0m,
                                ubicacion_1 = "",
                                ubicacion_2 = "",
                                ubicacion_3 = "",
                                ubicacion_4 = "",
                                nivel_minimo = 0.0m,
                                nivel_optimo = 0.0m,
                                pto_pedido = 0.0m
                            };
                            xit += 1;
                            listPrdDep.Add(prdDep);
                        }

                        ctx.productos_deposito.AddRange(listPrdDep);
                        ctx.SaveChanges();
                        ts.Commit();
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