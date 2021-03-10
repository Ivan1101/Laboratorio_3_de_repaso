using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_3_de_repaso
{
    public partial class Form1 : Form
    {
        List<Propietarios> propietarios = new List<Propietarios>();
        public Form1()
        {
            InitializeComponent();
        }
        void guardar_datos()
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Propietarios propietariostemp = new Propietarios();
            propietariostemp.Dpi = textBox_propietarios.Text;
            propietariostemp.Nombre = textBox_Nombre.Text;
            propietariostemp.Apellido = textBox_Apellido.Text;
            propietarios.Add(propietariostemp);
        }
    }
}
