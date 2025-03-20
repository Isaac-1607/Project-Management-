using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace EAU3P3
{
    public partial class Proyectos : Form
    {
        public Proyectos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtdescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Cadena de conexión para MySQL
            string connectionString = "server=localhost;port=3306;database=construccionesnova;user=root;password=Apple123;";

            // Obtener datos del formulario
            string nombreProyecto = txtproyecto.Text;
            string descripcion = txtdescripcion.Text;
            decimal presupuesto;
            if (!decimal.TryParse(txtpresupuesto.Text, out presupuesto))
            {
                MessageBox.Show("Ingrese un valor numérico válido para el presupuesto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string estado = txtestado.Text;
            DateTime fechaInicio = dateTimeInicio.Value;
            DateTime fechaFin = dateTimeFin.Value;

            // Consulta SQL para insertar los datos
            string query = "INSERT INTO Proyectos (nombre_proyecto, descripcion, fecha_inicio, fecha_fin, presupuesto, estado) " +
                           "VALUES (@nombre, @descripcion, @fechaInicio, @fechaFin, @presupuesto, @estado)";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Agregar parámetros para evitar inyección SQL
                        command.Parameters.AddWithValue("@nombre", nombreProyecto);
                        command.Parameters.AddWithValue("@descripcion", descripcion);
                        command.Parameters.AddWithValue("@fechaInicio", fechaInicio.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@fechaFin", fechaFin.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@presupuesto", presupuesto);
                        command.Parameters.AddWithValue("@estado", estado);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Proyecto guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el proyecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    





private void Proyectos_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form1 form1Form = new Form1(); // Crear una instancia del formulario "Proyectos"
            form1Form.Show(); // Mostrar la nueva ventana
            this.Hide(); // Ocultar la ventana actual



        }

        private void txtproyecto_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
