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
    public partial class Facturacion : Form
    {

        private string connectionString = "server=localhost;port=3306;database=construccionesnova;user=root;password=Apple123;";

        public Facturacion()
        {
            InitializeComponent();
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            CargarProyectos(); // 🔹 Llamamos a la función aquí
        }

        private void CargarProyectos()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id_proyecto, nombre_proyecto FROM Proyectos";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count > 0) // 🔹 Verificamos si hay proyectos
                            {
                                cmbProyecto.DataSource = dt;
                                cmbProyecto.DisplayMember = "nombre_proyecto"; // Muestra el nombre
                                cmbProyecto.ValueMember = "id_proyecto"; // Guarda el ID
                            }
                            else
                            {
                                MessageBox.Show("No hay proyectos en la base de datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los proyectos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
   

private void txtmonto_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Cadena de conexión
            string connectionString = "server=localhost;port=3306;database=construccionesnova;user=root;password=Apple123;";

            // Obtener valores de los controles
            int idProyecto = Convert.ToInt32(cmbProyecto.SelectedValue);
            DateTime fechaFactura = dateTimePicker1.Value.Date;
            decimal montoTotal;
            string estadoPago = txtestadopago.Text.Trim();

            // Validación del monto
            if (!decimal.TryParse(txtmonto.Text, out montoTotal))
            {
                MessageBox.Show("Ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Consulta SQL para insertar la factura
            string query = "INSERT INTO Facturas (id_proyecto, fecha_factura, monto_total, estado_pago) " +
                           "VALUES (@idProyecto, @fechaFactura, @montoTotal, @estadoPago)";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idProyecto", idProyecto);
                        command.Parameters.AddWithValue("@fechaFactura", fechaFactura);
                        command.Parameters.AddWithValue("@montoTotal", montoTotal);
                        command.Parameters.AddWithValue("@estadoPago", estadoPago);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Factura registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo registrar la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    


        

   
        private void cmbProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtestadopago_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form1 form1Form = new Form1(); // Crear una instancia del formulario "Proyectos"
            form1Form.Show(); // Mostrar la nueva ventana
            this.Hide(); // Ocultar la ventana actual


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Facturacionypagos facturacionypagosForm = new Facturacionypagos(); // Crear una instancia del formulario "Proyectos"
            facturacionypagosForm.Show(); // Mostrar la nueva ventana
            this.Hide(); // Ocultar la ventana actual


        }
    }
}
