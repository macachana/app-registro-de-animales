using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using RefugioClases;

namespace RefugioForms
{
    public partial class FormRegistroUsuarios : Form
    {
        public List<string> usuariosLogueados;
        public FormRegistroUsuarios()
        {
            InitializeComponent();
            usuariosLogueados = new List<string>();
        }

        public void visualizarLista()
        {
            this.Registro_view.Items.Clear();
            foreach (string usuarioI in this.usuariosLogueados)
            {
                this.Registro_view.Items.Add(usuarioI);
            }
        }

        private void aBRIRARCHIVOLOGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombreArchivo;
            if (OFDArchivoLog.ShowDialog() == DialogResult.OK)
            {
                nombreArchivo = OFDArchivoLog.FileName;
                GenericArchivos<Usuario>.deserializarArchivoTexto(nombreArchivo);
                this.visualizarLista();
            }
        }

        private void gUARDARARCHIVOLOGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombreArchivo;
            if (SFDArchivoLog.ShowDialog() == DialogResult.OK)
            {
                nombreArchivo = SFDArchivoLog.FileName;
                GenericArchivos<Usuario>.serializarArchivoTexto(nombreArchivo);
                this.visualizarLista();
            }
        }
    }
}
