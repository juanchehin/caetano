using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;

namespace CapaNegocio
{
    public class CN_Clientes
    {
        private CD_Clientes objetoCD = new CD_Clientes();


        // ==================================================
        //Método Insertar que llama al método Insertar de la clase DArticulo
        //de la CapaDatos
        // ==================================================
        public static string Insertar(string Apellidos, string Nombres, string DNI,string FechaNac, string Email, string Telefono
            , string Direccion, string Ciudad, string Provincia, string Sexo, string Observaciones)
        {
            CD_Clientes Obj = new CD_Clientes();
            Obj.Apellidos = Apellidos;
            Obj.Nombres = Nombres;
            Obj.DNI = DNI;
            Obj.FechaNac = FechaNac;
            Obj.Email = Email;
            Obj.Telefono = Telefono;
            Obj.Direccion = Direccion;
            Obj.Ciudad = Ciudad;
            Obj.Provincia = Provincia;
            Obj.Sexo = Sexo;
            Obj.FechaNac = FechaNac;
            // Obj.EstadoPer = EstadoPer;
            Obj.Comentarios = Observaciones;

            return Obj.Insertar(Obj);
        }
        // ==================================================
        //  Muestra un cliente dado su ID
        // ==================================================
        public DataTable MostrarClientes(Boolean incluyeBajas)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.DameClientes(incluyeBajas);
            return tabla;
        }
        // ==================================================
        //  Elimina un cliente dado su ID
        // ==================================================
        public static string Eliminar(int IdCliente)
        {
            CD_Clientes Obj = new CD_Clientes();
            Obj.IdCliente = IdCliente;
            return Obj.Eliminar(Obj);
        }

        // ==================================================
        //  Devuelve un cliente dado su ID
        // ==================================================
        public DataTable MostrarCliente(int IdCliente)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarCliente(IdCliente);
            return tabla;
        }
        // ==================================================
        //  Edita un cliente
        // ==================================================
        public static string Editar(int IdCliente,string Apellidos, string Nombres, string DNI, string FechaNac, string Email, string Telefono
            , string Direccion, string Ciudad, string Provincia, string Sexo, string Observaciones)
        {
            
            CD_Clientes Obj = new CD_Clientes();
            Obj.IdCliente = IdCliente;

            Obj.Apellidos = Apellidos;
            Obj.Nombres = Nombres;
            Obj.DNI = DNI;
            Obj.FechaNac = FechaNac;
            Obj.Email = Email;
            Obj.Telefono = Telefono;
            Obj.Direccion = Direccion;
            Obj.Ciudad = Ciudad;
            Obj.Provincia = Provincia;
            Obj.Sexo = Sexo;
            Obj.FechaNac = FechaNac;
            // Obj.EstadoPer = EstadoPer;
            Obj.Comentarios = Observaciones;

            return Obj.Editar(Obj);
        }
        // ==================================================
        //  Busca un cliente
        // ==================================================
        public DataTable BuscarCliente(string textobuscar)
        {
            Console.WriteLine("textobuscar en capa negocio es : " + textobuscar);
            CD_Clientes Obj = new CD_Clientes();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarCliente(Obj);
        }
    }
}
