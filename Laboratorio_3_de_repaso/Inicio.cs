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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PROPIETARIO v1 = new PROPIETARIO();
            v1.Show();
            this.SetVisibleCore(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PROPIEDAD v2 = new PROPIEDAD();
            v2.Show();
            this.SetVisibleCore(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MOSTRAR v3 = new MOSTRAR();
            v3.Show();
            this.SetVisibleCore(false);
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}
