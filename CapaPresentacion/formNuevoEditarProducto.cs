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
                this.cbEstadoProd.Visible = false;
                this.lblEstado.Visible = false;

                this.tbStock.Visible = false;
                this.lblStock.Visible = false;
            }
            else
            {
                this.lblEditarNuevo.Text = "Editar";
                // this.cbEstadoProd.Visible = ...valor traido de la BD...;
            }
            this.CargarProveedores();
            this.CargarCategorias();
        }
        // ==============================================
        //     Carga de proveedores y categorias
        // =============================================
        public void CargarProveedores()
        {
            this.cbProveedores.DataSource = objetoProv.DameNombresProveedores();
        }
        public void CargarCategorias()
        {
            this.cbCategorias.DataSource = objetoProd.DameNombresCategorias();
        }
        // ==============================================
        //     Boton GUARDAR
        // =============================================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
                try
                {
                    string rpta = "";
                    if (this.tbProducto.Text == string.Empty )
                    {
                        MensajeError("Falta ingresar algunos datos");
                    }
                    else
                    {
                        if (this.esNuevo)
                        {
                            rpta = CN_Productos.Insertar(this.tbProducto.Text.Trim(),this.cbCategorias.Text , this.cbProveedores.Text , this.tbCodigo.Text.Trim(),
                                this.tbDescripcion.Text.Trim());
                        }
                        else
                        {
                            // rpta = CN_Productos.Editar(this.tbProducto.Text.Trim(), this.tbCodigo.Text.Trim(), Convert.ToDecimal(this.tbPrecio.Text),
                            //     this.lbDescripcion.Text.Trim(),this.estadoProd);
                        }

                        if (rpta.Equals("OK"))
                        {
                            if (this.esNuevo)
                            {
                                this.MensajeOk("Se Insertó de forma correcta el registro");
                            }
                            else
                            {
                                this.MensajeOk("Se Actualizó de forma correcta el registro");
                            }
                        }
                        else
                        {
                            this.MensajeError(rpta);
                        }
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
        }
        // ==============================================
        //      Mensajes
        // =============================================
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Caetano", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Caetano", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
