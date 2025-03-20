using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Crypto.Generators;

namespace EAU3P3
{


public partial class Form1 : Form
    {

        private int _idUsuario;
        private string _rol;

        // Constructor que recibe los parámetros de idUsuario y rol
        public Form1(int idUsuario, string rol)
        {
            InitializeComponent();
            _idUsuario = idUsuario; // Asignar el valor de idUsuario
            _rol = rol;             // Asignar el valor de rol
        }



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Ejemplo de cómo usar el idUsuario y rol
            label5.Text = $"Bienvenido, Usuario #{_idUsuario}";
            label6.Text = $"Rol: {_rol}"; // Mostrar el rol del usuario

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Proyectos proyectosForm = new Proyectos(); // Crear una instancia del formulario "Proyectos"
            proyectosForm.Show(); // Mostrar la nueva ventana
            this.Hide(); // Ocultar la ventana actual 

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Facturacion facturacionForm = new Facturacion(); // Crear una instancia del formulario "Proyectos"
            facturacionForm.Show(); // Mostrar la nueva ventana
            this.Hide(); // Ocultar la ventana actual



        }

        private void button4_Click(object sender, EventArgs e)
        {

            Empleados empleadosForm = new Empleados(); // Crear una instancia del formulario "Proyectos"
            empleadosForm.Show(); // Mostrar la nueva ventana
            this.Hide(); // Ocultar la ventana actual


        }

        private void button2_Click(object sender, EventArgs e)
        {

            Materiales materialesForm = new Materiales(); // Crear una instancia del formulario "Proyectos"
            materialesForm.Show(); // Mostrar la nueva ventana
            this.Hide(); // Ocultar la ventana actual


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas cerrar sesión?", "Cerrar Sesión",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Cerrar la aplicación
                Application.Exit();
            }



        }
    }
}
