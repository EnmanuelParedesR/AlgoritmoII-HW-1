using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.AlgoritmoII.Objects.Classes
{
    public class Screw
    {
        public string ScreName { get; set; }
        public int Diameter { get; set; }
        public bool Matched { get; set; }
        public Screw(int _diameter)
        {
            Diameter = _diameter;
            ScreName = "SW-" + new Random().Next();
        }
    }
}
