using Practica1.AlgoritmoII.Objects.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_AlgoritmoII
{
    public class SetUp
    {
        protected int NutsQuantity, ScrewQuantity;
        protected Nut[] Nuts;
        protected Screw[] Screws;
        public int minDiameterSize;
        public int maxDiameterSize;

        public SetUp(int _nutQuantity, int screwQuantity, int minDiameterSize, int maxDiameterSize)
        {

            if (minDiameterSize < 1) {
                throw new Exception("Diameter min size can not be minor than 1");
            }
            NutsQuantity = _nutQuantity;
            ScrewQuantity = screwQuantity;

            Initializer();
        }
        public void Initializer()
        {
            Nuts = new Nut[NutsQuantity];

            var nut = new Nut(5);

            for (var a = 0; a < NutsQuantity; a++) {

                Nuts[a] = new Nut(new Random().Next(minDiameterSize, maxDiameterSize));
            }

            for (var a = 0; a < ScrewQuantity; a++)
            {
                Screws[a] = new Screw(new Random().Next(minDiameterSize, maxDiameterSize));
            }
        }
    }
}
