using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Contable.Asiento
{

    public class Ficha
    {

        public int Id { get; set; }
        public int Renglones { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Comprobante { get; set; }
        public string Detalle { get; set; }
        public bool EstaAnulado { get; set; }
        public bool EstaProcesado { get; set; }
        public bool AutoGenerado { get; set; }
        public Enumerados.Tipo TipoAsiento { get; set; }
        public decimal Importe { get; set; }
        public Integracion.Regla.Ficha ReglaIntegracion { get; set; }
        public Periodo.Ficha Periodo { get; set; }
        public TipoDocumento.Ficha TipoDocumento { get; set; }
        public List<FichaDocumento> Documentos { get; set; }
        public List<FichaResumen> Resumen { get; set; }


        public string MesAnoRelacion 
        {
            get
            {
                return Periodo.Mes + "/" + Periodo.Ano;
            }
        }

        public string ReglaAplica 
        {
            get
            {
                var x = ReglaIntegracion.Descripcion.Trim();
                if (string.IsNullOrEmpty(x)){ x="MANUAL";}
                return x ;
            }
        }
        
        public string TipoDocumentoDescripcion 
        {
            get 
            {
                return TipoDocumento.Descripcion;
            }
        }

        public string TipoAsientoDesc
        {
            get
            {
                string desc = "";
                switch (TipoAsiento)
                {
                    case Enumerados.Tipo.Apertura:
                        desc = "APERTURA";
                        break;
                    case Enumerados.Tipo.Operativo:
                        desc = "OPERATIVO";
                        break;
                    case Enumerados.Tipo.Ajuste:
                        desc = "DE AJUSTE";
                        break;
                    case Enumerados.Tipo.Cierre:
                        desc = "DE CIERRE";
                        break;
                }
                return desc;
            }
        }

    }

}