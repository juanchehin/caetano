using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class formNuevoEditarProducto : Form
    {
        CN_Productos objetoProd = new CN_Productos();
        CN_Proveedores objetoProv = new CN_Proveedores();

        bool esNuevo = false;

        private int idProducto;
        private int idProveedor;
        private int idCategoria;
        private int codigo;
        private char producto;
        private decimal precio;
        private int stock;
        private char estadoProd;
        private char descripcion;
        public formNuevoEditarProducto(int pIdProducto,bool pEsNuevo)
        {
            InitializeComponent();
            this.esNuevo = pEsNuevo;
            this.idProducto = pIdProducto;
            if (pEsNuevo)
            {
                lblEditarNuevo.Text = "Nuevo";
            }
            else
            {
                this.lblEditarNuevo.Text = "Editar";
            }
            this.CargarProveedores();
            this.CargarCategorias();
        }
        public void CargarProveedores()
        {
            this.cbProveedores.DataSource = objetoProv.DameNombresProveedores();
        }
        public void CargarCategorias()
        {
            this.cbCategorias.DataSource = objetoProd.DameNombresCategorias();
        }
    }
}
