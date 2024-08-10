using System.Text.Json;
using RefugioClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace RefugioForms
{
    public delegate void metodosInicializacion(Usuario usuario);
    public partial class FormLogin : Form
    {
        Task t;

        //lista de usuarios donde se guardaran los datos del archivo "MOCK_DATA.json"
        private List<Usuario> usuarios;

        private Usuario usuarioIngresado;


        private FormPrincipal frmPrinc;
        public FormLogin()
        {
            this.usuarios = new List<Usuario>();
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.buttonMostrar.Click += this.ocultarContraseña;
        }

        /// <summary>
        /// este metodo me permite ingresar al formulario 
        /// principal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button_ingresar_Click(object sender, EventArgs e)
        {

            this.usuarios = GenericArchivos<Usuario>.deserializarArchivoJSON("MOCK_DATA.json");

            if (await this.verificarUsuario())
            {
                this.frmPrinc = new FormPrincipal();

                if (MessageBox.Show("¿DESEA INICIALIZAR LA APP CON BASE DE DATOS? ( si apreta 'NO' se inicializara con archivos JSON )", "INICIALIZAR APP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmPrinc.baseDatos = true;
                }
                else
                {
                    frmPrinc.baseDatos = false;
                }

                metodosInicializacion metodos = this.AgregarIngresoARegistro;
                metodos += frmPrinc.AsignarPermisos;
                frmPrinc.inicializarDatos();
                this.t = Task.Run(()=>metodos?.Invoke(this.usuarioIngresado));
                this.t = Task.Run(()=> frmPrinc.MostrarUsuario(this.usuarioIngresado));
                Thread.Sleep(1000);
                frmPrinc.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("el correo o la contraseña ingresadas son incorrectas");
            }
        }
       
        /// <summary>
        /// agrega todos los ingresos de los usuarios, junto con la hora,minutos y segundos.
        /// </summary>
        /// <param name="usu"></param>
        public async void AgregarIngresoARegistro(Usuario usu)
        {
            using (StreamWriter usuariosLogueados = new StreamWriter("usuarios.log", append: true))
            {
                usuariosLogueados.WriteLine(usu);
                usuariosLogueados.Close();
            }
        }

        private void ocultarContraseña(object sender, EventArgs e)
        {
            if (this.textBox2.PasswordChar == '*')
            {
                this.textBox2.PasswordChar = '\0';
                this.buttonMostrar.Text = "OCULTAR";
            }
            else
            {
                this.textBox2.PasswordChar = '*';
                this.buttonMostrar.Text = "MOSTRAR";
            }
        }

        private async Task<bool> verificarUsuario()
        {
            bool verificacion = await Task.Run(() => {
                bool verificacionUsuario = false;

                string correo = this.textBox1.Text;
                string contra = this.textBox2.Text;
                foreach (Usuario data in this.usuarios)
                {
                    if (data.correo == correo && data.clave == contra)
                    {
                        verificacionUsuario = true;
                        this.usuarioIngresado = new Usuario(data.apellido, data.nombre, data.legajo, data.correo, data.clave, data.perfil);
                    }
                }
                return verificacionUsuario;            
            });
            return verificacion;
        }
    }
}
