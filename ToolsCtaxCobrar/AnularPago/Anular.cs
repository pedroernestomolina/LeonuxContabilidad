using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ToolsCtaxCobrar.AnularPago
{

    public class Anular
    {

        public void Anula(OOB.CtxCobrar.Documentos.Pago.Ficha ficha) 
        {
            var msg = MessageBox.Show("Estas Seguro De Anular El Pago ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                var fichaAnular= new OOB.CtxCobrar.Pago.Anular.Ficha()
                {
                    IdPago=ficha.IdAuto,
                    Notas="PRUEBA",
                };
                var r01 = Globals.MyData.CtaxCobrar_Pago_Anular(fichaAnular);
                if (r01.Result== OOB.Resultado.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
            }
        }

    }

}