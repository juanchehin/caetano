// Agregados
using MySql.Data.MySqlClient;
using System;
using System.Data;
// using System.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
    public class CD_Productos
    {
        private int _IdProducto;
        private int _IdProveedor;
        private int _IdCategoria;
        private string _Producto;
        private string _Codigo;
        private decimal _Precio;
        private int _Stock;
        private string _EstadoProd;
        private string _Observaciones;

        private string _TextoBuscar;



        public int IdProducto { get => _IdProducto; set => _IdProducto = value; }
        public int IdProveedor { get => _IdProveedor; set => _IdProveedor = value; }
        public int IdCategoria { get => _IdCategoria; set => _IdCategoria = value; }
        public string Producto { get => _Producto; set => _Producto = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public decimal Precio { get => _Precio; set => _Precio = value; }
        public int Stock { get => _Stock; set => _Stock = value; }
        public string EstadoProd { get => _EstadoProd; set => _EstadoProd = value; }
        public string Observaciones { get => _Observaciones; set => _Observaciones = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructores
        public CD_Productos()
        {

        }

        public CD_Productos(int IdProducto,int IdProveedor,int IdCategoria, string Producto, string Codigo,decimal Precio,int Stock,string Observaciones,string EstadoProd, string textobuscar)
        {
            this.IdProducto = IdProducto;
            this.IdProveedor = IdProveedor;
            this.IdCategoria = IdCategoria;
            this.Producto = Producto;
            this.Codigo = Codigo;
            this.Precio = Precio;
            this.Stock = Stock;
            this.EstadoProd = EstadoProd;
            this.Observaciones = Observaciones;
            this.TextoBuscar = textobuscar;

        }

        // ==================================================
        //  Permite devolver todos los productos de la BD
        // ==================================================
        private CD_Conexion conexion = new CD_Conexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();
        List<string> categorias = new List<string>();

        public DataTable Mostrar()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_productos";

            tabla.Clear();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        // Devuelve un solo producto dado un ID
        public DataTable MostrarProducto(int IdProducto)
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
        // ==================================================
        //  Permite devolver solo los nombres de las CATEGORIAS dado
        //  para cargar en el combo box.
        // ==================================================
        public List<string> DameNombresCategorias()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_nombres_categorias";

            tabla.Clear();
            // leer = comando.ExecuteReader();
            // tabla.Load(leer);
            // Console.WriteLine("leer valor : " + leer);

            using (comando)
            {
                using (leer = comando.ExecuteReader())
                {
                    // Console.WriteLine("leer.Read() antes : " + leer.Read());
                    while (leer.Read())
                    {
                        for (int i = 0; i < leer.FieldCount; i++)
                        {
                            categorias.Add(Convert.ToString(leer.GetValue(i)));
                        }
                    }
                }
            }
            // string columna = leer["Proveedor"].

            // conexion.CerrarConexion();
            return categorias;

        }
        // ==================================================
        //  Permite insertar un producto
        // ==================================================
        public string Insertar(CD_Productos Producto)
        {
            string rpta = "";
            try
            {

                Console.WriteLine("Producto es : " + Producto.Producto);

                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_producto";

                MySqlParameter pIdProveedor = new MySqlParameter();
                pIdProveedor.ParameterName = "@pIdProveedor";
                pIdProveedor.MySqlDbType = MySqlDbType.Int32;
                pIdProveedor.Value = Producto.IdProveedor;
                comando.Parameters.Add(pIdProveedor);

                MySqlParameter pIdCategoria = new MySqlParameter();
                pIdCategoria.ParameterName = "@pIdCategoria";
                pIdCategoria.MySqlDbType = MySqlDbType.Int32;
                pIdCategoria.Value = Producto.IdCategoria;
                comando.Parameters.Add(pIdCategoria);

                MySqlParameter pProducto = new MySqlParameter();
                pProducto.ParameterName = "@pProducto";
                pProducto.MySqlDbType = MySqlDbType.VarChar;
                pProducto.Size = 60;
                pProducto.Value = Producto.Producto;
                comando.Parameters.Add(pProducto);

                MySqlParameter pCodigo = new MySqlParameter();
                pCodigo.ParameterName = "@pCodigo";
                pCodigo.MySqlDbType = MySqlDbType.Int32;
                pCodigo.Value = Producto.Codigo;
                comando.Parameters.Add(pCodigo);

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

                /*MySqlParameter pEstadoProd = new MySqlParameter();
                pEstadoProd.ParameterName = "@pEstadoProd";
                pEstadoProd.MySqlDbType = MySqlDbType.VarChar;
                pEstadoProd.Size = 1;
                pEstadoProd.Value = Producto.EstadoProd;
                comando.Parameters.Add(pEstadoProd);*/

                MySqlParameter pObservaciones = new MySqlParameter();
                pObservaciones.ParameterName = "@pObservaciones";
                pObservaciones.MySqlDbType = MySqlDbType.VarChar;
                pObservaciones.Size = 255;
                pObservaciones.Value = Producto.Observaciones;
                comando.Parameters.Add(pObservaciones);
                

                Console.WriteLine("rpta es : " + rpta );

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
        // ==================================================
        //  Permite eliminar un producto
        // ==================================================
        public string Eliminar(int IdProducto)
        {
            string rpta = "";
            Console.WriteLine("IdProducto en CD productos es _: " + IdProducto);
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_eliminar_producto";

                MySqlParameter pIdProducto = new MySqlParameter();
                pIdProducto.ParameterName = "@pIdProducto";
                pIdProducto.MySqlDbType = MySqlDbType.Int32;
                // pIdEmpleado.Size = 60;
                pIdProducto.Value = IdProducto;
                comando.Parameters.Add(pIdProducto);

                //Ejecutamos nuestro comando

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Producto";
                Console.WriteLine("rpta es : " + rpta);

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

        public DataTable BuscarProducto(CD_Productos Producto)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_buscar_producto";

                MySqlParameter pTextoBuscar = new MySqlParameter();
                pTextoBuscar.ParameterName = "@pTextoBuscar";
                pTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
                pTextoBuscar.Size = 30;
                pTextoBuscar.Value = Producto.TextoBuscar;
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

        }
    }
}
