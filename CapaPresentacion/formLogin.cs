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
    public partial class formLogin : Form
    {
        CN_Usuarios Obj = new CN_Usuarios();
        public formLogin()
        {
            InitializeComponent();
            txtUsuario.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string Datos = Obj.Login(this.txtUsuario.Text, this.txtPassword.Text);
            // Evaluar si existe el Usuario
            Console.WriteLine("Datos es : " + Datos);
            if (Datos != "Ok")
            {
                MessageBox.Show("Error de login", "Peluqueria Caetano", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmPrincipal frm = new frmPrincipal();
                frm.Show();
                this.Hide();

            }
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            formInformacion frm = new formInformacion();
            frm.Show();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.ttAyuda.SetToolTip(btnAyuda, "Ayuda");
        }
    }
}
