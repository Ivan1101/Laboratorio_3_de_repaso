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
        // Se declararon listas para todas las clases que se realizaron y sus respectivos archivos de textos
        List<Dueño> dueño = new List<Dueño>();
        string archivo3 = "Dueño.txt";
        List<Propietario_mayor> propietario_Mayor = new List<Propietario_mayor>();
        //string archivo4 = "Propietario mayor.txt";
        List<Propiedades> propiedades = new List<Propiedades>();
        string archivo2 = "Propiedades.txt";
        List<Propietarios> propietarios = new List<Propietarios>();
        string archivo1 = "Propietarios.txt";
        public MOSTRAR()
        {
            InitializeComponent();
            label1.Visible = false;
            label2.Visible = false;
        }
        void leer_datos()// función para leer los datos de todas las clases
        { // Se lee los datos de la clase Dueño
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

            // Se lee los datos de la clase Propiedades
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

            // Se lee los datos de la clase Propietarios
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
            /*foreach (var p in propiedades)
            {
                Propietario_mayor propietario_medio = new Propietario_mayor();
                Propietarios temppropietario = propietarios.Find(l => l.Dpi == p.Dpi_dueño);
                propietario_medio.Dpi = p.Dpi_dueño;
                propietario_medio.Nombre_apellido = temppropietario.Nombre.ToString() + " " + temppropietario.Apellido.ToString();

                propietario_Mayor.Add(propietario_medio);
            }*/
            verificar_propiedades(); // se llama la función de verificar el numero de propiedades de un propietario
        }

            private void verificar_propiedades() // retorna 0 si no se encuentra en la lista
        {

            for (int x = 0; x < propiedades.Count; x++)
            { // Se coloca esta condición para ver si en la lista propietari_Mayor hay algun dato
                if (propietario_Mayor.Count > 0)
                {
                    for (int y = 0; y < propietario_Mayor.Count; y++)
                    {
                        // Se coloco esta condición si el dato de dpi es igual en la dos clases
                        if (propiedades[x].Dpi_dueño.Equals(propietario_Mayor[y].Dpi))
                        {
                            //Propietario_mayor temppropietario_mayor = new Propietario_mayor();
                            propietario_Mayor[y].Contador_propiedades = propietario_Mayor[y].Contador_propiedades + 1;
                            propietario_Mayor[y].Cuota_total += propiedades[x].Cuota_mantenimiento;
                        }
                        else
                        // Se agrega los datos si el dato del dpi en la lista propiedades no era igual al dato de dpi en propietario mayor
                        {
                            Propietarios al = propietarios.Find(c => c.Dpi.Equals(propiedades[x].Dpi_dueño));
                            Propietario_mayor propietario_Mayortemp = new Propietario_mayor();
                            propietario_Mayortemp.Nombre_apellido = al.Nombre + " " + al.Apellido;
                            propietario_Mayortemp.Dpi = al.Dpi;
                            propietario_Mayortemp.Contador_propiedades = 1;
                            propietario_Mayortemp.Cuota_total = propiedades[x].Cuota_mantenimiento;
                            propietario_Mayor.Add(propietario_Mayortemp);
                        }
                    }
                }
                // sino se cumple la función de que no haya un datos en la lista 
                else
                {
                    Propietarios al = propietarios.Find(c => c.Dpi.Equals(propiedades[x].Dpi_dueño));
                    Propietario_mayor propietario_Mayortemp = new Propietario_mayor();
                    propietario_Mayortemp.Nombre_apellido = al.Nombre + " " + al.Apellido;
                    propietario_Mayortemp.Dpi = al.Dpi;
                    propietario_Mayortemp.Contador_propiedades = 1;
                    propietario_Mayortemp.Cuota_total = propiedades[x].Cuota_mantenimiento;
                    propietario_Mayor.Add(propietario_Mayortemp);
                }
            }

        }

        public void mostrar() // función para mostrar los datos en el dataGridView
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
            // Funciones que van a cargar solo compilando el programa o formulario
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

            label1.Text = "";
            label1.Visible = true;
            label2.Visible = false;
     //Se instancia un objeto de la clase Propietario_mayor para ordenar los datos de esta y encontrar el primero propietario que tiene mayor propiedades
            Propietario_mayor temppropietario = propietario_Mayor.OrderByDescending(al => al.Contador_propiedades).First();
            label1.Text = temppropietario.Nombre_apellido;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            string temp_cuota= "";
    // Se  utiliza la lista propiedades para ordenar los datos de forma descendente de acuerdo a la cuota de mantenimiento
            propiedades = propiedades.OrderByDescending(cuota => cuota.Cuota_mantenimiento).ToList();
        // Ciclo para mostrar solo las 3 cuotas mas altas
            for (int x = 0; x < 3; x++)
            {
                temp_cuota = temp_cuota +"Q."+ propiedades[x].Cuota_mantenimiento + "\n";

            }
            richTextBox1.Text = temp_cuota;// Se muestran en un richTextBox
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            string temp_cuota  ="";
         // Se  utiliza la lista propiedades para ordenar los datos de forma ascendente de acuerdo a la cuota de mantenimiento
            propiedades = propiedades.OrderBy(cuota => cuota.Cuota_mantenimiento).ToList();
            // Ciclo para mostrar solo las 3 cuotas mas bajas
            for (int x = 0; x < 3; x++)
            {
                temp_cuota = temp_cuota + "Q." + propiedades[x].Cuota_mantenimiento + "\n";

            }
            richTextBox1.Text = temp_cuota; // Se muestran en un richTextBox

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "";
            label2.Visible = true;
            label1.Visible = false;
            // Se  utiliza la lista propiedades para ordenar los datos de forma descendente de acuerdo a la cuota total
            propietario_Mayor = propietario_Mayor.OrderByDescending(cuota => cuota.Cuota_total).ToList();
            // Se muestra en una label los datos del indice 0 de esta
            label2.Text = propietario_Mayor[0].Nombre_apellido+ " " +"Q."+ propietario_Mayor[0].Cuota_total;
        }
    }
}
