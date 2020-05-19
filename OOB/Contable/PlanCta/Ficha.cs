using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOB.Contable.PlanCta
{

    public class Ficha
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public Enumerados.Tipo Tipo { get; set; }
        public Enumerados.Naturaleza Naturaleza { get; set; }
        public Enumerados.EstadoSituacion Estado { get; set; }
        public Saldos SaldoActual { get; set; }

        public decimal Debe 
        {
             //get { return Math.Abs(SaldoActual.Debe); }
             get { return SaldoActual.Debe; }
        }

        public decimal Haber
        {
            //get { return Math.Abs(SaldoActual.Haber); }
            get { return SaldoActual.Haber; }
        }

        public string Cuenta 
        { 
            get 
            { 
                return Codigo + Environment.NewLine+ Nombre; 
            }
        }

        public string TipoDescripcion 
        { 
            get 
            { 
                return Tipo == Enumerados.Tipo.Auxiliar ? "Auxiliar" : "Totalizadora"; 
            }
        }

        public string NaturalezaDescripcion 
        { 
            get 
            { 
                return Naturaleza == Enumerados.Naturaleza.Deudora ? "Deudora" : "Acreedora"; 
            } 
        }

        public string EstadoSituacionDescripcion
        {
            get
            {
                return Estado == Enumerados.EstadoSituacion.Financiero ? "Situación Financiero" : "Resultado";
            }
        }

        public decimal Saldo
        {
            get 
            {
                return ((SaldoActual.Apertura + SaldoActual.Anterior) + (SaldoActual.Debe - SaldoActual.Haber));
                //if (Naturaleza== Enumerados.Naturaleza.Deudora )
                //{
                //    return ( (SaldoActual.Apertura + SaldoActual.Anterior) + (SaldoActual.Debe - SaldoActual.Haber) );
                //}
                //else
                //{
                //    return ( (SaldoActual.Apertura + SaldoActual.Anterior) + (SaldoActual.Haber - SaldoActual.Debe) );
                //}
            }
        }

        public Ficha()
        {
            Id = -1;
            Codigo = "";
            Nombre = "";
        }

        public Ficha(OOB.Cuenta.Ficha ficha)
        {
            Id = ficha.IdPlanCta ;
            Codigo = ficha.CodigoCta;
            Nombre = ficha.DescripcionCta;
            Naturaleza = ficha.NaturalezaCta;
        }

    }

}