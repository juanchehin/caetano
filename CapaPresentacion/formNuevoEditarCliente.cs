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
    public partial class formNuevoEditarClientes : Form
    {
        CN_Clientes objetoCN = new CN_Clientes();
        DataTable respuesta;
        // int parametroActual;
        bool bandera;
        bool IsNuevo = false;
        bool IsEditar = false;

        private int IdCliente;
        private string Apellidos;
        private string Nombres;
        private string DNI;
        private DateTime FechaNac;
        private string FechaAlta;   // No se modifica
        private string Email;
        private string Telefono;
        private string Direccion;
        private string Ciudad;
        private string Provincia;
        private string Sexo;
        private string EstadoPer;
        private string Observaciones;

        public formNuevoEditarClientes(int parametro, bool IsNuevoEditar)
        {
            InitializeComponent();
            this.IdCliente = parametro;
            this.bandera = IsNuevoEditar;
        }

        /*private void formNuevoEditarClientes_Load(object sender, EventArgs e)
        {
            
        }*/

        // Carga los valores en los campos de texto del formulario para que se modifiquen los que se desean
        private void MostrarCliente(int IdCliente)
        {
            respuesta = objetoCN.MostrarCliente(IdCliente);

            // Console.WriteLine("Respuesta es ; " + respuesta.Rows.Count);
            foreach (DataRow row in respuesta.Rows)
            {
                Console.WriteLine("row telefono es :" + row["Telefono"]);

                IdCliente = Convert.ToInt32(row["IdCliente"]);
                Apellidos = Convert.ToString(row["Apellidos"]);
                Nombres = Convert.ToString(row["Nombres"]);
                DNI = Convert.ToString(row["DNI"]);
                Email = Convert.ToString(row["Email"]);
                Telefono = Convert.ToString(row["Telefono"]);
                Direccion = Convert.ToString(row["Direccion"]);
                Ciudad = Convert.ToString(row["Ciudad"]);
                Provincia = Convert.ToString(row["Provincia"]);
                Sexo = Convert.ToString(row["Sexo"]);
                Observaciones = Convert.ToString(row["Observaciones"]);
                if (row["FechaNac"] == DBNull.Value)
                {
                    FechaNac = Convert.ToDateTime("2010-12-25");
                    dpFechaNac.Value = FechaNac;
                }
                else
                {
                    FechaNac = Convert.ToDateTime(row["FechaNac"]);
                    dpFechaNac.Value = FechaNac;

                }
                // FechaNac = Convert.ToString(row["FechaNac"]);


                txtApellidos.Text = Apellidos;
                txtNombres.Text = Nombres;
                txtDNI.Text = DNI;
                // dpFechaNac.Text = FechaNac;
                txtEmail.Text = Email;
                txtTelefono.Text = Telefono;
                txtDireccion.Text = Direccion;
                txtCiudad.Text = Ciudad;
                txtProvincia.Text = Provincia;
                cbSexo.Text = Sexo;
                rTextObservaciones.Text = Observaciones;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           /* try
            {
                string rpta = "";
                if (this.txtApellidos.Text == string.Empty || this.txtNombres.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = CN_Clientes.Insertar(this.txtApellidos.Text.Trim(), this.txtNombres.Text.Trim(), this.txtDNI.Text.Trim()
                            , this.FechaNac.Trim(), this.txtEmail.Text.Trim(), this.txtTelefono.Text.Trim(), this.txtDireccion.Text.Trim()
                            , this.txtCiudad.Text.Trim(), this.txtProvincia.Text.Trim(), this.cbSexo.Text.Trim(), this.rTextObservaciones.Text.Trim());
                    }
                    else
                    {
                        // rpta = CN_Clientes.Editar(this.IdCliente, this.txtTransporte.Text.Trim(), this.txtTitular.Text.Trim(), this.txtTelefono.Text.Trim());
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
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

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            this.Close();*/
        }
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Caetano", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Caetano", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formNuevoEditarClientes_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtApellidos;
            if (this.bandera)
            {
                lblEditarNuevo.Text = "Nuevo";
                // this.MostrarProducto(this.IdProducto);
                this.IsNuevo = true;
                this.IsEditar = false;
            }
            else
            {
                lblEditarNuevo.Text = "Editar";
                this.IsNuevo = false;
                this.IsEditar = true;
                this.MostrarCliente(this.IdCliente);
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtApellidos.Text == string.Empty || this.txtNombres.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        var año = this.dpFechaNac.Value.Year;
                        var mes = this.dpFechaNac.Value.Month;
                        var dia = this.dpFechaNac.Value.Day;
                        var fecha = año + "-" + mes + "-" + dia;

                        Console.WriteLine("this.FechaNac " + this.FechaNac);
                        // Console.WriteLine("this.FechaNac.Trim() " + this.FechaNac.Trim());
                        rpta = CN_Clientes.Insertar(this.txtApellidos.Text.Trim(), this.txtNombres.Text.Trim(), this.txtDNI.Text.Trim()
                            , fecha, this.txtEmail.Text.Trim(), this.txtTelefono.Text.Trim(), this.txtDireccion.Text.Trim()
                            , this.txtCiudad.Text.Trim(), this.txtProvincia.Text.Trim(), this.cbSexo.Text.Trim(), this.rTextObservaciones.Text.Trim());
                    }
                    else
                    {
                        // rpta = CN_Clientes.Editar(this.IdCliente, this.txtTransporte.Text.Trim(), this.txtTitular.Text.Trim(), this.txtTelefono.Text.Trim());
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
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

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            // this.Close();
        }
    }
}
