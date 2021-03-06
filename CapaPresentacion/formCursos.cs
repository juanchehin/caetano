﻿using System;
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
    public partial class formCursos : Form
    {
        CN_Cursos objetoCN = new CN_Cursos();

        private int IdCurso;

        public formCursos()
        {
            InitializeComponent();
            cargarCursos();
        }

        private void formCursos_Load(object sender, EventArgs e)
        {
            cargarCursos();

        }
        public void cargarCursos()
        {
            dataListadoCursos.DataSource = objetoCN.MostrarCursos();
            dataListadoCursos.Columns[0].Visible = false;
            // lblTotalClientes.Text = "Total de Registros: " + Convert.ToString(dataListadoCursos.Rows.Count);
            // this.banderaFormularioHijo = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Peluqueria caetano", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Peluqueria caetano", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /*private void btnEliminar_Click(object sender, EventArgs e)
        {
            /*try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar el cliente", "Gomeria Leon", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    CN_Clientes.Eliminar(this.IdCliente);
                    this.MostrarClientes();
                }
                this.MensajeOk("Se elimino de forma correcta el registro");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            this.Close();
        }*/

        private void BuscarCorte()
        {
            Console.WriteLine("this.txtBuscar.Text es " + this.txtBuscar.Text);
            // this.dataListadoClientes.DataSource = objetoCN.BuscarCliente(this.txtBuscar.Text);
            // this.OcultarColumnas();
            // lblTotalClientes.Text = "Total de Registros: " + Convert.ToString(dataListadoClientes.Rows.Count);
        }

        /*private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarCliente();
        }*/

        private void btnNuevoCorte_Click(object sender, EventArgs e)
        {
            Console.WriteLine("this.IdCliente en click nuevo es  : " + this.IdCurso);
            /* formNuevoEditarClientes frm = new formNuevoEditarClientes(this.IdCliente, true);
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();*/
        }

        private void dataListadoCcortes_SelectionChanged(object sender, EventArgs e)
        {
            if (dataListadoCursos.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataListadoCursos.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataListadoCursos.Rows[selectedrowindex];
                this.IdCurso = Convert.ToInt32(selectedRow.Cells["IdCurso"].Value);
                Console.WriteLine("El id IdCliente es " + this.IdCurso);
            }
        }

        /*private void botonEditarListado_Click_1(object sender, EventArgs e)
        {
            /*formNuevoEditarClientes frm = new formNuevoEditarClientes(this.IdCliente, false);
            frm.MdiParent = this.MdiParent;
            frm.Show();
            this.Close();
        }*/

        private void formCortes_Load(object sender, EventArgs e)
        {

        }

        /*private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar el cliente", "Gomeria Leon", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    CN_Clientes.Eliminar(this.IdCliente);
                    this.MostrarClientes();
                    this.MensajeOk("Se elimino de forma correcta el registro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            this.Close();
    }

    private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(this, new EventArgs());
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            this.MostrarClientes();
        }*/
    }

}
