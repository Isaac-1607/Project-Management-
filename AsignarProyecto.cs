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
    public partial class AsignarProyecto : Form
    {
        private string connectionString = "server=localhost;port=3306;database=construccionesnova;user=root;password=Apple123;";
        public AsignarProyecto()
        {
            InitializeComponent();
            CargarEmpleados();
            CargarProyectos();
        }

        private void CargarEmpleados()
        {
            string query = "SELECT id_empleado, nombre FROM empleados";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        var dataTable = new DataTable();
                        dataTable.Load(reader);
                        cmbEmpleados.DataSource = dataTable;
                        cmbEmpleados.DisplayMember = "nombre";
                        cmbEmpleados.ValueMember = "id_empleado";
                        cmbEmpleados.SelectedIndex = -1; // Evita selección automática
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProyectos()
        {
            string query = "SELECT id_proyecto, nombre_proyecto FROM proyectos";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        var dataTable = new DataTable();
                        dataTable.Load(reader);
                        cmbProyectos.DataSource = dataTable;
                        cmbProyectos.DisplayMember = "nombre_proyecto";
                        cmbProyectos.ValueMember = "id_proyecto";
                        cmbProyectos.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar proyectos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Cadena de conexión
            string connectionString = "server=localhost;port=3306;database=construccionesnova;user=root;password=Apple123;";

            // Obtener valores seleccionados
            int idEmpleado = Convert.ToInt32(cmbEmpleados.SelectedValue);
            int idProyecto = Convert.ToInt32(cmbProyectos.SelectedValue);
            DateTime fechaAsignacion = dateTimePicker1.Value.Date;

            // Consulta SQL para insertar en la tabla asignacion_empleados
            string query = "INSERT INTO asignacion_empleados (id_proyecto, id_empleado, fecha_asignacion) VALUES (@idProyecto, @idEmpleado, @fechaAsignacion)";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idProyecto", idProyecto);
                        command.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                        command.Parameters.AddWithValue("@fechaAsignacion", fechaAsignacion);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Empleado asignado exitosamente al proyecto.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo asignar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al asignar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AsignarProyecto_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Empleados empleadosForm = new Empleados(); // Crear una instancia del formulario "Proyectos"
            empleadosForm.Show(); // Mostrar la nueva ventana
            this.Hide(); // Ocultar la ventana actual
        }
    }
}




