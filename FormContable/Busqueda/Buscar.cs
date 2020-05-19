using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormContable.Busqueda
{
    public partial class Buscar : Form
    {

        public event EventHandler<string> BuscarOk;

        public Buscar()
        {
            InitializeComponent();
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            var cad = TB_BUSCAR.Text.Trim();
            if (cad != "")
            {
                EventHandler<string> handler = BuscarOk;
                if (handler != null) 
                {
                    handler(this, cad);
                }
            }
        }
       
    }
}