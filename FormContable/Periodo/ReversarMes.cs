using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormContable.Periodo
{
    public partial class ReversarMes : Form
    {

        public event EventHandler RevesarOk;
        private OOB.Contable.Periodo.Ficha _periodo;

        public ReversarMes(OOB.Contable.Periodo.Ficha periodo)
        {
            InitializeComponent();
            _periodo = periodo;
        }

        private void ReversarMes_Load(object sender, EventArgs e)
        {
        }

        public void Reversar()
        {
            var msg = MessageBox.Show("Udted Esta Inentando Reversar Al Mes Anterior, Verificó Que No Existan Movimientos En El Periodo Actual ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                msg = MessageBox.Show("Reversar Al Mes Anterior ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == System.Windows.Forms.DialogResult.Yes)
                {
                    var r01 = Globals.MyData.Periodo_Reversar(_periodo);
                    if (r01.Result == OOB.Resultado.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        Close();
                    }

                    EventHandler handler = RevesarOk;
                    if (handler != null)
                    {
                        handler(this, null);
                    }

                    Helpers.Msg.Alerta("PROCESO REALIZADO EXITOSAMENTE ..... !!!!");
                    Close();
                }
                else
                {
                    button1.Enabled = true;
                }
            }
            else 
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Reversar();
        }

    }
}