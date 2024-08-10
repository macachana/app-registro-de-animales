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
using System.Windows; // window
using RefugioClases;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace RefugioForms
{
    public partial class FormPrincipal : Form
    {
        #region ATRIBUTOS
        public delegate void cambiarLabel(Usuario usuario);

        public delegate void cambiarHilo();

        public delegate void metodosFiltro();

        private Task? t;

        /*variable que me indica como inicializar la aplicacion 
        (si Archivos es true entonces se inicializa en archivo json,
        pero si es false entonces la aplicacion se inicializa en bases de datos)*/
        public bool baseDatos;

        public bool createPermiso;
        public bool updatePermiso;
        public bool deletePermiso;

        // variables de uso general
        private Usuario usuarioIngresado;

        private AccesoDatos ado;
        private List<Perro> listaPerros;
        private List<Gato> listaGatos;
        private List<Tigre> listaTigres;

        private Refugio refugioHP;
        private FormIngresoPerro frmPerro;
        private FormIngresoGato frmGato;
        private FormIngresoTigre frmTigre;

        private FormRegistroUsuarios frmRegistroU;

        private ManejadorEventos manejadorEventos;

        metodosFiltro FiltroAnimales;

        #endregion


        public FormPrincipal()
        {
            InitializeComponent();
            this.t = Task.Run(() => inicializarVariables());
        }

        #region INICIALIZACION DE VARIABLES
        /// <summary>
        /// inicializa las variables que se utilizaran en la app
        /// </summary>
        private void inicializarVariables()
        {
            this.listaPerros = new List<Perro>();
            this.listaGatos = new List<Gato>();
            this.listaTigres = new List<Tigre>();
            this.refugioHP = new Refugio();
            this.ado = new AccesoDatos();

            this.frmPerro = new FormIngresoPerro();
            this.frmGato = new FormIngresoGato();
            this.frmTigre = new FormIngresoTigre();

            this.frmRegistroU = new FormRegistroUsuarios();

            this.manejadorEventos = new ManejadorEventos();

            // Suscribirse a los eventos
            // eventos de serializacion json
            this.manejadorEventos.SerializarPerroJ += SerializarJPerro;
            this.manejadorEventos.DeserializarPerroJ += DeserializarJPerro;

            this.manejadorEventos.SerializarGatoJ += SerializarJGato;
            this.manejadorEventos.DeserializarGatoJ += DeserializarJGato;

            this.manejadorEventos.SerializarTigreJ += SerializarJTigre;
            this.manejadorEventos.DeserializarTigreJ += DeserializarJTigre;


            // eventos de serializacion xml
            this.manejadorEventos.SerializarPerroX += SerializarXMLPerro;
            this.manejadorEventos.DeserializarPerroX += DeserializarXMLPerro;

            this.manejadorEventos.SerializarGatoX += SerializarXMLGato;
            this.manejadorEventos.DeserializarGatoX += DeserializarXMLGato;

            this.manejadorEventos.SerializarTigreX += SerializarXMLTigre;
            this.manejadorEventos.DeserializarTigreX += DeserializarXMLTigre;

            // Asignar los manejadores de eventos a los botones
            // asignacion de eventos de serializacion y deserializacion de archivos json            
            this.TSSerArchivoJsonP.Click += (sender, e) => this.manejadorEventos.OnSerializarPerroJson();
            this.TSDesArchivoJsonP.Click += (sender, e) => this.manejadorEventos.OnDeserializarPerroJson();
            this.TSSerArchivoJsonG.Click += (sender, e) => this.manejadorEventos.OnSerializarGatoJson();
            this.TSDesArchivoJsonG.Click += (sender, e) => this.manejadorEventos.OnDeserializarGatoJson();
            this.TSSerArchivoJsonT.Click += (sender, e) => this.manejadorEventos.OnSerializarTigreJson();
            this.TSDesArchivoJsonT.Click += (sender, e) => this.manejadorEventos.OnDeserializarTigreJson();

            // asignacion de eventos de serializacion y deserializacion de archivos xml
            this.TSSerArchivoXmlP.Click += (sender, e) => this.manejadorEventos.OnSerializarPerroXML();
            this.TSDesArchivoXmlP.Click += (sender, e) => this.manejadorEventos.OnDeserializarPerroXML();
            this.TSSerArchivoXmlG.Click += (sender, e) => this.manejadorEventos.OnSerializarGatoXML();
            this.TSDesArchivoXmlG.Click += (sender, e) => this.manejadorEventos.OnDeserializarGatoXML();
            this.TSSerArchivoXmlT.Click += (sender, e) => this.manejadorEventos.OnSerializarTigreXML();
            this.TSDesArchivoXmlT.Click += (sender, e) => this.manejadorEventos.OnDeserializarTigreXML();
            FiltroAnimales = this.MostrarAnimalMasPesado;
            FiltroAnimales += this.MostrarAnimalMasViejo;
        }

        #endregion


        /// <summary>
        /// me permite que dependiendo del estado de la variable booleana "baseDatos" (la cual tiene un valor u otro dependiendo de si el usuario
        /// quiere inicializar con base de datos o con archivo JSON)
        /// </summary>
        public async void inicializarDatos()
        {
            try
            {
                if(await this.ado.ProbarConexion())
                {
                    if(this.baseDatos)
                    {
                        this.refugioHP.Animales = await this.ado.ObtenerListaDato();
                        this.dividirListaGeneral(this.refugioHP.Animales);
                    }
                    else
                    {
                        this.listaPerros = GenericArchivos<Perro>.deserializarArchivoJSON("ListaPerrosJson.json");
                        this.listaGatos = GenericArchivos<Gato>.deserializarArchivoJSON("ListaGatosJson.json");
                        this.listaTigres = GenericArchivos<Tigre>.deserializarArchivoJSON("ListaTigresJson.json");
                    }
                }
            }catch(ExcepcionBD excBD)
            {
                MessageBox.Show(excBD.Message);
            }
            finally
            {
                this.t = Task.Run(() => ActualizarVisor());
            }
        }

        public void dividirListaGeneral(List<Animal> lista)
        {
            foreach(Animal a in lista)
            {
                if(a is Perro)
                {
                    this.listaPerros += (Perro)a;
                }
                else if(a is Gato)
                {
                    this.listaGatos += (Gato)a;
                }
                else if(a is Tigre)
                {
                    this.listaTigres += (Tigre)a;
                }
            }
        }

        /// <summary>
        /// este metodo me permite inicializar los permisos del usuario logueado dependiendo de su "perfil"
        /// </summary>
        /// <param name="usuario"> usuario logueado </param>
        public async void AsignarPermisos(Usuario usuario)
        {
            await Task.Run(() => { 
                if (usuario.perfil == "administrador")
                {
                    this.createPermiso = true;
                    this.updatePermiso = true;
                    this.deletePermiso = true;
                }
                else if (usuario.perfil == "supervisor")
                {
                    this.createPermiso = true;
                    this.updatePermiso = true;
                    this.deletePermiso = false;
                }
                else
                {
                    this.createPermiso = false;
                    this.updatePermiso = false;
                    this.deletePermiso = false;
                }
                this.usuarioIngresado = usuario;            
            });
        }

        /// <summary>
        /// el metodo "ActualizarVisor" me permite actualizar el visor que 
        /// le pase por parametro, limpiandolo y luego ingresando los "items" de una
        /// determinada lista de animales.
        /// </summary>
        /// <param name="visor"> ListBox en donde se ingresar los datos de determinado animal, el cual es seleccionado en 
        /// el form FormTipoAnimal </param>
        // este metodo se ejecuta en otro hilo, pero luego se cambia al hilo principal para asi poder modificar los ListBox
        private void ActualizarVisor()
        {
            if (this.ListBoxPerros.InvokeRequired)
            {
                cambiarHilo cambio = new cambiarHilo(ActualizarVisor);
                this.ListBoxPerros.Invoke(cambio);
            }
            else
            {
                this.ListBoxPerros.Items.Clear();
                foreach (var perrito in this.listaPerros)
                {
                    this.refugioHP.Animales += perrito;
                    this.ListBoxPerros.Items.Add(perrito);
                }
            }
            
            if (this.ListBoxGatos.InvokeRequired)
            {
                cambiarHilo cambio = new cambiarHilo(ActualizarVisor);
                this.ListBoxGatos.Invoke(cambio);

            }
            else
            {
                this.ListBoxGatos.Items.Clear();
                foreach (var gatito in this.listaGatos)
                {
                    this.refugioHP.Animales += gatito;
                    this.ListBoxGatos.Items.Add(gatito);
                }
            }
            
            if (this.ListBoxTigres.InvokeRequired)
            {
                cambiarHilo cambio = new cambiarHilo(ActualizarVisor);
                this.ListBoxTigres.Invoke(cambio);
            }
            else
            {
                this.ListBoxTigres.Items.Clear();
                foreach (var tigre in this.listaTigres)
                {
                    this.refugioHP.Animales += tigre;
                    this.ListBoxTigres.Items.Add(tigre);
                }
            }
            this.FiltroAnimales?.Invoke();
        }


        /// <summary>
        /// este metodo me permite Mostrar el usuario logueado en el label 
        /// de el formulario principal
        /// </summary>
        /// <param name="usuarioIng"> usuario ingresado por el FormLogin </param>   
        public void MostrarUsuario(Usuario usuario)
        {
            if (this.labelUsuarioLog.InvokeRequired)
            {
                cambiarLabel metodosDel = new cambiarLabel(MostrarUsuario);

                object[] parametro = new object[] { usuario };
                this.labelUsuarioLog.Invoke(metodosDel,parametro);
            }
            else
            {
                this.labelUsuarioLog.Text = usuario.MostrarPrincipal();
            }
        }

        /// <summary>
        /// este metodo me devuelven el nombre y la edad del animal más viejo
        /// </summary>
        /// 
        // agregar un delegate general que acumule los metodos mostrarAnimalViejo de las tres clases derivadas
        public void MostrarAnimalMasViejo()
        {
            Perro perroAux = new Perro();
            Gato gatoAux = new Gato();
            Tigre tigreAux = new Tigre();

            this.dividirListaGeneral(this.refugioHP.Animales);

            foreach(Perro p in this.listaPerros)
            {
                int edad = (int)p;
                if (edad > perroAux.Edad)
                {
                    perroAux.Nombre = p.Nombre;
                    perroAux.Edad = edad;
                }
            }

            foreach(Gato g in this.listaGatos)
            {
                int edad = (int)g;
                if (edad > gatoAux.Edad)
                {
                    gatoAux.Nombre = g.Nombre;
                    gatoAux.Edad = edad;
                }
            }

            foreach(Tigre t in this.listaTigres)
            {
                int edad = (int)t;
                if (edad > tigreAux.Edad)
                {
                    tigreAux.Nombre = t.Nombre;
                    tigreAux.Edad = edad;
                }
            }

            this.labelPerroMasViejo.Text = perroAux.mostrarAnimalViejo(perroAux.Nombre, perroAux.Edad);
            this.labelGatoMasViejo.Text = gatoAux.mostrarAnimalViejo(gatoAux.Nombre, gatoAux.Edad);
            this.labelTigreMasViejo.Text = tigreAux.mostrarAnimalViejo(tigreAux.Nombre, tigreAux.Edad);
        }

        /// <summary>
        /// este metodo me devuelven el nombre y el peso del animal más pesado
        /// </summary>
        /// 
        // agregar un delegate general que acumule los metodos mostrarAnimalPesado de las tres clases derivadas
        public void MostrarAnimalMasPesado()
        {
            Perro perroAux = new Perro();
            Gato gatoAux = new Gato();
            Tigre tigreAux = new Tigre();

            this.dividirListaGeneral(this.refugioHP.Animales);

            foreach(Perro p in this.listaPerros)
            {
                double peso = p;
                if (peso > perroAux.Peso)
                {
                    perroAux.Nombre = p.Nombre;
                    perroAux.Peso = peso;
                }
            }

            foreach(Gato g in this.listaGatos)
            {
                double peso = g;
                if (peso > gatoAux.Peso)
                {
                    gatoAux.Nombre = g.Nombre;
                    gatoAux.Peso = peso;
                }
            }

            foreach(Tigre t in this.listaTigres)
            {
                double peso = t;
                if (peso > tigreAux.Peso)
                {
                    tigreAux.Nombre = t.Nombre;
                    tigreAux.Peso = peso;
                }
            }

            this.labelPerroMasPesado.Text = perroAux.mostrarAnimalPesado(perroAux.Nombre, perroAux.Peso);
            this.labelGatoMasPesado.Text = gatoAux.mostrarAnimalPesado(gatoAux.Nombre, gatoAux.Peso);
            this.labelTigreMasPesado.Text = tigreAux.mostrarAnimalPesado(tigreAux.Nombre, tigreAux.Peso);
        }

        #region INGRESO DE DATOS
        /// <summary>
        /// el metodo " pERROSToolStripMenuItem_Click" se encarga de abrir el formulario perro para
        /// que el usuario pueda ingresar los datos que pide.
        /// </summary>
        private void pERROSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.createPermiso)
            {
                this.frmPerro = new FormIngresoPerro();
                frmPerro.ShowDialog();
                if (frmPerro.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (this.ado.AgregarDato(frmPerro.PerroIngresado))
                            this.listaPerros += frmPerro.PerroIngresado;
                    }catch(ExcepcionBD exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                    finally
                    {
                        this.t = Task.Run(() => ActualizarVisor());
                    }
                }
            }
            else
            {
                MessageBox.Show($"SU PERFIL {this.usuarioIngresado.perfil} NO TIENE PERMISO PARA CREAR UN ITEM", "ERROR DE PERMISOS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// el metodo " pERROSToolStripMenuItem_Click" se encarga de abrir el formulario gato para
        /// que el usuario pueda ingresar los datos que pide.
        /// </summary>
        private void gATOToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (this.createPermiso)
            {
                this.frmGato = new FormIngresoGato();
                frmGato.ShowDialog();
                if (frmGato.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (this.ado.AgregarDato(frmGato.GatoIngresado))
                            this.listaGatos += frmGato.GatoIngresado;
                    }
                    catch(ExcepcionBD excBD)
                    {
                        MessageBox.Show(excBD.Message);
                    }
                    finally
                    {
                        this.t = Task.Run(() => ActualizarVisor());
                    }
                }
            }
            else
            {
                MessageBox.Show($"SU PERFIL {this.usuarioIngresado.perfil} NO TIENE PERMISO PARA CREAR UN ITEM", "ERROR DE PERMISOS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// el metodo " pERROSToolStripMenuItem_Click" se encarga de abrir el formulario tigre para
        /// que el usuario pueda ingresar los datos que pide.
        /// </summary>
        private void tIGREToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.createPermiso)
            {
                this.frmTigre = new FormIngresoTigre();
                frmTigre.ShowDialog();
                if (frmTigre.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        if (this.ado.AgregarDato(frmTigre.TigreIngresado))
                            this.listaTigres += frmTigre.TigreIngresado;
                    }
                    catch(ExcepcionBD excBD)
                    {
                        MessageBox.Show(excBD.Message);
                    }
                    finally
                    {
                        this.t = Task.Run(() => ActualizarVisor());
                    }
                }
            }
            else
            {
                MessageBox.Show($"SU PERFIL {this.usuarioIngresado.perfil} NO TIENE PERMISO PARA CREAR UN ITEM", "ERROR DE PERMISOS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        #endregion

        #region MODIFICAR DATOS
        /// <summary>
        /// este metodo permite modificar un animal dependiendo del item seleccionado,
        /// si un item del visor "Perro" es seleccionado entonces abrira el formulario 
        /// FormIngresoPerro , y asi si selecciono un item del visor gatos o tigre.
        /// </summary>
        private void mODIFICARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.updatePermiso)
            {
                int elIntGato = ListBoxGatos.SelectedIndex;
                int elIntPerro = ListBoxPerros.SelectedIndex;
                int elIntTigre = ListBoxTigres.SelectedIndex;
                if (elIntPerro != -1)
                {
                    this.frmPerro = new FormIngresoPerro(this.listaPerros[elIntPerro]);
                    frmPerro.ShowDialog();

                    if (frmPerro.DialogResult == DialogResult.OK)
                    {
                        if (this.baseDatos)
                        {
                            try
                            {
                                if (this.ado.ModificarDato(this.listaPerros[elIntPerro], frmPerro.PerroIngresado))
                                {
                                    this.refugioHP.modificarItem(this.listaPerros[elIntPerro], frmPerro.PerroIngresado);

                                    this.listaPerros[elIntPerro] = frmPerro.PerroIngresado;

                                }
                            }
                            catch(ExcepcionBD excBD)
                            {
                                MessageBox.Show(excBD.Message);
                            }
                        }
                        else
                        {
                            this.refugioHP.modificarItem(this.listaPerros[elIntPerro], frmPerro.PerroIngresado);

                            this.listaPerros[elIntPerro] = frmPerro.PerroIngresado;

                        }
                        this.t = Task.Run(() => ActualizarVisor());
                    }
                }
                else if (elIntGato != -1)
                {
                    this.frmGato = new FormIngresoGato(this.listaGatos[elIntGato]);
                    frmGato.ShowDialog();
                    if (frmGato.DialogResult == DialogResult.OK)
                    {
                        if (this.baseDatos)
                        {
                            try
                            {
                                if (this.ado.ModificarDato(this.listaGatos[elIntGato], frmGato.GatoIngresado))
                                {
                                    this.refugioHP.modificarItem(this.listaGatos[elIntGato], frmGato.GatoIngresado);

                                    this.listaGatos[elIntGato] = frmGato.GatoIngresado;

                                }
                            }
                            catch(ExcepcionBD excBD)
                            {
                                MessageBox.Show(excBD.Message);
                            }
                        }
                        else
                        {
                            this.refugioHP.modificarItem(this.listaGatos[elIntGato], frmGato.GatoIngresado);

                            this.listaGatos[elIntGato] = frmGato.GatoIngresado;

                        }
                        this.t = Task.Run(() => ActualizarVisor());
                    }
                }
                else if (elIntTigre != -1)
                {
                    this.frmTigre = new FormIngresoTigre(this.listaTigres[elIntTigre]);
                    frmTigre.ShowDialog();

                    if (frmTigre.DialogResult == DialogResult.OK)
                    {
                        if (this.baseDatos)
                        {
                            try
                            {
                                if (this.ado.ModificarDato(this.listaTigres[elIntTigre], frmTigre.TigreIngresado))
                                {
                                    this.refugioHP.modificarItem(this.listaTigres[elIntTigre], frmTigre.TigreIngresado);
                                
                                    this.listaTigres[elIntTigre] = frmTigre.TigreIngresado;
                                }
                            }
                            catch(ExcepcionBD excBD)
                            {
                                MessageBox.Show(excBD.Message);
                            }
                            
                        }
                        else
                        {
                            this.refugioHP.modificarItem(this.listaTigres[elIntTigre],frmTigre.TigreIngresado);

                            this.listaTigres[elIntTigre] = frmTigre.TigreIngresado;

                        }
                        this.t = Task.Run(() => ActualizarVisor());
                    }
                }
                else
                {
                    MessageBox.Show("ERROR, No selecciono ningun item", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                elIntPerro = -1;
                elIntGato = -1;
                elIntTigre = -1;
            }
            else
            {
                MessageBox.Show($"SU PERFIL {this.usuarioIngresado.perfil} NO TIENE PERMISO PARA MODIFICAR UN ITEM", "ERROR DE PERMISOS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        #region ELIMINAR DATOS
        /// <summary>
        /// este metodo elimina el item elegido, utilizando la misma logica 
        /// que el metodo de modificar item.
        /// </summary>
        private void eLIMINARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.deletePermiso)
            {
                int elIntGato = ListBoxGatos.SelectedIndex;
                int elIntPerro = ListBoxPerros.SelectedIndex;
                int elIntTigre = ListBoxTigres.SelectedIndex;

                if (elIntPerro != -1)
                {
                    this.frmPerro = new FormIngresoPerro(this.listaPerros[elIntPerro], true);
                    if (frmPerro.ShowDialog() == DialogResult.OK)
                    {
                        if (this.baseDatos)
                        {
                            try
                            {
                                if (this.ado.EliminarDato(this.listaPerros[elIntPerro]))
                                {
                                    this.refugioHP.Animales -= this.listaPerros[elIntPerro];
                                    this.listaPerros -= this.listaPerros[elIntPerro];
                                }
                            }
                            catch(ExcepcionBD excBD)
                            {
                                MessageBox.Show(excBD.Message);
                            }
                        }
                        else
                        {
                            this.refugioHP.Animales -= this.listaPerros[elIntPerro];
                            this.listaPerros -= this.listaPerros[elIntPerro];
                        }
                        this.t = Task.Run(() => ActualizarVisor());
                    }
                }
                else if (elIntGato != -1)
                {
                    this.frmGato = new FormIngresoGato(this.listaGatos[elIntGato], true);
                    if (frmGato.ShowDialog() == DialogResult.OK)
                    {
                        if (this.baseDatos)
                        {
                            try
                            {
                                if (this.ado.EliminarDato(this.listaGatos[elIntGato]))
                                {
                                    this.refugioHP.Animales -= this.listaGatos[elIntGato];
                                    this.listaGatos -= this.listaGatos[elIntGato];
                                }
                            }
                            catch(ExcepcionBD excBD)
                            {
                                MessageBox.Show(excBD.Message);
                            }
                        }
                        else
                        {
                            this.refugioHP.Animales -= this.listaGatos[elIntGato];
                            this.listaGatos -= this.listaGatos[elIntGato];
                        }
                        this.t = Task.Run(() => ActualizarVisor());
                    }
                }
                else if (elIntTigre != -1)
                {
                    this.frmTigre = new FormIngresoTigre(this.listaTigres[elIntTigre], true);
                    if (frmTigre.ShowDialog() == DialogResult.OK)
                    {
                        if (this.baseDatos)
                        {
                            try
                            {
                                if (this.ado.EliminarDato(this.listaTigres[elIntTigre]))
                                {
                                    this.refugioHP.Animales -= this.listaTigres[elIntTigre];
                                    this.listaTigres -= this.listaTigres[elIntTigre];
                                }
                            }
                            catch(ExcepcionBD excBD)
                            {
                                MessageBox.Show(excBD.Message);
                            }
                        }
                        else
                        {
                            this.refugioHP.Animales -= this.listaTigres[elIntTigre];
                            this.listaTigres -= this.listaTigres[elIntTigre];
                        }
                        this.t = Task.Run(() => ActualizarVisor());
                    }
                }
                else
                {
                    MessageBox.Show("ERROR,No se selecciono ningun item", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                elIntPerro = -1;
                elIntGato = -1;
                elIntTigre = -1;
            }
            else
            {
                MessageBox.Show($"SU PERFIL DE {this.usuarioIngresado.perfil} NO TIENE PERMISO PARA ELIMINAR UN ITEM", "ERROR DE PERMISOS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        #endregion

        /// <summary>
        /// este metodo permite que cuando el usuario apreta el boton para cerrar el programa, este muestre
        /// un mensaje en donde le vuelva a preguntar si desea cerrarlo o no.
        /// </summary>
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cerrar el sistema?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }



        /// <summary>
        /// metodos para que el usuario pueda elegir donde abrir y guardar sus archivos xml
        /// el archivo serializado y deserializar el archivo que quiera ya sea de perros,gatos o tigres 
        /// en formato XML.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region XML

        public void SerializarXMLPerro(object sender, EventArgs e)
        {
            string nombreArchivo;
            if (saveFileDialogXmlP.ShowDialog() == DialogResult.OK)
            {
                if (this.listaPerros.Count > 0)
                {
                    nombreArchivo = saveFileDialogXmlP.FileName;
                    GenericArchivos<Perro>.serializarArchivoXML(nombreArchivo, this.listaPerros);
                }
                else
                {
                    MessageBox.Show("Para serializar debe ingresar al menos un perro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void DeserializarXMLPerro(object sender, EventArgs e)
        {
            string nombreArchivo;
            if (openFileDialogXmlP.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    nombreArchivo = openFileDialogXmlP.FileName;
                    if (this.listaPerros.Count > 0)
                    {
                        foreach (Perro perrito in GenericArchivos<Perro>.deserializarArchivoXML(nombreArchivo))
                        {
                            this.listaPerros += perrito;
                        }
                    }
                    else
                    {
                        this.listaPerros = GenericArchivos<Perro>.deserializarArchivoXML(nombreArchivo);
                    }

                    this.t = Task.Run(() => ActualizarVisor());
                }
                catch (Exception exc)
                {
                    MessageBox.Show($"se ha producido una excepcion {exc.GetType()}");
                }
            }
        }
        public void SerializarXMLGato(object sender, EventArgs e)
        {
            string nombreArchivo;
            if (saveFileDialogXmlG.ShowDialog() == DialogResult.OK)
            {
                if (this.listaGatos.Count > 0)
                {
                    nombreArchivo = saveFileDialogXmlG.FileName;
                    GenericArchivos<Gato>.serializarArchivoXML(nombreArchivo, this.listaGatos);
                }
                else
                {
                    MessageBox.Show("Para serializar debe ingresar al menos un gato", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void DeserializarXMLGato(object sender, EventArgs e)
        {
            string nombreArchivo;
            if (openFileDialogXmlG.ShowDialog() == DialogResult.OK)
            {
                nombreArchivo = openFileDialogXmlG.FileName;

                if (this.listaGatos.Count > 0)
                {
                    foreach (Gato gatito in GenericArchivos<Gato>.deserializarArchivoXML(nombreArchivo))
                    {
                        this.listaGatos += gatito;
                    }
                }
                else
                {
                    this.listaGatos = GenericArchivos<Gato>.deserializarArchivoXML(nombreArchivo);
                }

                this.t = Task.Run(() => ActualizarVisor());
            }
        }
        public void SerializarXMLTigre(object sender, EventArgs e)
        {
            string nombreArchivo;
            if (saveFileDialogXmlT.ShowDialog() == DialogResult.OK)
            {
                if (this.listaTigres.Count > 0)
                {
                    nombreArchivo = saveFileDialogXmlT.FileName;
                    GenericArchivos<Tigre>.serializarArchivoXML(nombreArchivo, this.listaTigres);
                }
                else
                {
                    MessageBox.Show("Para serializar debe ingresar al menos un tigre", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void DeserializarXMLTigre(object sender, EventArgs e)
        {
            string nombreArchivo;
            if (openFileDialogXmlT.ShowDialog() == DialogResult.OK)
            {
                nombreArchivo = openFileDialogXmlT.FileName;
                if (this.listaTigres.Count > 0)
                {
                    foreach (Tigre tigre in GenericArchivos<Tigre>.deserializarArchivoXML(nombreArchivo))
                    {
                        this.listaTigres += tigre;
                    }
                }
                else
                {
                    this.listaTigres = GenericArchivos<Tigre>.deserializarArchivoXML(nombreArchivo);
                }

                this.t = Task.Run(() => ActualizarVisor());
            }
        }

        #endregion

        /// <summary>
        /// metodos para que el usuario pueda elegir donde abrir y guardar sus archivos json
        /// el archivo serializado y deserializar el archivo que quiera ya sea de perros,gatos o tigres 
        /// en formato XML.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        #region JSON
        public void SerializarJPerro(object sender, EventArgs e)
        {
            string nombreArchivo;
            if (saveFileDialogJsonP.ShowDialog() == DialogResult.OK)
            {
                if (this.listaPerros.Count > 0)
                {
                    nombreArchivo = saveFileDialogJsonG.FileName;
                    GenericArchivos<Perro>.serializarArchivoJSON(nombreArchivo, this.listaPerros);
                }
                else
                {
                    MessageBox.Show("Para serializar debe ingresar al menos un gato", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void DeserializarJPerro(object sender, EventArgs e)
        {
            string nombreArchivo;
            if (openFileDialogJsonP.ShowDialog() == DialogResult.OK)
            {
                nombreArchivo = openFileDialogJsonP.FileName;

                if (this.listaPerros.Count > 0)
                {
                    foreach (Perro perrito in GenericArchivos<Perro>.deserializarArchivoJSON(nombreArchivo))
                    {
                        this.listaPerros += perrito;
                    }
                }
                else
                {
                    this.listaPerros = GenericArchivos<Perro>.deserializarArchivoJSON(nombreArchivo);
                }

                this.t = Task.Run(() => ActualizarVisor());
            }
        }
        public void SerializarJGato(object sender, EventArgs e)
        {
            string nombreArchivo;
            if (saveFileDialogJsonG.ShowDialog() == DialogResult.OK)
            {
                if (this.listaGatos.Count > 0)
                {
                    nombreArchivo = saveFileDialogJsonG.FileName;
                    GenericArchivos<Gato>.serializarArchivoJSON(nombreArchivo, this.listaGatos);
                }
                else
                {
                    MessageBox.Show("Para serializar debe ingresar al menos un gato", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void DeserializarJGato(object sender, EventArgs e)
        {
            string nombreArchivo;
            if (openFileDialogJsonG.ShowDialog() == DialogResult.OK)
            {
                nombreArchivo = openFileDialogJsonG.FileName;
                if (this.listaGatos.Count > 0)
                {
                    foreach (Gato gatito in GenericArchivos<Gato>.deserializarArchivoJSON(nombreArchivo))
                    {
                        this.listaGatos += gatito;
                    }
                }
                else
                {
                    this.listaGatos = GenericArchivos<Gato>.deserializarArchivoJSON(nombreArchivo);
                }
                this.t = Task.Run(() => ActualizarVisor());
            }
        }
        public void SerializarJTigre(object sender, EventArgs e)
        {
            string nombreArchivo;
            if (saveFileDialogJsonT.ShowDialog() == DialogResult.OK)
            {
                if (this.listaTigres.Count > 0)
                {
                    nombreArchivo = saveFileDialogJsonT.FileName;
                    GenericArchivos<Tigre>.serializarArchivoJSON(nombreArchivo, this.listaTigres);
                }
                else
                {
                    MessageBox.Show("Para serializar debe ingresar al menos un tigre", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void DeserializarJTigre(object sender, EventArgs e)
        {
            string nombreArchivo;
            if (openFileDialogJsonT.ShowDialog() == DialogResult.OK)
            {
                nombreArchivo = openFileDialogJsonT.FileName;
                if (this.listaTigres.Count > 0)
                {
                    foreach (Tigre tigre in GenericArchivos<Tigre>.deserializarArchivoJSON(nombreArchivo))
                    {
                        this.listaTigres += tigre;
                    }
                }
                else
                {
                    this.listaTigres = GenericArchivos<Tigre>.deserializarArchivoJSON(nombreArchivo);
                }
                this.t = Task.Run(() => ActualizarVisor());
            }
        }
        #endregion

        /// <summary>
        /// metodos para que el usuario pueda elegir donde abrir y guardar sus bases de datos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        #region BASE DE DATOS

        // ABRIR BASE DE DATOS
        private async void abrirBaseDatos(object sender,EventArgs e)
        {
            this.refugioHP.Animales = await this.ado.ObtenerListaDato();
            this.dividirListaGeneral(this.refugioHP.Animales);
            this.t = Task.Run(() => ActualizarVisor());
        }


        // GUARDAR BASE DE DATOS DE PERRO
        private async void pERROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Perro p in this.listaPerros)
            {
                if (await this.ado.existeAnimalEnBD(p) == false)
                {
                    if(this.ado.AgregarDato(p))
                    {
                        i++;
                    }

                }
            }
            if(i == this.listaPerros.Count)
            {
                MessageBox.Show("Datos agregados exitosamente a la base de datos","OPERACION EXITOSA",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if (i < this.listaGatos.Count && i != 0)
            {
                MessageBox.Show($"Se agregaron {i} perros y los otros {this.listaPerros.Count - i} no se agregaron por que ya estaban en la base de datos");
            }
            else if (i == 0)
            {
                MessageBox.Show("Todos los items de la lista de perros ya se encuentran en la base de datos");
            }
        }

        // GUARDAR BASE DE DATOS DE GATO
        private async void gATOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Gato g in this.listaGatos)
            {
                if (await this.ado.existeAnimalEnBD(g) == false)
                {
                    if(this.ado.AgregarDato(g))
                    {
                        i++;
                    }
                }

            }
            if(i == this.listaGatos.Count)
            {
                MessageBox.Show("todos los gatos fueron agregados exitosamente a la base de datos", "OPERACION EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(i < this.listaGatos.Count && i != 0)
            {
                MessageBox.Show($"Se agregaron {i} gatos y los otros {this.listaGatos.Count - i} no se agregaron por que ya estaban en la base de datos");
            }
            else if(i == 0)
            {
                MessageBox.Show("Todos los items de la lista de gatos ya se encuentran en la base de datos");
            }

        }

        // GUARDAR BASE DE DATOS DE TIGRE
        private async void tIGREToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                foreach (Tigre t in this.listaTigres)
                {
                    if (await this.ado.existeAnimalEnBD(t) == false)
                    {

                        if(this.ado.AgregarDato(t))
                        {
                            i++;
                        }
                    }
                }
            }catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


            if(i == this.listaTigres.Count)
            {
                MessageBox.Show("todos los tigres agregados exitosamente a la base de datos","OPERACION EXITOSA",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if (i < this.listaGatos.Count && i != 0)
            {
                MessageBox.Show($"Se agregaron {i} tigres y los otros {this.listaTigres.Count - i} no se agregaron por que ya estaban en la base de datos");
            }
            else if (i == 0)
            {
                MessageBox.Show("Todos los items de la lista de tigres ya se encuentran en la base de datos");
            }
        }

        #endregion


        //metodos para ordenar lista de perros
        #region Metodos de orden Perros
        private void EdadOrdenarAscP_Click(object sender, EventArgs e)
        {
            try
            {
                this.listaPerros = frmPerro.organizarPorEdadASC(this.listaPerros);
                this.t = Task.Run(() => ActualizarVisor());
            }
            catch (ExcepcionsListas exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void EdadOrdenarDesP_Click(object sender, EventArgs e)
        {
            try
            {
                this.listaPerros = frmPerro.organizarPorEdadDES(this.listaPerros);
                this.t = Task.Run(() => ActualizarVisor());
            }
            catch (ExcepcionsListas exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void NOMBREordenarAscP_Click(object sender, EventArgs e)
        {
            try
            {
                this.listaPerros = frmPerro.organizarPorNombreASC(this.listaPerros);
                this.t = Task.Run(() => ActualizarVisor());
            }
            catch (ExcepcionsListas exc)
            {
                MessageBox.Show(exc.Message);

            }
        }

        private void NOMBREordenarDesP_Click(object sender, EventArgs e)
        {
            try
            {
                this.listaPerros = frmPerro.organizarPorNombreDES(this.listaPerros);
                this.t = Task.Run(() => ActualizarVisor());
            }
            catch (ExcepcionsListas exc)
            {
                MessageBox.Show(exc.Message);

            }

        }
        #endregion
        //metodos para ordenar lista de gatos
        #region Metodos de orden Gatos
        private void EdadOrdenarAscG_Click(object sender, EventArgs e)
        {
            try
            {
                this.listaGatos = frmGato.organizarPorEdadASC(this.listaGatos);
                this.t = Task.Run(() => ActualizarVisor());
            }
            catch (ExcepcionsListas exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void EdadOrdenarDesG_Click(object sender, EventArgs e)
        {
            try
            {
                this.listaGatos = frmGato.organizarPorEdadDES(this.listaGatos);
                this.t = Task.Run(() => ActualizarVisor());
            }
            catch (ExcepcionsListas exc)
            {
                MessageBox.Show(exc.Message);

            }
        }

        private void NOMBREordenarAscG_Click(object sender, EventArgs e)
        {
            try
            {
                this.listaGatos = frmGato.organizarPorNombreASC(this.listaGatos);
                this.t = Task.Run(() => ActualizarVisor());
            }
            catch (ExcepcionsListas exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void NOMBREordenarDesG_Click(object sender, EventArgs e)
        {
            try
            {
                this.listaGatos = frmGato.organizarPorNombreDES(this.listaGatos);
                this.t = Task.Run(() => ActualizarVisor());
            }
            catch (ExcepcionsListas exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        #endregion

        //metodos para ordenar lista de tigres
        #region Metodos de orden Tigres
        private void EdadOrdenarAscT_Click(object sender, EventArgs e)
        {
            try
            {
                this.listaTigres = frmTigre.organizarPorEdadASC(this.listaTigres);
                this.t = Task.Run(() => ActualizarVisor());
            }
            catch (ExcepcionsListas exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void EdadOrdenarDesT_Click(object sender, EventArgs e)
        {
            try
            {
                this.listaTigres = frmTigre.organizarPorEdadDES(this.listaTigres);
                this.t = Task.Run(() => ActualizarVisor());
            }
            catch (ExcepcionsListas exc)
            {
                MessageBox.Show(exc.Message);
            }


        }

        private void NOMBREordenarAscT_Click(object sender, EventArgs e)
        {
            try
            {
                this.listaTigres = frmTigre.organizarPorNombreASC(this.listaTigres);
                this.t = Task.Run(() => ActualizarVisor());
            }
            catch (ExcepcionsListas exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void NOMBREordenarDesT_Click(object sender, EventArgs e)
        {
            try
            {
                this.listaTigres = frmTigre.organizarPorNombreDES(this.listaTigres);
                this.t = Task.Run(() => ActualizarVisor());
            }
            catch (ExcepcionsListas exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        #endregion



        /// <summary>
        /// este metodo permite al suaurio ingresar a la interfaz deel registro de usuarios logueados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegistroDeUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                this.frmRegistroU.usuariosLogueados = GenericArchivos<Usuario>.deserializarArchivoTexto("usuarios.log");
                this.frmRegistroU.visualizarLista();
                this.frmRegistroU.ShowDialog();
            }
            catch (ExcepcionsListas exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

    }

}
