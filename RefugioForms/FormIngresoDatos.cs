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
using System.Xml.Serialization;
using System.Xml;
using RefugioClases;

namespace RefugioForms
{
    public partial class FormIngresoDatos : Form
    {

        public string path;

        public FormIngresoDatos()
        {
            InitializeComponent();

            foreach (ESexo sex in Enum.GetValues(typeof(ESexo)))
            {
                this.CBSexo.Items.Add(sex);
            }

            this.CBSexo.SelectedItem = ESexo.SIN_SEXO;
        }

        /// <summary>
        /// metodo que verifica que todos los item de carga de datos esten cargados
        /// </summary>
        /// <returns> devuelve una variable que me indica si todos los items estan cargados </returns>
        protected bool CargarFormulario()
        {
            bool esta = true;
            foreach (Control item in this.Controls)
            {
                if (item is TextBox & item.Text == String.Empty)
                {
                    esta = false;
                    break;
                }
            }
            return esta;
        }

        protected void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (this.CargarFormulario())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("ERROR,Hay campos sin completar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void buttonCancelar_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.Cancel;
        
    }
}
