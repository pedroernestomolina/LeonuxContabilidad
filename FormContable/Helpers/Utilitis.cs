using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormContable.Helpers
{

    public class Utilitis
    {

        static public void Calculadora()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = @"calc.exe";
            p.Start();
            //p.WaitForExit();
        }

        static public void ImprimirComprobante(int IdAsiento)
        {
            var r01 = Globals.MyData.Reportes_Balance_ComprobanteDiario(IdAsiento);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var r04 = Globals.MyData.Empresa_DatosNegocio();
            if (r04.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return;
            }

            Globals.MyReports.Balance_ComprobanteDiario(r01.Entidad, r04.Entidad);
        }

    }

}
