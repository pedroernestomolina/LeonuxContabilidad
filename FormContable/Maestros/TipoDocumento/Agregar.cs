using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormContable.Maestros.TipoDocumento
{
    public partial class Agregar : Form
    {

        public event EventHandler<int> AgregarOK = null;

        public Agregar()
        {
            InitializeComponent();
        }

        private void Agregar_Load(object sender, EventArgs e)
        {
            TB_DESCRIPCION.Select();
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            if (TB_DESCRIPCION.Text.Trim() == "") { return; }
            //var msg = MessageBox.Show("Agregar Ficha ?","*** Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            var msg = System.Windows.Forms.DialogResult.Yes;
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                var FichaAgregar = new OOB.Contable.TipoDocumento.Insertar() { Descripcion = TB_DESCRIPCION.Text.Trim() };
                var r01 = Globals.MyData.TipoDocumento_Insertar(FichaAgregar);
                if (r01.Result == OOB.Resultado.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                Handler_AgregarOK(r01.Id);
            }
        }

        private void Salir()
        {
            Close();
        }

        private void Handler_AgregarOK(int id)
        {
            Helpers.Msg.AgregarOk();

            EventHandler<int> handler = AgregarOK;
            if (handler != null)
            {
                handler(this, id);
            }
        }

        public void Limpiar() 
        {
            TB_DESCRIPCION.Text = "";
            TB_DESCRIPCION.Select();
        }

    }
}