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
        
        List<Propiedades> propiedades = new List<Propiedades>();
        string archivo2 = "Propiedades.txt";
        List<Propietarios> propietarios = new List<Propietarios>();
        string archivo1 = "Propietarios.txt";
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


            FileStream stream = new FileStream(archivo2, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Propiedades tempmostrar = new Propiedades();
                tempmostrar.No_casa = reader.ReadLine();
                tempmostrar.Dpi_dueño = reader.ReadLine();
                tempmostrar.Cuota_mantenimiento = float.Parse(reader.ReadLine());

                propiedades.Add(tempmostrar);

            }
            reader.Close();
            FileStream stream1 = new FileStream(archivo1, FileMode.Open, FileAccess.Read);
            StreamReader reader1 = new StreamReader(stream1);
            while (reader1.Peek() > -1)
            {
                Propietarios tempmostrar = new Propietarios();
                tempmostrar.Dpi = reader1.ReadLine();
                tempmostrar.Nombre = reader1.ReadLine();
                tempmostrar.Apellido = reader1.ReadLine();

                propietarios.Add(tempmostrar);

            }
            reader1.Close();
            foreach (var p in propiedades)
            {
                Propietario_mayor propietario_medio = new Propietario_mayor();
                Propietarios temppropietario = propietarios.Find(l => l.Dpi == p.Dpi_dueño);
                propietario_medio.Dpi = p.Dpi_dueño;
                propietario_medio.Nombre_apellido = temppropietario.Nombre.ToString() + " " + temppropietario.Apellido.ToString();

                propietario_Mayor.Add(propietario_medio);
            }
        }

            private void verificar_propiedades() // retorna 0 si no se encuentra en la lista
        {
            for (int x = 0; x < propiedades.Count; x++)
            {

                for (int y = 0; y < propietario_Mayor.Count; y++)
                {
                    if (propiedades[x].Dpi_dueño.Equals(propietario_Mayor[y].Dpi))
                    {
                        //Propietario_mayor temppropietario_mayor = new Propietario_mayor();
                        propietario_Mayor[y].Contador_propiedades= propietario_Mayor[y].Contador_propiedades+1;
                    }
                    else
                    {
                        Propietario_mayor al = propietario_Mayor.Find(c => c.Dpi.Equals(propiedades[x].Dpi_dueño));
                        Propietario_mayor propietario_Mayortemp = new Propietario_mayor();
                        propietario_Mayortemp.Nombre_apellido = al.Nombre_apellido;
                        propietario_Mayortemp.Dpi = al.Dpi;
                        propietario_Mayortemp.Contador_propiedades = al.Contador_propiedades;
                        propietario_Mayortemp.Cuota_total = al.Cuota_total;
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
        public void cargar()
        {
            foreach( var p in propiedades)
            {
                Propietario_mayor propietario_medio = new Propietario_mayor();
                Propietarios temppropietario = propietarios.Find(l => l.Dpi == p.Dpi_dueño);
                propietario_medio.Dpi = p.Dpi_dueño;
                propietario_medio.Nombre_apellido = temppropietario.Nombre+" "+temppropietario.Apellido;

                propietario_Mayor.Add(propietario_medio);
            }
        }
       
            private void button1_Click(object sender, EventArgs e)
        {
            Inicio regresar = new Inicio();
            regresar.Show();
            this.SetVisibleCore(false);
        }

        private void MOSTRAR_Load(object sender, EventArgs e)
        {
            //cargar();

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

            //  cargar();
           // leer_datos();
            verificar_propiedades();

            Propietario_mayor temppropietario = propietario_Mayor.OrderByDescending(al => al.Contador_propiedades).First();
            label1.Text = temppropietario.Nombre_apellido;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            string temp_cuota= "";
            propiedades = propiedades.OrderByDescending(cuota => cuota.Cuota_mantenimiento).ToList();
            for (int x = 0; x < 3; x++)
            {
                temp_cuota = temp_cuota + propiedades[x].Cuota_mantenimiento + "\n";

            }
        }
    }
}
