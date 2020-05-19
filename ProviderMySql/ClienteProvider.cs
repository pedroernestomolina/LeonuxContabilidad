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

        public DTO.ResultadoLista<DTO.Clientes.Cliente.Resumen> Cliente_Lista(DTO.Clientes.Cliente.Filtro filtro)
        {
            var result = new ResultadoLista<DTO.Clientes.Cliente.Resumen>();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var q = ctx.clientes.
                        ToList();

                    if (filtro.PorEstatus !=  DTO.Clientes.Enumerados.PorEstatus.SinDefinir)
                    {
                        switch (filtro.PorEstatus)
                        {
                            case DTO.Clientes.Enumerados.PorEstatus.Activo:
                                q = q.Where(f =>f.estatus.Trim().ToUpper()=="ACTIVO").ToList();
                                break;
                            case DTO.Clientes.Enumerados.PorEstatus.Inactivo:
                                q = q.Where(f =>f.estatus.Trim().ToUpper()=="INACTIVO").ToList();
                                break;
                        }
                    }

                    if (filtro.PorSaldo != DTO.Clientes.Enumerados.PorSaldo.SinDefinir)
                    {
                        switch (filtro.PorSaldo)
                        {
                            case DTO.Clientes.Enumerados.PorSaldo.Pendiente :
                                q = q.Where(f => f.saldo>0).ToList();
                                break;
                        }
                    }

                    if (filtro.Cadena != "") 
                    {
                        q = q.Where(f => 
                            f.codigo.Trim().ToUpper().Contains(filtro.Cadena) || 
                            f.razon_social.Trim().ToUpper().Contains(filtro.Cadena) ||
                            f.ci_rif.Trim().ToUpper().Contains(filtro.Cadena) 
                            ).
                            ToList();
                    }

                    if (q.Count > 0)
                    {
                        var list = q.Select(d =>
                        {
                            
                            return new DTO.Clientes.Cliente.Resumen ()
                            {
                                IdAuto = d.auto,
                                CiRif=d.ci_rif,
                                RazonSocial=d.razon_social,
                                Codigo=d.codigo,
                                DirFiscal=d.dir_fiscal,
                                Telefono=d.telefono.Trim()+","+d.telefono2.Trim(),
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

        public ResultadoEntidad<DTO.Clientes.Cliente.Ficha> Cliente_Get_ById(string auto)
        {
            var result = new ResultadoEntidad<DTO.Clientes.Cliente.Ficha >();

            try
            {
                using (var ctx = new dBEntities(_cn.ConnectionString))
                {
                    var entCliente = ctx.clientes.Find(auto);
                    if (entCliente == null)
                    {
                        result.Mensaje = "[ ID ] CLIENTE NO ENCONTRADA";
                        result.Result = DTO.EnumResult.isError;
                        result.Entidad = null;
                        return result;
                    }

                    var r = new DTO.Clientes.Cliente.Ficha ()
                    {
                        IdAuto  =entCliente.auto,
                        IdAutoVendedor=entCliente.auto_vendedor,
                        CiRif=entCliente.ci_rif,
                        Codigo = entCliente.codigo ,
                        RazonSocial=entCliente.razon_social,
                        DirFiscal=entCliente.dir_fiscal,
                        Telefonos=entCliente.telefono+","+entCliente.telefono2+", "+entCliente.celular+","+entCliente.fax,
                        MontoPorAnticipos = entCliente.anticipos,
                        MontoPorCreditos = entCliente.creditos,
                        MontoPorDebitos = entCliente.debitos,
                        SaldoActual = entCliente.saldo,
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

    }

}