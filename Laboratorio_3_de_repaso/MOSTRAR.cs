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
    public partial class MOSTRAR : Form
    {
        public MOSTRAR()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inicio regresar = new Inicio();
            regresar.Show();
            this.SetVisibleCore(false);
        }
    }
}
