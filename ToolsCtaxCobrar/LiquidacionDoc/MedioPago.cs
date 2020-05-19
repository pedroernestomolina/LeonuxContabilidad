using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.LiquidacionDoc
{

    public class MedioPago
    {

        public int ClaveId { get; set; }
        public decimal Importe { get; set; }
        public decimal Saldo { get; set; }
        public string Referencia { get; set; }
        public DateTime Fecha { get; set; }
        public OOB.Empresa.MediosPago.Ficha Medio { get; set; }
        public OOB.Bancos.Banco.Ficha Banco { get; set; }

       
        private decimal _montoUsado;
        public decimal MontoUsadoParaCalculoComision 
        { 
            get {return _montoUsado;}
            set { _montoUsado = value; }
        }

        public decimal Resta 
        {
            get 
            {
                if (Saldo > 0)
                {
                    if (Importe > Saldo)
                    {
                        return (Saldo - _montoUsado);
                    }
                    else
                    {
                        return (Importe - _montoUsado);
                    }
                }
                else 
                {
                    return 0;
                }
            }
        }

        public bool ImporteYaUsadoParaCalculoComision
        {
            get 
            {
                return _montoUsado >= Importe;
            }
        }

        public string MedioDesc
        {
            get
            {
                if (Medio != null)
                {
                    return Medio.Nombre;
                }
                else
                {
                    return "";
                }
            }
        }

        public string BancoDesc
        {
            get
            {
                if (Banco != null)
                {
                    return Banco.Numero;
                }
                else
                {
                    return "";
                }
            }
        }


    }

}
