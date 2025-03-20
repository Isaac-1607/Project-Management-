using MySql.Data.MySqlClient;
using BCrypt.Net; // Aquí se usa BCrypt.Net en lugar de BouncyCastle
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net; // Asegúrate de tener la referencia a BCrypt.Net

namespace EAU3P3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private bool ValidarCredenciales(string nombreUsuario, string contraseña)
        {
            // Cadena de conexión a la base de datos MySQL
            string connectionString = "server=localhost;port=3306;database=construccionesnova;user=root;password=Apple123;";
            string query = "SELECT ID_Usuario, Contraseña, Rol FROM Usuarios WHERE Nombre_Usuario = @NombreUsuario;";

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string contraseñaEncriptada = reader.GetString("Contraseña");
                                string rol = reader.GetString("Rol");
                                int idUsuario = reader.GetInt32("ID_Usuario");

                                // Verificar si la contraseña ingresada coincide con la almacenada (encriptada)
                                if (BCrypt.Net.BCrypt.Verify(contraseña, contraseñaEncriptada))
                                {
                                    // Si la contraseña es correcta, abrir el formulario principal
                                    Form1 form1 = new Form1(idUsuario, rol);
                                    form1.Show();
                                    this.Hide();
                                    return true;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Si el usuario no existe o la contraseña es incorrecta
            MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }




        private void Login_Load(object sender, EventArgs e)
        {

            // Ocultar caracteres de la contraseña
            txtContraseña.UseSystemPasswordChar = true;


        }



        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {

            string nombreUsuario = txtNombreUsuario.Text;
            string contraseña = txtContraseña.Text;
            // Validar credenciales
            ValidarCredenciales(nombreUsuario, contraseña);


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {


            Application.Exit(); // Cierra la aplicación

        }
    }
}
