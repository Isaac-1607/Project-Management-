using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EAU3P3
{
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form1 form1Form = new Form1(); // Crear una instancia del formulario "Proyectos"
            form1Form.Show(); // Mostrar la nueva ventana
            this.Hide(); // Ocultar la ventana actual

        }

        private void button1_Click(object sender, EventArgs e)
        {



            // Cadena de conexión para MySQL
            string connectionString = "server=localhost;port=3306;database=construccionesnova;user=root;password=Apple123;";

            // Obtener datos del formulario
            string nombreEmpleado = txtempleado.Text;
            string especialidad = txtespecialidad.Text;
            decimal salario;
            if (!decimal.TryParse(txtsalario.Text, out salario))
            {
                MessageBox.Show("Ingrese un valor numérico válido para el salario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string disponibilidad = txtdispo.Text;

            // Consulta SQL para insertar los datos
            string query = "INSERT INTO empleados (nombre, especialidad, salario, disponibilidad) " +
                           "VALUES (@nombre, @especialidad, @salario, @disponibilidad)";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros para evitar inyección SQL
                        command.Parameters.AddWithValue("@nombre", nombreEmpleado);
                        command.Parameters.AddWithValue("@especialidad", especialidad);
                        command.Parameters.AddWithValue("@salario", salario);
                        command.Parameters.AddWithValue("@disponibilidad", disponibilidad);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Empleado guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            AsignarProyecto asignarproyectoForm = new AsignarProyecto(); // Crear una instancia del formulario "Proyectos"
            asignarproyectoForm.Show(); // Mostrar la nueva ventana
            this.Hide(); // Ocultar la ventana actual






        }
    }
}
