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
using RefugioClases;
using Microsoft.Data.SqlClient;

namespace RefugioForms
{
    public partial class FormIngresoPerro : FormIngresoDatos, Iordenamiento<Perro>
    {
        private Perro perroIngresado;
        private SqlCommand? comando;
        private SqlDataReader? lector;

        public Perro PerroIngresado
        {
            get
            {
                return this.perroIngresado;
            }

            set
            {
                this.perroIngresado = value;
            }
        }

        public FormIngresoPerro() : base()
        {
            InitializeComponent();

            foreach (Etamanio tam in Enum.GetValues(typeof(Etamanio)))
            {
                this.CBTamanio.Items.Add(tam);
            }

            this.CBTamanio.SelectedItem = Etamanio.GRANDE;
            this.buttonAceptar.Click += this.BformularioClick;
            this.buttonCancelar.Click += base.buttonCancelar_Click;
        }

        public FormIngresoPerro(Perro perro, bool restringido = false) : this()
        {
            if (restringido)
            {
                this.textBoxNombre.Text = perro.Nombre.ToString().ToUpper();
                this.textBoxPeso.Text = perro.Peso.ToString().ToUpper();
                this.textBoxEdad.Text = perro.Edad.ToString().ToUpper();
                this.textBoxColorOjos.Text = perro.ColorOjos.ToString().ToUpper();
                this.textBoxRaza.Text = perro.Raza.ToString().ToUpper();

                this.CBSexo.Items.Clear();
                this.CBSexo.Items.AddRange(new object[] { perro.Sexo });
                this.CBSexo.SelectedItem = perro.Sexo;


                this.CBTamanio.Items.Clear();
                this.CBTamanio.Items.AddRange(new object[] { perro.Tamanio });
                this.CBTamanio.SelectedItem = perro.Tamanio;



                this.textBoxNombre.ReadOnly = true;
                this.textBoxPeso.ReadOnly = true;
                this.textBoxColorOjos.ReadOnly = true;
                this.textBoxEdad.ReadOnly = true;
                this.textBoxRaza.ReadOnly = true;
            }
            else
            {
                this.textBoxNombre.Text = perro.Nombre.ToString();
                this.textBoxPeso.Text = perro.Peso.ToString();
                this.textBoxEdad.Text = perro.Edad.ToString();
                this.textBoxColorOjos.Text = perro.ColorOjos.ToString();
                this.textBoxRaza.Text = perro.Raza.ToString();
                this.CBSexo.SelectedItem = perro.Sexo;
                this.CBTamanio.SelectedItem = perro.Tamanio;
            }
        }

        private void BformularioClick(object sender, EventArgs e)
        {
            if (base.CargarFormulario())
            {
                try
                {
                    if (this.textBoxRaza.Text == String.Empty)
                    {
                        this.perroIngresado = new Perro(base.textBoxNombre.Text, base.textBoxColorOjos.Text,
                            int.Parse(base.textBoxEdad.Text), double.Parse(base.textBoxPeso.Text)
                        , (ESexo)base.CBSexo.SelectedItem, (Etamanio)this.CBTamanio.SelectedItem);
                    }
                    else
                    {
                        this.perroIngresado = new Perro(base.textBoxNombre.Text, base.textBoxColorOjos.Text,
                            int.Parse(base.textBoxEdad.Text), double.Parse(base.textBoxPeso.Text)
                        , (ESexo)base.CBSexo.SelectedItem, (Etamanio)this.CBTamanio.SelectedItem, this.textBoxRaza.Text);
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

        public List<Perro> organizarPorNombreASC(List<Perro> lista)
        {
            if(lista.Count > 0)
            {
                lista = lista.OrderBy(x => x.Nombre).ToList();
            }
            else
            {
                throw new ExcepcionsListas();
            }
            return lista;
        }
        public List<Perro> organizarPorNombreDES(List<Perro> lista)
        {
            if(lista.Count > 0)
            {
                lista = lista.OrderByDescending(x => x.Nombre).ToList();
            }
            else
            {
                throw new ExcepcionsListas();

            }
            return lista;
        }
        public List<Perro> organizarPorEdadASC(List<Perro> lista)
        {
            if(lista.Count > 0)
            {
                lista = lista.OrderBy(x => x.Edad).ToList();
            }
            else
            {
                throw new ExcepcionsListas();
            }
            return lista;
        }
        public List<Perro> organizarPorEdadDES(List<Perro> lista)
        {
            if(lista.Count > 0)
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
