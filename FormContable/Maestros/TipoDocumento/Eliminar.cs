using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormContable.Maestros.TipoDocumento
{

    public class Eliminar
    {

        public bool Elimina(OOB.Contable.TipoDocumento.Ficha ficha)
        {
            var result = false;
            var msg = MessageBox.Show("Elimnar Item ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                var elimiarDoc = new OOB.Contable.TipoDocumento.Eliminar() { Item = ficha };
                var r01= Globals.MyData.TipoDocumento_Eliminar(elimiarDoc);
                if (r01.Result == OOB.Resultado.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return false;
                }
                result = true;
            }
            return result;
        }

    }

}