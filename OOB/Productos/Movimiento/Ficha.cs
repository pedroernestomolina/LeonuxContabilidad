using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOB.Productos.Movimiento
{

    public class Ficha
    {
        public string DocumentoNro { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Nota { get; set; }
        public string Usuario { get; set; }
        public string Estacion { get; set; }
        public string ConceptoCodigo { get; set; }
        public string ConceptoDesc { get; set; }
        public string DepositoCodigo { get; set; }
        public string DepositoDesc { get; set; }
        public string DocumentoCodigo { get; set; }
        public string DocumentoDesc { get; set; }
        public int Renglones { get; set; }
        public decimal Importe { get; set; }
        public List<Detalle> Detalles { get; set; }

        public string FechaHora
        {
            get
            {
                return Fecha.ToShortDateString()+ Environment.NewLine + Hora.Trim();
            }
        }

        public string UsuarioEstacion
        {
            get
            {
                return Usuario.Trim() + Environment.NewLine + Estacion.Trim();
            }
        }

        public string Concepto 
        {
            get
            {
                return ConceptoCodigo.Trim() + Environment.NewLine + ConceptoDesc.Trim();
            } 
        }

        public string Deposito
        {
            get
            {
                return DepositoCodigo.Trim() + Environment.NewLine + DepositoDesc.Trim();
            }
        }

        public string Documento
        {
            get
            {
                return DocumentoNro+ Environment.NewLine+ DocumentoDesc.Trim()+ " ( " + DocumentoCodigo.Trim()+ " ) ";
            }
        }


    }

}
