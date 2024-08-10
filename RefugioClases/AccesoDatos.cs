using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioClases
{
    public class AccesoDatos
    {
        private static string cadena_conexion;
        private SqlConnection conexion;
        private SqlCommand? comando;
        private SqlDataReader? lector;

        static AccesoDatos()
        {
            AccesoDatos.cadena_conexion = "Data Source=DESKTOP-DUJQPTJ\\SQLEXPRESS;Initial Catalog=Refugio;Integrated Security=True;Trust Server Certificate=True";
        }

        public AccesoDatos()
        {
            // CREO UN OBJETO SQLCONECTION
            this.conexion = new SqlConnection(AccesoDatos.cadena_conexion);
        }

        /// <summary>
        /// comprobar que la conexion con la base de datos fue exitosa
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ProbarConexion()
        {
            bool rtaF = await Task.Run(() => { 
                    bool rta = true;

                    try
                    {
                        this.conexion.Open();
                    }
                    catch (Exception exc)
                    {
                        rta = false;
                        throw new ExcepcionBD();
                    }
                    finally
                    {
                        if (this.conexion.State == ConnectionState.Open)
                        {
                            this.conexion.Close();
                        }
                    }

                return rta;
            
            });
            return rtaF;
        }

        public async Task<List<Animal>> ObtenerListaDato()
        {
            List<Animal> lista = await Task.Run(() => { 
                List<Animal> listaAnimalesAux = new();
                try
                {
                    this.comando = new SqlCommand();
                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = "SELECT * FROM Animales ";
                    this.comando.Connection = conexion;
                    conexion.Open();
                    this.lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        if (!(lector["raza"] is DBNull) && !(lector["tamanio"] is DBNull))
                        {
                            Perro item = new Perro();
                            item.Nombre = (string)lector["nombre"];
                            item.ColorOjos = (string)lector["colorOjos"];
                            item.Edad = (int)lector["edad"];
                            item.Peso = (double)lector["peso"];
                            item.Sexo = (ESexo)lector["sexo"];
                            item.Raza = (string)lector["raza"];
                            item.Tamanio = (Etamanio)lector["tamanio"];
                            listaAnimalesAux += item;
                        }     
                    
                        if (!(lector["razaGatos"] is DBNull) && !(lector["esDomestico"] is DBNull) && !(lector["comportamiento"] is DBNull))
                        {
                            Gato item = new Gato();
                            item.Nombre = (string)lector["nombre"];
                            item.ColorOjos = (string)lector["colorOjos"];
                            item.Edad = (int)lector["edad"];
                            item.Peso = (double)lector["peso"];
                            item.Sexo = (ESexo)lector["sexo"];
                            item.RazaGatos = (ERazaGatos)lector["razaGatos"];
                            item.EsDomestico = (bool)lector["esDomestico"];
                            item.Comportamiento = (string)lector["comportamiento"];
                            listaAnimalesAux += item;
                        }
                        if (!(lector["subEspecie"] is DBNull) && !(lector["habitat"] is DBNull))
                        {
                            Tigre item = new Tigre();
                            item.Nombre = (string)lector["nombre"];
                            item.ColorOjos = (string)lector["colorOjos"];
                            item.Edad = (int)lector["edad"];
                            item.Peso = (double)lector["peso"];
                            item.Sexo = (ESexo)lector["sexo"];
                            item.SubEspecie = (EsubEspecie)lector["subEspecie"];
                            item.Habitat = (string)lector["habitat"];
                            listaAnimalesAux += item;
                        }
                    }

                    lector.Close();
                }
                catch (Exception ex)
                {
                    throw new ExcepcionBD($"no se pudieron extraer todos los datos ",ex);
                }
                finally
                {
                    if (conexion.State == ConnectionState.Open)
                    {
                        conexion.Close();
                    }
                }

                return listaAnimalesAux;
            });
            return lista;
        }

        public bool AgregarDato(Animal param)
        {
            bool rta = true;
            string sql = " ";
            try
            {
                this.comando = new SqlCommand();
                if (param is Perro)
                {
                    agregarParametrosPerro((Perro)param);
                    sql = "INSERT INTO Animales (nombre, colorOjos, edad,peso,sexo,raza,tamanio) VALUES(";
                    sql += "@nombre1 , @colorOjos1 , @edad1 , @peso1 , @sexo1 , @raza1 , @tamanio1)";

                }
                else if(param is Gato)
                {
                    agregarParametrosGato((Gato)param);
                    sql = "INSERT INTO Animales (nombre, colorOjos, edad,peso,sexo,razaGatos,esDomestico,comportamiento) VALUES(";
                    sql += "@nombre1 , @colorOjos1 , @edad1 , @peso1, @sexo1 , @razaGatos1 , @esDomestico1 , @comportamiento1)";
                }
                else if(param is Tigre)
                {
                    agregarParametrosTigre((Tigre)param);
                    sql = "INSERT INTO Animales (nombre, colorOjos, edad,peso,sexo,subEspecie,habitat) VALUES(";
                    sql += "@nombre1 , @colorOjos1 , @edad1 , @peso1 , @sexo1 , @subEspecie1, @habitat1)";

                }

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = conexion;
                conexion.Open();

                if (this.comando.ExecuteNonQuery() == 0)
                {
                    rta = false;
                }

            }
            catch (ExcepcionBD excBD)
            {
                rta = false;
                throw new ExcepcionBD("no se pudo agregar el animal");
            }
            catch (Exception exc)
            {
                rta = false;
                throw new ExcepcionBD($"no se pudo agregar el animal por que surgio otro tipo de excepcion {exc.Message}", exc);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return rta;
        }

        public bool ModificarDato(Animal paramOriginal, Animal paramNuevo)
        {
            bool rta = true;
            string sql = " ";

            try
            {
                this.comando = new SqlCommand();
                if (paramNuevo is Perro)
                {
                    agregarParametrosPerro((Perro)paramNuevo,1);
                    agregarParametrosPerro((Perro)paramOriginal,2);
                    sql = "UPDATE Animales ";
                    sql += "SET nombre = @nombre1, colorOjos = @colorOjos1, edad = @edad1, peso = @peso1, sexo = @sexo1, raza = @raza1, tamanio = @tamanio1 ";
                    sql += "WHERE nombre = @nombre2 AND colorOjos = @colorOjos2 AND edad = @edad2 AND peso = @peso2 AND sexo = @sexo2 AND raza = @raza2 AND tamanio = @tamanio2";
                }
                else if(paramNuevo is Gato)
                {
                    agregarParametrosGato((Gato)paramNuevo,1);
                    sql = "UPDATE Animales ";
                    sql += "SET nombre = @nombre1, colorOjos = @colorOjos1, edad = @edad1, peso = @peso1, sexo = @sexo1, razaGatos = @razaGatos1, esDomestico = @esDomestico1, comportamiento = @comportamiento1 ";
                    agregarParametrosGato((Gato)paramOriginal,2);
                    sql += "WHERE nombre = @nombre2 AND colorOjos = @colorOjos2 AND edad = @edad2 AND peso = @peso2 AND sexo = @sexo2 AND razaGatos = @razaGatos2 AND esDomestico = @esDomestico2 AND comportamiento = @comportamiento2";
                }
                else if(paramNuevo is Tigre)
                {
                    agregarParametrosTigre((Tigre)paramNuevo,1);
                    agregarParametrosTigre((Tigre)paramOriginal,2);
                    sql = "UPDATE Animales ";
                    sql += "SET nombre = @nombre1, colorOjos = @colorOjos1, edad = @edad1, peso = @peso1, sexo = @sexo1, subEspecie = @subEspecie1, habitat = @habitat1 ";
                    sql += "WHERE nombre = @nombre2 AND colorOjos = @colorOjos2 AND edad = @edad2 AND peso = @peso2 AND sexo = @sexo2 AND subEspecie = @subEspecie2 AND habitat = @habitat2";
                }
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = conexion;

                conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (ExcepcionBD excBD)
            {
                rta = false;
                throw new ExcepcionBD("no se pudo modificar el animal");
            }
            catch (Exception exc)
            {
                rta = false;
                throw new ExcepcionBD($"no se pudo modificar el animal por que surgio otro tipo de excepcion {exc.Message}", exc);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return rta;
        }

        public bool EliminarDato(Animal param)
        {
            bool rta = true;
            string sql = " ";
            try
            {
                this.comando = new SqlCommand();

                if(param is Perro)
                {
                    agregarParametrosPerro((Perro)param);
                    sql = "DELETE FROM Animales WHERE nombre = @nombre1 AND colorOjos = @colorOjos1 AND edad = @edad1 AND peso = @peso1 AND sexo = @sexo1 AND raza = @raza1 AND tamanio = @tamanio1";
                }
                else if(param is Gato)
                {
                    agregarParametrosGato((Gato)param);
                    sql = "DELETE FROM Animales WHERE nombre = @nombre1 AND colorOjos = @colorOjos1 AND edad = @edad1 AND peso = @peso1 AND sexo = @sexo1 AND razaGatos = @razaGatos1 AND esDomestico = @esDomestico1 AND comportamiento = @comportamiento1";
                }
                else if(param is Tigre)
                {
                    agregarParametrosTigre((Tigre)param);
                    sql = "DELETE FROM Animales WHERE nombre = @nombre1 AND colorOjos = @colorOjos1 AND edad = @edad1 AND peso = @peso1 AND sexo = @sexo1 AND subEspecie = @subEspecie1 AND habitat = @habitat1";
                }

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = conexion;

                conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (ExcepcionBD excBD)
            {
                rta = false;
                throw new ExcepcionBD("no se pudo eliminar al animal");
            }
            catch(Exception exc)
            {
                rta = false;
                throw new ExcepcionBD($"no se pudo eliminar al animal por que surgio otro tipo de excepcion {exc.Message}",exc);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return rta;
        }


        public void agregarParametrosPerro(Perro param,int num = 1)
        {
            comando.Parameters.AddWithValue($"@nombre{num}", param.Nombre);
            comando.Parameters.AddWithValue($"@colorOjos{num}", param.ColorOjos);
            comando.Parameters.AddWithValue($"@edad{num}", param.Edad);
            comando.Parameters.AddWithValue($"@peso{num}", param.Peso);
            comando.Parameters.AddWithValue($"@sexo{num}", (int)param.Sexo);
            comando.Parameters.AddWithValue($"@raza{num}", param.Raza);
            comando.Parameters.AddWithValue($"@tamanio{num}", (int)param.Tamanio);
        }

        public void agregarParametrosGato(Gato param,int num = 1)
        {
            comando.Parameters.AddWithValue($"@nombre{num}", param.Nombre);
            comando.Parameters.AddWithValue($"@colorOjos{num}", param.ColorOjos);
            comando.Parameters.AddWithValue($"@edad{num}", param.Edad);
            comando.Parameters.AddWithValue($"@peso{num}", param.Peso);
            comando.Parameters.AddWithValue($"@sexo{num}", (int)param.Sexo);
            comando.Parameters.AddWithValue($"@razaGatos{num}", (int)param.RazaGatos);
            comando.Parameters.AddWithValue($"@esDomestico{num}", param.EsDomestico.GetHashCode());
            comando.Parameters.AddWithValue($"@comportamiento{num}", param.Comportamiento);
        }

        public void agregarParametrosTigre(Tigre param, int num = 1)
        {
            comando.Parameters.AddWithValue($"@nombre{num}", param.Nombre);
            comando.Parameters.AddWithValue($"@colorOjos{num}", param.ColorOjos);
            comando.Parameters.AddWithValue($"@edad{num}", param.Edad);
            comando.Parameters.AddWithValue($"@peso{num}", param.Peso);
            comando.Parameters.AddWithValue($"@sexo{num}", (int)param.Sexo);
            comando.Parameters.AddWithValue($"@subEspecie{num}", (int)param.SubEspecie);
            comando.Parameters.AddWithValue($"@habitat{num}", param.Habitat);
        }

        public async Task<bool> existeAnimalEnBD(Animal a)
        {
            List<Perro> listaPerrosAux = new();
            List<Gato> listaGatosAux = new();
            List<Tigre> listaTigresAux = new();

            List<Animal> animales = new();

            animales = await this.ObtenerListaDato();

            bool rta = false;

            foreach (Animal ani in animales)
            {
                if (ani is Perro)
                {
                    listaPerrosAux += (Perro)ani;
                }
                else if (ani is Gato)
                {
                    listaGatosAux += (Gato)ani;
                }
                else if (ani is Tigre)
                {
                    listaTigresAux += (Tigre)ani;
                }
            }

            if (a is Perro)
            {
                foreach (Perro perroBD in listaPerrosAux)
                {
                    if ((Perro)a == perroBD)
                        rta = true;
                }

            }
            else if (a is Gato)
            {
                foreach (Gato gatoBD in listaGatosAux)
                {
                    if ((Gato)a == gatoBD)
                        rta = true;
                }
            }
            else if (a is Tigre)
            {
                foreach (Tigre perroBD in listaTigresAux)
                {
                    if ((Tigre)a == perroBD)
                        rta = true;
                }
            }
            return rta;
        }
    }
}
