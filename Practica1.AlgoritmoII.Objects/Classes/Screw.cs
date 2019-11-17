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

        public Screw(int _diameter)
        {
            Diameter = _diameter;
            ScreName = "SCREW ID: " + new Random().Next(1);
        }
    }
}
