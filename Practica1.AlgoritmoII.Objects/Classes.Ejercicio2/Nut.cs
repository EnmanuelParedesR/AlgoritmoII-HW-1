﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.AlgoritmoII.Objects.Classes.Ejercicio2
{
    public class Nut
    {
        public string NutName { get; set; }
        public int Diameter { get; set; }
        public bool Matched { get; set; }
        public Nut(int _diameter)
        {
            Diameter = _diameter;
            NutName = "NT-" + StaticRandom.Instance.Next(1, 999);
        }
    }
}
