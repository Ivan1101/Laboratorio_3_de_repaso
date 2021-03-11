using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3_de_repaso
{
    public class Dueño
    {
        string nombre_apellido;
        string no_casa;
        float cuota_mantenimiento;

        public string Nombre_apellido { get => nombre_apellido; set => nombre_apellido = value; }
        public string No_casa { get => no_casa; set => no_casa = value; }
        public float Cuota_mantenimiento { get => cuota_mantenimiento; set => cuota_mantenimiento = value; }
        
    }
}
