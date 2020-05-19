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
 
    public partial class Editar : Form
    {

        public event EventHandler<int> EditarOK = null;
        OOB.Contable.TipoDocumento.Ficha FichaEditar;

        public Editar(OOB.Contable.TipoDocumento.Ficha ficha)
        {
            InitializeComponent();
            FichaEditar = ficha;
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            TB_DESCRIPCION.Text = FichaEditar.Descripcion;
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
            var msg = MessageBox.Show("Actualizar Datos Ficha ?","*** Alerta ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                var editar = new OOB.Contable.TipoDocumento.Editar() { Id= FichaEditar.Id,  Descripcion =TB_DESCRIPCION.Text.Trim()};
                var r01 = Globals.MyData.TipoDocumento_Editar(editar);
                if (r01.Result == OOB.Resultado.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                Handler_EditarOK(editar.Id);
                Close();
            }
        }

        private void Handler_EditarOK(int id)
        {
            Helpers.Msg.EditarOk ();

            EventHandler<int> handler = EditarOK;
            if (handler != null)
            {
                handler(this, id);
            }
        }

        private void Salir()
        {
            Close();
        }

    }
}