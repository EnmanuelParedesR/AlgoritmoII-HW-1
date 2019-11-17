using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.AlgoritmoII.Objects.Classes
{
    public class Nut
    {
        public string NutName { get; set; }
        public int Diameter { get; set; }

        public Nut(int _diameter)
        {
            Diameter = _diameter;
            NutName = "NUT ID: " + new Random().Next(1);
        }

    }
}
