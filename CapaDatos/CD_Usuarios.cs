// Agregados
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Reflection.Emit;
// using System.Data.MySqlClient;


namespace CapaDatos
{
    public class CD_Usuarios
    {
        private int _IdUsuario;
        private string _Usuario;
        private string _FechaAlta;
        private string _FechaBaja;
        private string _Horario;
        private string _Password;
        private string _EstadoPer;

        private string _TextoBuscar;



        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string FechaAlta { get => _FechaAlta; set => _FechaAlta = value; }
        public string FechaBaja { get => _FechaBaja; set => _FechaBaja = value; }
        public string Horario { get => _Horario; set => _Horario = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string EstadoPer { get => _EstadoPer; set => _EstadoPer = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructores
        public CD_Usuarios()
        {

        }

        public CD_Usuarios(int IdUsuario, string Usuario,string FechaAlta,string FechaBaja,string Horario,string Password,string EstadoPer)
        {
            this.IdUsuario = IdUsuario;
            this.Usuario = Usuario;
            this.FechaAlta = FechaAlta;
            this.FechaBaja = FechaBaja;
            this.Horario = Horario;
            this.Password = Password;
            this.EstadoPer = EstadoPer;

            //            this.TextoBuscar = textobuscar;

        }

        // ==================================================
        //  Permite devolver todos los productos de la BD
        // ==================================================
        private CD_Conexion conexion = new CD_Conexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();
        public DataTable dameUsuarios()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_usuarios";

            tabla.Clear();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }
        /*
        // Devuelve un solo producto dado un ID
        public DataTable MostrarCorte(int IdCorte)
        {
            Console.WriteLine("IdProducto en capa datos es : " + IdProducto);
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_producto";

            MySqlParameter pIdProducto = new MySqlParameter();
            pIdProducto.ParameterName = "@pIdProducto";
            pIdProducto.MySqlDbType = MySqlDbType.Int32;
            // pIdProducto.Size = 60;
            pIdProducto.Value = IdProducto;
            comando.Parameters.Add(pIdProducto);

            leer = comando.ExecuteReader();
            tabla.Load(leer);
            Console.WriteLine("tabla en capa datos es : " + tabla);
            Console.WriteLine("leer en capa datos es : " + leer.ToString());
            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return tabla;

        }

        //Métodos
        //Insertar
        public string Insertar(CD_Cortes Corte)
        {
            string rpta = "";
            // SqlConnection SqlCon = new SqlConnection();
            try
            {

                Console.WriteLine("Producto es : " + Producto.Producto);

                //Código
                /*SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand(); */
        /*
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_producto";

                /*SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure; */
        /*

                MySqlParameter pProducto = new MySqlParameter();
                pProducto.ParameterName = "@pProducto";
                pProducto.MySqlDbType = MySqlDbType.VarChar;
                pProducto.Size = 60;
                pProducto.Value = Producto.Producto;
                comando.Parameters.Add(pProducto);

                MySqlParameter pPrecio = new MySqlParameter();
                pPrecio.ParameterName = "@pPrecio";
                pPrecio.MySqlDbType = MySqlDbType.Decimal;
                // pPrecio.Size = 30;
                pPrecio.Value = Producto.Precio;
                comando.Parameters.Add(pPrecio);

                MySqlParameter pStock = new MySqlParameter();
                pStock.ParameterName = "@pStock";
                pStock.MySqlDbType = MySqlDbType.Int16;
                pStock.Size = 40;
                pStock.Value = Producto.Stock;
                comando.Parameters.Add(pStock);

                MySqlParameter pEstadoProd = new MySqlParameter();
                pEstadoProd.ParameterName = "@pEstadoProd";
                pEstadoProd.MySqlDbType = MySqlDbType.VarChar;
                pEstadoProd.Size = 1;
                pEstadoProd.Value = Producto.EstadoProd;
                comando.Parameters.Add(pEstadoProd);

                MySqlParameter pObservaciones = new MySqlParameter();
                pObservaciones.ParameterName = "@pObservaciones";
                pObservaciones.MySqlDbType = MySqlDbType.VarChar;
                pObservaciones.Size = 255;
                pObservaciones.Value = Producto.Observaciones;
                comando.Parameters.Add(pObservaciones);


                Console.WriteLine("rpta es : " + rpta);

                // Console.WriteLine("el comando es : " + comando.CommandText[0]);
                //Ejecutamos nuestro comando

                // ExecuteNonQuery devuelve el numero de filas afectadas
                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Producto";
                comando.Parameters.Clear();

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
        public string Eliminar(CD_Productos Producto)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_eliminar_producto";

                MySqlParameter pIdProducto = new MySqlParameter();
                pIdProducto.ParameterName = "@pIdProducto";
                pIdProducto.MySqlDbType = MySqlDbType.Int32;
                // pIdEmpleado.Size = 60;
                pIdProducto.Value = Producto.IdProducto;
                comando.Parameters.Add(pIdProducto);

                //Ejecutamos nuestro comando

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Producto";

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
            comando.Parameters.Clear();
            return rpta;
        }
        // ===================================
        // Permite editar un producto
        // ===================================
        public string Editar(CD_Productos Producto)
        {
            Console.WriteLine("Produco.IdProducto es 1 : " + Producto.IdProducto);
            string rpta = "";
            comando.Parameters.Clear();// si no ponerlo al comienzo de esta funcion
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_editar_producto";

                MySqlParameter pIdProducto = new MySqlParameter();
                pIdProducto.ParameterName = "@pIdProducto";
                pIdProducto.MySqlDbType = MySqlDbType.Int32;
                // pIdEmpleado.Size = 60;
                pIdProducto.Value = Producto.IdProducto;
                comando.Parameters.Add(pIdProducto);

                Console.WriteLine("Produco.IdProducto es : " + Producto.IdProducto);

                MySqlParameter pProducto = new MySqlParameter();
                pProducto.ParameterName = "@pProducto";
                pProducto.MySqlDbType = MySqlDbType.VarChar;
                pProducto.Size = 60;
                pProducto.Value = Producto.Producto;
                comando.Parameters.Add(pProducto);

                MySqlParameter pPrecio = new MySqlParameter();
                pPrecio.ParameterName = "@pPrecio";
                pPrecio.MySqlDbType = MySqlDbType.Decimal;
                // pPrecio.Size = 30;
                pPrecio.Value = Producto.Precio;
                comando.Parameters.Add(pPrecio);

                MySqlParameter pStock = new MySqlParameter();
                pStock.ParameterName = "@pStock";
                pStock.MySqlDbType = MySqlDbType.Int16;
                pStock.Size = 40;
                pStock.Value = Producto.Stock;
                comando.Parameters.Add(pStock);

                MySqlParameter pEstadoProd = new MySqlParameter();
                pEstadoProd.ParameterName = "@pEstadoProd";
                pEstadoProd.MySqlDbType = MySqlDbType.VarChar;
                pEstadoProd.Size = 1;
                pEstadoProd.Value = Producto.EstadoProd;
                comando.Parameters.Add(pEstadoProd);

                MySqlParameter pObservaciones = new MySqlParameter();
                pObservaciones.ParameterName = "@pObservaciones";
                pObservaciones.MySqlDbType = MySqlDbType.VarChar;
                pObservaciones.Size = 255;
                pObservaciones.Value = Producto.Observaciones;
                comando.Parameters.Add(pObservaciones);

                // Console.WriteLine("comando.Executeexe() es : " + comando.ExecuteReader().ToString());

                //Console.WriteLine("comando.ExecuteScalar().ToString() es : " + comando.ExecuteScalar().ToString());

                //Ejecutamos nuestro comando

                rpta = comando.ExecuteScalar().ToString() == "Ok" ? "OK" : "No se edito el Producto";



            }
            catch (Exception ex)
            {

                rpta = ex.Message;
                Console.WriteLine("rpta es : " + rpta);
            }
            finally
            {
                //if (conexion. == ConnectionState.Open) 
                conexion.CerrarConexion();
            }
            comando.Parameters.Clear();
            return rpta;
        }
        */
        public string Login(string usuario,string pass)
        {
            string rpta = "";
            Console.WriteLine("usuario es : " + usuario);
            Console.WriteLine("pass es : " + pass);
            try
            {
                Console.WriteLine("usuario es : " + usuario);
                Console.WriteLine("pass es : " + pass);
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_login";

                MySqlParameter pUsuario = new MySqlParameter();
                pUsuario.ParameterName = "@pUsuario";
                pUsuario.MySqlDbType = MySqlDbType.VarChar;
                pUsuario.Size = 30;
                pUsuario.Value = usuario;
                comando.Parameters.Add(pUsuario);

                MySqlParameter pPassword = new MySqlParameter();
                pPassword.ParameterName = "@pPassword";
                pPassword.MySqlDbType = MySqlDbType.VarChar;
                pPassword.Size = 35;
                pPassword.Value = pass;
                comando.Parameters.Add(pPassword);

                rpta = comando.ExecuteScalar().ToString() == "Ok" ? "Ok" : "Error de credenciales";

            }
            catch (Exception ex)
            {

                rpta = ex.Message;
                Console.WriteLine("rpta es : " + rpta);
            }
            finally
            {
                //if (conexion. == ConnectionState.Open) 
                conexion.CerrarConexion();
            }
            comando.Parameters.Clear();
            return rpta;

        }
    }
}
