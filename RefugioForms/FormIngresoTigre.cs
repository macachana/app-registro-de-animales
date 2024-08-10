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
    public partial class FormIngresoTigre : FormIngresoDatos,Iordenamiento<Tigre>
    {
        private Tigre tigreIngresado;
        private SqlCommand? comando;
        private SqlDataReader? lector;
        public Tigre TigreIngresado
        {
            get
            {
                return this.tigreIngresado;
            }

            set
            {
                this.tigreIngresado = value;
            }
        }

        public FormIngresoTigre() : base()
        {
            InitializeComponent();
            foreach (EsubEspecie des in Enum.GetValues(typeof(EsubEspecie)))
            {
                this.CBSubEspecie.Items.Add(des);
            }
            this.CBSubEspecie.SelectedItem = EsubEspecie.BENGALA;
            this.buttonAceptar.Click += this.BformularioClick;
            this.buttonCancelar.Click += base.buttonCancelar_Click;
        }

        public FormIngresoTigre(Tigre tigre, bool restringido = false) : this()
        {
            if (restringido)
            {
                this.textBoxNombre.Text = tigre.Nombre.ToString().ToUpper();
                this.textBoxPeso.Text = tigre.Peso.ToString().ToUpper();
                this.textBoxColorOjos.Text = tigre.ColorOjos.ToString().ToUpper();
                this.textBoxEdad.Text = tigre.Edad.ToString().ToUpper();
                this.textBoxHabitat.Text = tigre.Habitat.ToString().ToUpper();

                this.CBSubEspecie.Items.Clear();
                this.CBSubEspecie.Items.AddRange(new object[] { tigre.SubEspecie });
                this.CBSubEspecie.SelectedItem = tigre.SubEspecie;

                this.CBSexo.Items.Clear();
                this.CBSexo.Items.AddRange(new object[] { tigre.Sexo });
                this.CBSexo.SelectedItem = tigre.Sexo;

                this.textBoxNombre.ReadOnly = true;
                this.textBoxPeso.ReadOnly = true;
                this.textBoxColorOjos.ReadOnly = true;
                this.textBoxEdad.ReadOnly = true;
                this.textBoxHabitat.ReadOnly = true;
            }
            else
            {
                this.textBoxNombre.Text = tigre.Nombre.ToString();
                this.textBoxPeso.Text = tigre.Peso.ToString();
                this.textBoxColorOjos.Text = tigre.ColorOjos.ToString();
                this.textBoxEdad.Text = tigre.Edad.ToString();
                this.textBoxHabitat.Text = tigre.Habitat.ToString();
                this.CBSexo.SelectedItem = tigre.Sexo;
            }
        }

        private void BformularioClick(object sender, EventArgs e)
        {
            if (base.CargarFormulario())
            {
                try
                {
                    if (this.textBoxHabitat.Text == String.Empty && (EsubEspecie)this.CBSubEspecie.SelectedItem == EsubEspecie.BENGALA)
                    {
                        this.tigreIngresado = new Tigre(base.textBoxNombre.Text, base.textBoxColorOjos.Text, int.Parse(base.textBoxEdad.Text),
                        double.Parse(base.textBoxPeso.Text), (ESexo)base.CBSexo.SelectedItem);
                    }
                    else if (this.textBoxHabitat.Text == String.Empty)
                    {
                        this.tigreIngresado = new Tigre(base.textBoxNombre.Text, base.textBoxColorOjos.Text, int.Parse(base.textBoxEdad.Text),
                        double.Parse(base.textBoxPeso.Text), (ESexo)base.CBSexo.SelectedItem, (EsubEspecie)this.CBSubEspecie.SelectedItem);
                    }
                    else
                    {
                        this.tigreIngresado = new Tigre(base.textBoxNombre.Text, base.textBoxColorOjos.Text, int.Parse(base.textBoxEdad.Text),
                        double.Parse(base.textBoxPeso.Text), (ESexo)base.CBSexo.SelectedItem, (EsubEspecie)this.CBSubEspecie.SelectedItem, this.textBoxHabitat.Text);
                    }
                    this.DialogResult = DialogResult.OK;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Alguno de los datos ingresados no respeta el formato indicado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }


        public List<Tigre> organizarPorNombreASC(List<Tigre> lista)
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

        public List<Tigre> organizarPorNombreDES(List<Tigre> lista)
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

        public List<Tigre> organizarPorEdadASC(List<Tigre> lista)
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

        public List<Tigre> organizarPorEdadDES(List<Tigre> lista)
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
