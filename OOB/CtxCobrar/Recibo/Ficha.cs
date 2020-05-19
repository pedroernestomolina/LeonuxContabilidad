using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.CtxCobrar.Recibo
{
    
    public class Ficha
    {

        public DateTime FechaEmision { get; set; }
        public string Hora { get; set; }
        public string DocumentoNro { get; set; }
        public string ClienteCodigo { get; set; }
        public string ClienteNombreRazonSocial { get; set; }
        public string ClienteCiRif { get; set; }
        public string ClienteDireccionFiscal { get; set; }
        public string ClienteTelefono { get; set; }
        public string CobradorNombre { get; set; }
        public string CobradorCodigo { get; set; }
        public string Usuario { get; set; }
        public string Estacion { get; set; }
        public decimal Importe { get; set; }
        public string Notas { get; set; }
        public List<Documento> Documentos { get; set; }
        public Pago FormaPago { get; set; }

        public string Cliente
        {
            get
            {
                return ClienteCiRif + Environment.NewLine + ClienteNombreRazonSocial.Trim() + Environment.NewLine + ClienteDireccionFiscal;
            }
        }

        public string Cobrador
        {
            get
            {
                return CobradorCodigo + Environment.NewLine + CobradorNombre ;
            }
        }

        public string UsuarioEstacion
        {
            get
            {
                return Usuario+ Environment.NewLine + Estacion;
            }
        }

    }

}