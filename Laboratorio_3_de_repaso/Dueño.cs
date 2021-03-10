using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3_de_repaso
{
    class Dueño
    {
        string nombre;
        string apellido;
        string no_casa;
        float cuota_mantenimiento;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string No_casa { get => no_casa; set => no_casa = value; }
        public float Cuota_mantenimiento { get => cuota_mantenimiento; set => cuota_mantenimiento = value; }
    }
}
