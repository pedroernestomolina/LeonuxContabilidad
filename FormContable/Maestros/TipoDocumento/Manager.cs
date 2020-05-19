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
    public partial class Manager : Form
    {

        private BindingSource bs;
        private BindingList<OOB.Contable.TipoDocumento.Ficha> Documentos;

        public Manager()
        {
            InitializeComponent();
            bs = new BindingSource();
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            DGV.AllowUserToAddRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.ReadOnly = true;

            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Descripcion";
            c2.HeaderText = "Descripción";
            c2.Visible = true;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            DGV.Columns.Add(c2);
            CargarData();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            Close();
        }

        private void CargarData()
        {
            var r01 = Globals.MyData.TipoDocumento_Lista();
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var l = r01.Lista.OrderBy(d => d.Descripcion).ToList();
            Documentos= new BindingList<OOB.Contable.TipoDocumento.Ficha>(l);
            bs.CurrentChanged += bs_CurrentChanged;
            bs.DataSource = Documentos;
            DGV.DataSource = bs;
        }

        private void bs_CurrentChanged(object sender, EventArgs e)
        {
            if (bs.Current != null) 
            {
            }
        }
     
        private void feditar_EditarOk(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void BT_REFRESCAR_Click(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void BT_AGREGAR_Click(object sender, EventArgs e)
        {
            AgregarItem();
        }

        private void BT_ELIMINAR_Click(object sender, EventArgs e)
        {
            EliminarItem();
        }

        private void BT_EDITAR_Click(object sender, EventArgs e)
        {
            EditarItem();
        }

        private void EditarItem()
        {
            if (bs != null)
            {
                if (bs.Current != null)
                {
                    var ficha = (OOB.Contable.TipoDocumento.Ficha)bs.Current;
                    var feditar = new Editar(ficha);
                    feditar.EditarOK +=feditar_EditarOK;
                    feditar.ShowDialog();
                }
            }
        }

        private void feditar_EditarOK(object sender, int e)
        {
            var r=Documentos.FirstOrDefault(d => d.Id == e);
            if (r != null) 
            {
                Documentos.Remove(r);
                ActualizarLista(e);
            }
        }

        private void EliminarItem()
        {
            if (bs != null)
            {
                if (bs.Current != null)
                {
                    var ficha = (OOB.Contable.TipoDocumento.Ficha)bs.Current;
                    var eliminar = new Eliminar();
                    if (eliminar.Elimina(ficha))
                    {
                        bs.Remove(ficha);
                        Helpers.Msg.EliminarOk();
                    };
                }
            }
        }

        private void Refrescar()
        {
            var r01 = Globals.MyData.TipoDocumento_Lista();
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var l = r01.Lista.OrderBy(d => d.Descripcion).ToList();
            Documentos = new BindingList<OOB.Contable.TipoDocumento.Ficha>(l);
            bs.DataSource = Documentos;
        }

        Agregar fagregar = null;
        private void AgregarItem()
        {
            fagregar = new Agregar();
            fagregar.AgregarOK += fagregar_AgregarOK;
            fagregar.ShowDialog();
        }

        private void fagregar_AgregarOK(object sender, int e)
        {
            ActualizarLista(e);
            fagregar.Limpiar();
        }

        void ActualizarLista(int id) 
        {
            var r01 = Globals.MyData.TipoDocumento_Get(id);
            if (r01.Result == OOB.Resultado.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Documentos.Add(r01.Entidad);
            var list = Documentos.OrderBy(d => d.Descripcion).ToList();

            Documentos.Clear();
            foreach (var it in list)
            {
                Documentos.Add(it);
            }
        }

    }
}