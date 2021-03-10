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
    public partial class PROPIEDAD : Form
    {
        List<Propiedades> propiedades = new List<Propiedades>();
        string archivo2 = "Propiedades.txt";
        List<Dueño> dueño = new List<Dueño>();
        string archivo3 = "Dueño.txt";
        List<Propietarios> propietarios = new List<Propietarios>();
        string archivo1 = "Propietarios.txt";
        public PROPIEDAD()
        {
            InitializeComponent();
        }
        public void guardar_datos()
        {
            FileStream stream2 = new FileStream(archivo3, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer2 = new StreamWriter(stream2);

            for (int i = 0; i < dueño.Count; i++)
            {
                writer2.WriteLine(dueño[i].Nombre_apellido);
                writer2.WriteLine(dueño[i].No_casa);
                writer2.WriteLine(dueño[i].Cuota_mantenimiento);
            }
            writer2.Close();

        }
        public void leer_datos (){
            FileStream stream = new FileStream(archivo1, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Propietarios propietario_temp = new Propietarios();
                propietario_temp.Dpi = reader.ReadLine();
                propietario_temp.Nombre = reader.ReadLine();
                propietario_temp.Apellido = reader.ReadLine();
                propietarios.Add(propietario_temp);
            }
            reader.Close();


            FileStream stream2 = new FileStream(archivo2, FileMode.Open, FileAccess.Read);
            StreamReader reader2 = new StreamReader(stream2);
            while (reader2.Peek() > -1)
            {
               Propiedades propiedadestemp = new Propiedades();
                propiedadestemp.No_casa = reader2.ReadLine();
                propiedadestemp.Dpi_dueño = reader2.ReadLine();
                propiedadestemp.Cuota_mantenimiento = float.Parse(reader2.ReadLine());
                propiedades.Add(propiedadestemp);
            }
            reader2.Close();

            FileStream stream4 = new FileStream(archivo3, FileMode.Open, FileAccess.Read);
            StreamReader reader4 = new StreamReader(stream4);
            while (reader4.Peek() > -1)
            {
                Dueño dueñotemp = new Dueño();
                dueñotemp.Nombre_apellido= reader4.ReadLine();
                dueñotemp.No_casa = reader4.ReadLine();
                dueñotemp.Cuota_mantenimiento = float.Parse(reader4.ReadLine());
                dueño.Add(dueñotemp);

            }
            reader4.Close();
        }

     
    }
}
