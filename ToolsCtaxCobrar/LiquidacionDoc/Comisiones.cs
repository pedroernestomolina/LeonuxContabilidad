using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToolsCtaxCobrar.LiquidacionDoc
{

    public class Comisiones
    {

        public List<Comision> Comision { get; set; }


        public Comisiones()
        {
            Comision = new List<Comision>();
        }


        public void Calculo(List<Liquida> docLq, List<MedioPago> pagos) 
        {
            Comision.Clear();
            foreach (var mp in pagos)
            {
                mp.MontoUsadoParaCalculoComision = 0.0m;
            }
            foreach (var doc in docLq)
            {
                var monto = doc.MontoRecibido;
                foreach (var mp in pagos) 
                {
                    if (mp.ImporteYaUsadoParaCalculoComision == false)
                    {
                        if (monto >= mp.Resta)
                        {
                            var c = new Comision()
                            {
                                DocLiquidar = doc,
                                SobreEsteMontoRecibido = mp.Resta,
                                Pago = mp,
                            };
                            Comision.Add(c);
                            mp.MontoUsadoParaCalculoComision += mp.Resta;
                            monto -= mp.Resta;
                        }
                        else
                        {
                            var c = new Comision()
                            {
                                DocLiquidar = doc,
                                SobreEsteMontoRecibido = monto,
                                Pago = mp,
                            };
                            Comision.Add(c);
                            mp.MontoUsadoParaCalculoComision += monto;
                            monto = 0;
                        }

                        if (monto <= 0) { break; }
                    }
                }
            }
        }

    }

}