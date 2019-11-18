using Practica1.AlgoritmoII.Objects.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practica1.AlgoritmoII.Objects.Classes.Ejercicio2
{
    public class Container
    {
        public int NutsQuantity, ScrewQuantity;
        public Nut[] Nuts;
        public Screw[] Screws;
        public int minDiameterSize;
        public int maxDiameterSize;

        public List<Match> matches = new List<Match>();

        public Container(int _nutQuantity, int screwQuantity, int _minDiameterSize, int _maxDiameterSize)
        {

            if (_minDiameterSize <= 0)
            {
                throw new Exception("Diameter min size can not be minor than 1");
            }
            NutsQuantity = _nutQuantity;
            ScrewQuantity = screwQuantity;

            minDiameterSize = _minDiameterSize;
            maxDiameterSize = _maxDiameterSize;
            Initializer();
        }

        public void Initializer()
        {
            //TODO: INSTANCE THIS BETTER 
            Nuts = new Nut[NutsQuantity];
            Screws = new Screw[ScrewQuantity];

            for (var a = 0; a < NutsQuantity; a++)
                Nuts[a] = new Nut(StaticRandom.Instance.Next(minDiameterSize, maxDiameterSize));

            for (var a = 0; a < ScrewQuantity; a++)
                Screws[a] = new Screw(StaticRandom.Instance.Next(minDiameterSize, maxDiameterSize));
        }

        /// <summary>
        /// Print
        /// </summary>
        public void PrintResult()
        {
            var resultNumber = 1;
            Console.WriteLine("########## Results #############");

            if (matches.Count == 0)
            {
                Console.WriteLine("No matches found");
            }
            else
            {
                foreach (var match in matches)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"Result #{resultNumber}");
                    resultNumber += 1;
                    Console.WriteLine($"Diameter: {match.Diameter}");
                    Console.WriteLine($"Screw Name: {match.Screw.ScreName}");
                    Console.WriteLine($"Nut Name: {match.Nut.NutName}");
                }
            }

            Console.WriteLine("########## End Results #############");

            Console.WriteLine("\n");
            Console.WriteLine($"Total Matches: #{matches.Count}");

            Console.WriteLine($"Total of Screws not matched: #{Screws.Where(screw => !screw.Matched).Count()}");
            Console.WriteLine($"Total of Nuts not matched: #{Nuts.Where(nut => !nut.Matched).Count()}");
            Console.ReadLine();
        }

        public void Compare()
        {
            if (Nuts.Length == 0 || Screws.Length == 0)
            {
                throw new Exception("Error - Nuts and Screws have to be greater than 0");
            }

            foreach (var screw in Screws)
            {
                Nut NutWithSameDiameter = Nuts.FirstOrDefault(nut => nut.Diameter == screw.Diameter && !nut.Matched);

                if (NutWithSameDiameter != null)
                {
                    NutWithSameDiameter.Matched = screw.Matched = true;

                    var match = new Match(NutWithSameDiameter, screw);

                    matches.Add(match);
                }
            }
        }

        public Results[] CompareWithBucketMethod()
        {
            var results = new Results[minDiameterSize - maxDiameterSize];
            //Where a [index equal to diameter]
             


            for (var a = 0; a < results.Length; a++)
            {
                var _nuts = Nuts.Where(nut => nut.Diameter == a);
                var _screws = Screws.Where(nut => nut.Diameter == a);
            }
            return results;
        }

    }
}
