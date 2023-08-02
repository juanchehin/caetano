using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Clientes
    {
        private int _IdCliente;
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


        public int IdCliente { get => _IdCliente; set => _IdCliente = value; }
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
        public CD_Clientes()
        {

        }

        public CD_Clientes(int IdCliente,string Apellidos, string Nombres,string DNI,string FechaNac,string FechaAlta,
            string Email,string Telefono,string Direccion, string Ciudad,string Provincia,string Sexo, string Comentarios)
        {            
            this.IdCliente = IdCliente;
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

        // ==================================================
        //  Carga los clientes de la BD con la opcion de incluye bajas
        // ==================================================
        public DataTable DameClientes(bool incluyeBajas)
        {
            Console.WriteLine("incluyeBajas en capa datos es : " + incluyeBajas);
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_clientes";

            MySqlParameter pincluyeBajas = new MySqlParameter();
            pincluyeBajas.ParameterName = "@pincluyeBajas";
            pincluyeBajas.MySqlDbType = MySqlDbType.Int32;
            // pIdProducto.Size = 60;
            pincluyeBajas.Value = incluyeBajas;
            comando.Parameters.Add(pincluyeBajas);

            tabla.Clear();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            comando.Parameters.Clear();
            conexion.CerrarConexion();
            return tabla;

        }
        // ==================================================
        //  Devuelve un cliente dado su ID
        // ==================================================
        public DataTable MostrarCliente(int IdCliente)
        {
            //Console.WriteLine("IdCliente en capa datos es : " + IdCliente);
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
        // ==================================================
        //  Edita un cliente dado su ID
        // ==================================================
        public string Editar(CD_Clientes Cliente)
        {
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

                MySqlParameter pApellidos = new MySqlParameter();
                pApellidos.ParameterName = "@pApellidos";
                pApellidos.MySqlDbType = MySqlDbType.VarChar;
                pApellidos.Size = 60;
                pApellidos.Value = Cliente.Apellidos;
                comando.Parameters.Add(pApellidos);

                MySqlParameter pNombres = new MySqlParameter();
                pNombres.ParameterName = "@pNombres";
                pNombres.MySqlDbType = MySqlDbType.VarChar;
                pNombres.Size = 30;
                pNombres.Value = Cliente.Nombres;
                comando.Parameters.Add(pNombres);

                MySqlParameter pDNI = new MySqlParameter();
                pDNI.ParameterName = "@pDNI";
                pDNI.MySqlDbType = MySqlDbType.VarChar;
                pDNI.Size = 15;
                pDNI.Value = Cliente.DNI;
                comando.Parameters.Add(pDNI);

                MySqlParameter pFechaNac = new MySqlParameter();
                pFechaNac.ParameterName = "@pFechaNac";
                pFechaNac.MySqlDbType = MySqlDbType.Date;
                pFechaNac.Size = 15;
                pFechaNac.Value = Cliente.FechaNac;
                comando.Parameters.Add(pFechaNac);

                MySqlParameter pEmail = new MySqlParameter();
                pEmail.ParameterName = "@pEmail";
                pEmail.MySqlDbType = MySqlDbType.VarChar;
                pEmail.Size = 50;
                pEmail.Value = Cliente.Email;
                comando.Parameters.Add(pEmail);

                MySqlParameter pTelefono = new MySqlParameter();
                pTelefono.ParameterName = "@pTelefono";
                pTelefono.MySqlDbType = MySqlDbType.VarChar;
                pTelefono.Size = 15;
                pTelefono.Value = Cliente.Telefono;
                comando.Parameters.Add(pTelefono);

                MySqlParameter pDireccion = new MySqlParameter();
                pDireccion.ParameterName = "@pDireccion";
                pDireccion.MySqlDbType = MySqlDbType.VarChar;
                pDireccion.Size = 45;
                pDireccion.Value = Cliente.Direccion;
                comando.Parameters.Add(pDireccion);

                MySqlParameter pCiudad = new MySqlParameter();
                pCiudad.ParameterName = "@pCiudad";
                pCiudad.MySqlDbType = MySqlDbType.VarChar;
                pCiudad.Size = 45;
                pCiudad.Value = Cliente.Ciudad;
                comando.Parameters.Add(pCiudad);

                MySqlParameter pProvincia = new MySqlParameter();
                pProvincia.ParameterName = "@pProvincia";
                pProvincia.MySqlDbType = MySqlDbType.VarChar;
                pProvincia.Size = 45;
                pProvincia.Value = Cliente.Provincia;
                comando.Parameters.Add(pProvincia);

                MySqlParameter pSexo = new MySqlParameter();
                pSexo.ParameterName = "@pSexo";
                pSexo.MySqlDbType = MySqlDbType.VarChar;
                pSexo.Size = 1;
                pSexo.Value = Cliente.Sexo;
                comando.Parameters.Add(pSexo);

                MySqlParameter pComentarios = new MySqlParameter();
                pComentarios.ParameterName = "@pComentarios";
                pComentarios.MySqlDbType = MySqlDbType.VarChar;
                pComentarios.Size = 255;
                pComentarios.Value = Cliente.Comentarios;
                comando.Parameters.Add(pComentarios);
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
        // ==================================================
        //  Inserta un cliente dado sus datos
        // ==================================================
        public string Insertar(CD_Clientes Cliente)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_cliente";

                MySqlParameter pApellidos = new MySqlParameter();
                pApellidos.ParameterName = "@pApellidos";
                pApellidos.MySqlDbType = MySqlDbType.VarChar;
                pApellidos.Size = 60;
                pApellidos.Value = Cliente.Apellidos;
                comando.Parameters.Add(pApellidos);

                MySqlParameter pNombres = new MySqlParameter();
                pNombres.ParameterName = "@pNombres";
                pNombres.MySqlDbType = MySqlDbType.VarChar;
                pNombres.Size = 60;
                pNombres.Value = Cliente.Nombres;
                comando.Parameters.Add(pNombres);

                MySqlParameter pDNI = new MySqlParameter();
                pDNI.ParameterName = "@pDNI";
                pDNI.MySqlDbType = MySqlDbType.VarChar;
                pDNI.Size = 12;
                pDNI.Value = Cliente.DNI;
                comando.Parameters.Add(pDNI);

                MySqlParameter pFechaNac = new MySqlParameter();
                pFechaNac.ParameterName = "@pFechaNac";
                pFechaNac.MySqlDbType = MySqlDbType.VarChar;
                pFechaNac.Size = 60;
                pFechaNac.Value = Cliente.FechaNac;
                comando.Parameters.Add(pFechaNac);

                MySqlParameter pEmail = new MySqlParameter();
                pEmail.ParameterName = "@pEmail";
                pEmail.MySqlDbType = MySqlDbType.VarChar;
                pEmail.Size = 60;
                pEmail.Value = Cliente.Email;
                comando.Parameters.Add(pEmail);

                MySqlParameter pTelefono = new MySqlParameter();
                pTelefono.ParameterName = "@pTelefono";
                pTelefono.MySqlDbType = MySqlDbType.VarChar;
                pTelefono.Size = 15;
                pTelefono.Value = Cliente.Telefono;
                comando.Parameters.Add(pTelefono);

                MySqlParameter pDireccion = new MySqlParameter();
                pDireccion.ParameterName = "@pDireccion";
                pDireccion.MySqlDbType = MySqlDbType.VarChar;
                pDireccion.Size = 60;
                pDireccion.Value = Cliente.Direccion;
                comando.Parameters.Add(pDireccion);

                MySqlParameter pCiudad= new MySqlParameter();
                pCiudad.ParameterName = "@pCiudad";
                pCiudad.MySqlDbType = MySqlDbType.VarChar;
                pCiudad.Size = 60;
                pCiudad.Value = Cliente.Ciudad;
                comando.Parameters.Add(pCiudad);

                MySqlParameter pProvincia = new MySqlParameter();
                pProvincia.ParameterName = "@pProvincia";
                pProvincia.MySqlDbType = MySqlDbType.VarChar;
                pProvincia.Size = 60;
                pProvincia.Value = Cliente.Provincia;
                comando.Parameters.Add(pProvincia);

                MySqlParameter pSexo = new MySqlParameter();
                pSexo.ParameterName = "@pSexo";
                pSexo.MySqlDbType = MySqlDbType.VarChar;
                pSexo.Size = 15;
                pSexo.Value = Cliente.Sexo;
                comando.Parameters.Add(pSexo);

                MySqlParameter pComentarios = new MySqlParameter();
                pComentarios.ParameterName = "@pComentarios";
                pComentarios.MySqlDbType = MySqlDbType.VarChar;
                pComentarios.Size = 255;
                pComentarios.Value = Cliente.Comentarios;
                comando.Parameters.Add(pComentarios);

                //Ejecutamos nuestro comando

                rpta = comando.ExecuteScalar().ToString() == "Ok" ? "OK" : "NO se Ingreso el Registro";

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception ex : " + ex.Message);
                rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return rpta;

        }

        // ==================================================
        //  Elimina un cliente dado su ID
        // ==================================================
        public string Eliminar(CD_Clientes Cliente)
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
                Console.WriteLine("");
            }
            finally
            {
                //if (conexion. == ConnectionState.Open) 
                conexion.CerrarConexion();
            }
            return rpta;
        }
        // ==================================================
        //  Busca un cliente dado un texto a buscar
        // ==================================================
        public DataTable BuscarCliente(CD_Clientes Cliente)
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
                comando.Parameters.Clear();
                conexion.CerrarConexion();

                // return tabla;
            }
            catch (Exception ex)
            {
                tabla = null;
            }
            return tabla;

        }
    }
}
