using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practica1.AlgoritmoII.Objects.Classes.Ejercicio2.Container;

namespace Practica1.AlgoritmoII.Objects.Classes.Ejercicio2
{
    public class Screw /*: ITest*/
    { 
        public string ScreName { get; set; }
        public int Diameter { get; set; }
        public bool Matched { get; set; }
        public Screw(int _diameter)
        {
            Diameter = _diameter;
            ScreName = "SW-" + StaticRandom.Instance.Next(1,999);
        }
    }
}
