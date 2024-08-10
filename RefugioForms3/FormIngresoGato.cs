using RefugioClases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.Text.Json;
using Microsoft.Data.SqlClient;

namespace RefugioForms
{
    public partial class FormIngresoGato : FormIngresoDatos, Iordenamiento<Gato>
    {
        private Gato gatoIngresado;

        private SqlCommand? comando;
        private SqlDataReader? lector;
        public Gato GatoIngresado
        {
            get
            {
                return this.gatoIngresado;
            }

            set
            {
                this.gatoIngresado = value;
            }
        }
        public FormIngresoGato() : base()
        {
            InitializeComponent();
            foreach (ERazaGatos razG in Enum.GetValues(typeof(ERazaGatos)))
            {
                this.CBRaza.Items.Add(razG);
            }
            this.CBRaza.SelectedItem = ERazaGatos.MESTIZO;

            this.buttonAceptar.Click += this.BformularioClick;
            this.buttonCancelar.Click += base.buttonCancelar_Click;
        }

        public FormIngresoGato(Gato gato, bool restringido = false) : this()
        {
            if (restringido)
            {
                this.textBoxNombre.Text = gato.Nombre.ToString().ToUpper();
                this.textBoxPeso.Text = gato.Peso.ToString().ToUpper();
                this.textBoxEdad.Text = gato.Edad.ToString().ToUpper();
                this.textBoxColorOjos.Text = gato.ColorOjos.ToString().ToUpper();
                this.checkBoxDomestico.Checked = gato.EsDomestico;
                this.TBComportamiento.Text = gato.Comportamiento.ToString().ToUpper();

                this.CBSexo.Items.Clear();
                this.CBSexo.Items.AddRange(new object[] { gato.Sexo });
                this.CBSexo.SelectedItem = gato.Sexo;

                this.CBRaza.Items.Clear();
                this.CBRaza.Items.AddRange(new object[] { gato.RazaGatos });
                this.CBRaza.SelectedItem = gato.RazaGatos;

                this.textBoxNombre.ReadOnly = true;
                this.textBoxPeso.ReadOnly = true;
                this.textBoxColorOjos.ReadOnly = true;
                this.textBoxEdad.ReadOnly = true;
                this.checkBoxDomestico.Enabled = false;
                this.TBComportamiento.ReadOnly = true;

            }
            else
            {
                this.textBoxNombre.Text = gato.Nombre.ToString();
                this.textBoxPeso.Text = gato.Peso.ToString();
                this.textBoxEdad.Text = gato.Edad.ToString();
                this.textBoxColorOjos.Text = gato.ColorOjos.ToString();
                this.CBRaza.SelectedItem = gato.RazaGatos;
                this.checkBoxDomestico.Checked = gato.EsDomestico;
                this.CBSexo.SelectedItem = gato.Sexo;
                this.TBComportamiento.Text = gato.Comportamiento.ToString();
            }

        }

        private void BformularioClick(object sender, EventArgs e)
        {
            if (base.CargarFormulario())
            {
                try
                {
                    if (this.checkBoxDomestico.Checked == false && this.TBComportamiento.Text == String.Empty)
                    {
                        this.gatoIngresado = new Gato(base.textBoxNombre.Text, base.textBoxColorOjos.Text,
                            int.Parse(base.textBoxEdad.Text), double.Parse(base.textBoxPeso.Text),
                            (ESexo)base.CBSexo.SelectedItem, (ERazaGatos)this.CBRaza.SelectedItem);
                    }
                    else if (this.TBComportamiento.Text == String.Empty)
                    {
                        this.gatoIngresado = new Gato(base.textBoxNombre.Text, base.textBoxColorOjos.Text,
                            int.Parse(base.textBoxEdad.Text), double.Parse(base.textBoxPeso.Text),
                            (ESexo)base.CBSexo.SelectedItem, (ERazaGatos)this.CBRaza.SelectedItem, this.checkBoxDomestico.Checked);
                    }
                    else
                    {
                        this.gatoIngresado = new Gato(base.textBoxNombre.Text, base.textBoxColorOjos.Text,
                            int.Parse(base.textBoxEdad.Text), double.Parse(base.textBoxPeso.Text),
                            (ESexo)base.CBSexo.SelectedItem, (ERazaGatos)this.CBRaza.SelectedItem, this.checkBoxDomestico.Checked, this.TBComportamiento.Text);
                    }

                    this.DialogResult = DialogResult.OK;
                }
                catch (FormatException exc)
                {
                    MessageBox.Show("Alguno de los datos ingresados no respeta el formato indicado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        public List<Gato> organizarPorNombreASC(List<Gato> lista)
        {
            if (lista.Count > 0)
            {
                lista = lista.OrderBy(x => x.Nombre).ToList();
            }
            else
            {
                throw new ExcepcionsListas();
            }
            return lista;
        }

        public List<Gato> organizarPorNombreDES(List<Gato> lista)
        {
            if (lista.Count > 0)
            {
                lista = lista.OrderByDescending(x => x.Nombre).ToList();
            }
            else
            {
                throw new ExcepcionsListas();
            }
            return lista;
        }

        public List<Gato> organizarPorEdadASC(List<Gato> lista)
        {

            if (lista.Count > 0)
            {
                lista = lista.OrderBy(x => x.Edad).ToList();
            }
            else
            {
                throw new ExcepcionsListas();
            }
            return lista;
        }
        public List<Gato> organizarPorEdadDES(List<Gato> lista)
        {
            if (lista.Count > 0)
            {
                lista = lista.OrderByDescending(x => x.Edad).ToList();
            }
            else
            {
                throw new ExcepcionsListas();
            }
            return lista;

        }
    }
}
