using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_3_de_repaso
{
    public partial class MOSTRAR : Form
    {
        List<Dueño> dueño = new List<Dueño>();
        string archivo3 = "Dueño.txt";
        public MOSTRAR()
        {
            InitializeComponent();
        }
        void leer_datos()
        {
            FileStream stream3 = new FileStream(archivo3, FileMode.Open, FileAccess.Read);
            StreamReader reader3 = new StreamReader(stream3);
            while (reader3.Peek() > -1)
            {
                Dueño tempmostrar = new Dueño();
                tempmostrar.Nombre_apellido = reader3.ReadLine();
                tempmostrar.No_casa = reader3.ReadLine();
                tempmostrar.Cuota_mantenimiento = float.Parse(reader3.ReadLine());

                dueño.Add(tempmostrar);

            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader3.Close();
        }
        void mostrar()
        {
            dataGridView1.Text = null;
            dataGridView1.DataSource = dueño;
            dataGridView1.Refresh();
        }
       
            private void button1_Click(object sender, EventArgs e)
        {
            Inicio regresar = new Inicio();
            regresar.Show();
            this.SetVisibleCore(false);
        }

        private void MOSTRAR_Load(object sender, EventArgs e)
        {

            leer_datos();
            mostrar();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        { //Se ordena los datos de acuerdo a la cuota mantenimineto de forma descedentemente
            dueño= dueño.OrderByDescending(cuota => cuota.Cuota_mantenimiento).ToList();
            mostrar();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {//Se ordena los datos de acuerdo a la cuota mantenimineto de forma ascedentemente
            dueño = dueño.OrderBy(cuota => cuota.Cuota_mantenimiento).ToList();
            mostrar();
        }
    }
}
