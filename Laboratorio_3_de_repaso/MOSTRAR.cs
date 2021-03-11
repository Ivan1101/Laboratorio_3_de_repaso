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
        List<Propietario_mayor> propietario_Mayor = new List<Propietario_mayor>();
        string archivo4= "Propietario mayor.txt";
        List<Propiedades> propiedades = new List<Propiedades>();
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

            FileStream stream4 = new FileStream(archivo4, FileMode.Open, FileAccess.Read);
            StreamReader reader4 = new StreamReader(stream4);
            while (reader4.Peek() > -1)
            {
                Propietario_mayor tempmostrar = new Propietario_mayor();
                tempmostrar.Nombre_apellido = reader4.ReadLine();
                tempmostrar.Dpi = reader4.ReadLine();
                tempmostrar.Contador_propiedades = Convert.ToInt32(reader4.ReadLine());
                tempmostrar.Cuota_total = float.Parse(reader4.ReadLine());

                propietario_Mayor.Add(tempmostrar);

            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader4.Close();
        }
   
        private void verificar_propiedades() // retorna 0 si no se encuentra en la lista
        {
            for (int x = 0; x < propiedades.Count; x++)
            {

                for (int y = 0; y < propietario_Mayor.Count; y++)
                {
                    if (propiedades[x].Dpi_dueño.Equals(propietario_Mayor[y]))
                    {
                        //Propietario_mayor temppropietario_mayor = new Propietario_mayor();
                        propietario_Mayor[y].Contador_propiedades++;
                    }
                    else
                    {
                        Propietario_mayor al = propietario_Mayor.Find(c => c.Dpi.Equals(propiedades[x].Dpi_dueño));
                        Propietario_mayor propietario_Mayortemp = new Propietario_mayor();
                        propietario_Mayortemp.Nombre_apellido = al.Nombre_apellido;
                        propietario_Mayortemp.Dpi = al.Dpi;
                        propietario_Mayortemp.Contador_propiedades = al.Contador_propiedades;
                        propietario_Mayortemp.Cuota_total = al.Cuota_total;conse
                    }
                }
            }

        }

        public void mostrar()
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
        { //Se ordena los datos de acuerdo a la cuota mantenimineto de forma ascedentemente
            dueño = dueño.OrderBy(cuota => cuota.Cuota_mantenimiento).ToList();
            mostrar();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {//Se ordena los datos de acuerdo a la cuota mantenimineto de forma descedentemente
            dueño = dueño.OrderByDescending(cuota => cuota.Cuota_mantenimiento).ToList();
            mostrar();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            verificar_propiedades();
            Propietario_mayor alto = propietario_Mayor.OrderByDescending(al => al.Contador_propiedades).First();
            label1.Text = alto.Nombre_apellido;
        }
    }
}
