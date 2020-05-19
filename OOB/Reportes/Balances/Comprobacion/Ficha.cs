using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.Reportes.Balances.Comprobacion
{

    public class Ficha
    {

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Nivel { get; set; }
        public OOB.Contable.PlanCta.Enumerados.Naturaleza Naturaleza { get; set; }
        public decimal SaldoApertura {get;set;}
        public decimal Debe {get;set;}
        public decimal Haber {get;set;}
        public bool IsTotal { get; set; }
        public decimal DebeAcumulado { get; set; }
        public decimal HaberAcumulado { get; set; }

        public decimal DebeAcum 
        {
            get { return DebeAcumulado + Debe; }
        }

        public decimal HaberAcum
        {
            get { return HaberAcumulado + Haber; }
        }

        public decimal SaldoMes
        { 
            get 
            {
                var saldo = 0.0m;
                saldo = Debe - Haber;
                //if (Naturaleza == Contable.PlanCta.Enumerados.Naturaleza.Deudora)
                //{
                //    saldo = Debe - Haber;
                //}
                //else 
                //{
                //    saldo = Haber - Debe;
                //}
                //
                return saldo;
            } 
        }
        public decimal SaldoFinal 
        {
            get 
            {
                var saldo = 0.0m;
                saldo = SaldoApertura + SaldoMes;
                return saldo ;
            }
        }

    }

}