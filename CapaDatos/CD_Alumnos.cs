using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Alumnos
    {
        private int _IdAlumno;
        private string _Apellidos;
        private string _Nombres;
        private string _DNI;
        private string _FechaNac;
        private string _FechaAlta;
        private string _Email;
        private string _Telefono;
        private string _Direccion;
        private string _Ciudad;
        private string _Provincia;
        private string _Sexo;
        private string _EstadoPer;
        private string _Comentarios;

        private string _TextoBuscar;


        public int IdAlumno { get => _IdAlumno; set => _IdAlumno = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string DNI { get => _DNI; set => _DNI = value; }
        public string FechaNac { get => _FechaNac; set => _FechaNac = value; }
        public string FechaAlta { get => _FechaAlta; set => _FechaAlta = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Ciudad { get => _Ciudad; set => _Ciudad = value; }
        public string Provincia { get => _Provincia; set => _Provincia = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public string EstadoPer { get => _EstadoPer; set => _EstadoPer = value; }
        public string Comentarios { get => _Comentarios; set => _Comentarios = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructores
        public CD_Alumnos()
        {

        }

        public CD_Alumnos(int IdAlumno, string Apellidos, string Nombres, string DNI, string FechaNac, string FechaAlta,
            string Email, string Telefono, string Direccion, string Ciudad, string Provincia, string Sexo, string Comentarios)
        {
            this.IdAlumno = IdAlumno;
            this.Apellidos = Apellidos;
            this.Nombres = Nombres;
            this.DNI = DNI;
            this.FechaNac = FechaNac;
            this.FechaAlta = FechaAlta;
            this.Email = Email;
            this.Telefono = Telefono;
            this.Direccion = Direccion;
            this.Ciudad = Ciudad;
            this.Provincia = Provincia;
            this.Sexo = Sexo;
            this.Comentarios = Comentarios;
        }

        // ==================================================
        //  Permite devolver todos los clientes activos de la BD
        // ==================================================
        private CD_Conexion conexion = new CD_Conexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();


        public DataTable DameAlumnos()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_alumnos";

            tabla.Clear();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        // devuelve solo 1 cliente de la BD
        /*public DataTable DameCortes(int IdCliente)
        {
            Console.WriteLine("IdCliente en capa datos es : " + IdCliente);
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_cliente";

            MySqlParameter pIdCliente = new MySqlParameter();
            pIdCliente.ParameterName = "@pIdCliente";
            pIdCliente.MySqlDbType = MySqlDbType.Int32;
            // pIdProducto.Size = 60;
            pIdCliente.Value = IdCliente;
            comando.Parameters.Add(pIdCliente);

            leer = comando.ExecuteReader();
            tabla.Load(leer);
            
            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return tabla;

        }

        public string Editar(CD_Cortes Cliente)
        {
            Console.WriteLine("Cliente.IdCliente es 1 : " + Cliente.IdCliente);
            string rpta = "";
            comando.Parameters.Clear();// si no ponerlo al comienzo de esta funcion
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_editar_cliente";

                MySqlParameter pIdCliente = new MySqlParameter();
                pIdCliente.ParameterName = "@pIdCliente";
                pIdCliente.MySqlDbType = MySqlDbType.Int32;
                // pIdEmpleado.Size = 60;
                pIdCliente.Value = Cliente.IdCliente;
                comando.Parameters.Add(pIdCliente);

                MySqlParameter pTransporte = new MySqlParameter();
                pTransporte.ParameterName = "@pTransporte";
                pTransporte.MySqlDbType = MySqlDbType.VarChar;
                pTransporte.Size = 60;
                pTransporte.Value = Cliente.Transporte;
                comando.Parameters.Add(pTransporte);

                MySqlParameter pTitular = new MySqlParameter();
                pTitular.ParameterName = "@pTitular";
                pTitular.MySqlDbType = MySqlDbType.VarChar;
                pTitular.Size = 30;
                pTitular.Value = Cliente.Titular;
                comando.Parameters.Add(pTitular);

                MySqlParameter pTelefono = new MySqlParameter();
                pTelefono.ParameterName = "@pTelefono";
                pTelefono.MySqlDbType = MySqlDbType.VarChar;
                pTelefono.Size = 15;
                pTelefono.Value = Cliente.Telefono;
                comando.Parameters.Add(pTelefono);

                rpta = comando.ExecuteScalar().ToString() == "Ok" ? "OK" : "No se edito el Registro";

            }
            catch (Exception ex)
            {

                rpta = ex.Message;
                Console.WriteLine("rpta es : " + rpta);
            }
            finally
            {
                conexion.CerrarConexion();
            }
            comando.Parameters.Clear();
            return rpta;
        }

        //Métodos
        //Insertar
        public string Insertar(CD_Cortes Cliente)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_cliente";

                MySqlParameter pTitular = new MySqlParameter();
                pTitular.ParameterName = "@pTitular";
                pTitular.MySqlDbType = MySqlDbType.VarChar;
                pTitular.Size = 60;
                pTitular.Value = Cliente.Titular;
                comando.Parameters.Add(pTitular);

                // Console.WriteLine("pNombre es : " + pNombre.Value);

                MySqlParameter pTransporte = new MySqlParameter();
                pTransporte.ParameterName = "@pTransporte";
                pTransporte.MySqlDbType = MySqlDbType.VarChar;
                pTransporte.Size = 60;
                pTransporte.Value = Cliente.Transporte;
                comando.Parameters.Add(pTransporte);

                MySqlParameter pTelefono = new MySqlParameter();
                pTelefono.ParameterName = "@pTelefono";
                pTelefono.MySqlDbType = MySqlDbType.VarChar;
                pTelefono.Size = 15;
                pTelefono.Value = Cliente.Telefono;
                comando.Parameters.Add(pTelefono);

                // Console.WriteLine("el comando es : " + comando.CommandText[0]);
                //Ejecutamos nuestro comando

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return rpta;

        }

        // Metodo ELIMINAR Empleado (da de baja)
        public string Eliminar(CD_Cortes Cliente)
        {
            string rpta = "";
            // SqlConnection SqlCon = new SqlConnection();
            try
            {

                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_eliminar_cliente";

                MySqlParameter pIdCliente = new MySqlParameter();
                pIdCliente.ParameterName = "@pIdCliente";
                pIdCliente.MySqlDbType = MySqlDbType.Int32;
                // pIdEmpleado.Size = 60;
                pIdCliente.Value = Cliente.IdCliente;
                comando.Parameters.Add(pIdCliente);

                //Ejecutamos nuestro comando

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //if (conexion. == ConnectionState.Open) 
                conexion.CerrarConexion();
            }
            return rpta;
        }

        public DataTable BuscarCliente(CD_Cortes Cliente)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_buscar_cliente";

                MySqlParameter pTextoBuscar = new MySqlParameter();
                pTextoBuscar.ParameterName = "@pTextoBuscar";
                pTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
                pTextoBuscar.Size = 30;
                pTextoBuscar.Value = Cliente.TextoBuscar;
                comando.Parameters.Add(pTextoBuscar);

                leer = comando.ExecuteReader();
                tabla.Load(leer);
                Console.WriteLine("tabla en capa datos es : " + tabla);
                Console.WriteLine("leer en capa datos es : " + leer.ToString());
                comando.Parameters.Clear();
                conexion.CerrarConexion();

                // return tabla;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Entro en el catch y tabla es en capa datos" + tabla);
                Console.WriteLine("Entro en el catch y ex es en capa datos" + ex.Message);

                tabla = null;
            }
            return tabla;

        }*/
    }
}
