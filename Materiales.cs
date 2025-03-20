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
    public partial class Materiales : Form
    {
        public Materiales()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1Form = new Form1(); // Crear una instancia del formulario "Proyectos"
            form1Form.Show(); // Mostrar la nueva ventana
            this.Hide(); // Ocultar la ventana actual
        }
    }
}
