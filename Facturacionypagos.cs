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
    public partial class Facturacionypagos : Form
    {

        private string connectionString = "server=localhost;port=3306;database=construccionesnova;user=root;password=Apple123;";
        public Facturacionypagos()
        {
            InitializeComponent();
        }

        private void Facturacionypagos_Load(object sender, EventArgs e)
        {
            CargarFacturas();
        }



        private void CargarFacturas()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id_factura FROM facturas";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                cmbfactura.DataSource = dt;
                                cmbfactura.DisplayMember = "id_factura"; // Mostrar ID de factura
                                cmbfactura.ValueMember = "id_factura";
                                cmbfactura.SelectedIndex = -1; // No seleccionar nada por defecto
                            }
                            else
                            {
                                MessageBox.Show("No hay facturas registradas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                cmbfactura.DataSource = null; // Limpiar si no hay datos
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las facturas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1Form = new Form1(); // Crear una instancia del formulario "Proyectos"
            form1Form.Show(); // Mostrar la nueva ventana
            this.Hide(); // Ocultar la ventana actual
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbpago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            {
                // Validaciones de entrada
                if (cmbfactura.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione una factura válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtpago.Text, out decimal montoPagado))
                {
                    MessageBox.Show("Ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener valores de los controles
                int idFactura = Convert.ToInt32(cmbfactura.SelectedValue);
                DateTime fechaPago = dateTimePicker1.Value.Date;

                // Consulta SQL para insertar el pago (sin id_pago, ya que es autoincremental)
                string query = "INSERT INTO Pagos (id_factura, fecha_pago, monto_pagado) " +
                               "VALUES (@idFactura, @fechaPago, @montoPagado)";

                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idFactura", idFactura);
                            command.Parameters.AddWithValue("@fechaPago", fechaPago);
                            command.Parameters.AddWithValue("@montoPagado", montoPagado);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Pago registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo registrar el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al registrar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}








