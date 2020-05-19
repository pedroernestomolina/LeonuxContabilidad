using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormContable.PlanCta
{
    public class Eliminar
    {

        public bool Elimina(OOB.Contable.PlanCta.Ficha ficha) 
        {
            var msg = MessageBox.Show("Elimnar Cuenta Contable ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                var result = Globals.MyData.PlanCta_Eliminar(ficha);
                if (result.Result == OOB.Resultado.EnumResult.isError)
                {
                    Helpers.Msg.Error(result.Mensaje);
                    return false;
                }
                return true;
            }
            else 
            {
                return false;
            }
        }

    }
}