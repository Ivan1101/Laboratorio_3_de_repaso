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
    public partial class Form1 : Form
    {
        List<Propietarios> propietarios = new List<Propietarios>();
        public Form1()
        {
            InitializeComponent();
        }
        public void guardar_datos(string archivo)
        {
            FileStream stream = new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            for (int i = 0; i < propietarios.Count; i++)
            {
                writer.WriteLine(propietarios[i].Dpi);
                writer.WriteLine(propietarios[i].Nombre);
                writer.WriteLine(propietarios[i].Apellido);
            }
            writer.Close();
        }
        void leer_datos(string archivo1)
        {
            FileStream stream = new FileStream(archivo1, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Propietarios propietariotemp = new Propietarios();
                propietariotemp.Dpi = reader.ReadLine();
                propietariotemp.Nombre = reader.ReadLine();
                propietariotemp.Apellido = reader.ReadLine();
                propietarios.Add(propietariotemp);

            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }
        void limpiar()
        {
            textBox_Dpi.Text = "";
            textBox_Nombre.Text = "";
            textBox_Apellido.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Propietarios propietariostemp = new Propietarios();
            propietariostemp.Dpi = textBox_Dpi.Text;
            propietariostemp.Nombre = textBox_Nombre.Text;
            propietariostemp.Apellido = textBox_Apellido.Text;
            propietarios.Add(propietariostemp);
            guardar_datos("Propietarios.txt");
            limpiar();
            MessageBox.Show("Proietario agregado correctamente");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
