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
        public int NutsQuantity, ScrewQuantity;
        public Nut[] Nuts;
        public Screw[] Screws;
        public int minDiameterSize;
        public int maxDiameterSize;

        //TODO: MOVE THIS FROM THIS CLASS
        public List<Match> matches = new List<Match>();

        public SetUp(int _nutQuantity, int screwQuantity, int _minDiameterSize, int _maxDiameterSize)
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
            //TODO: CREATE THIS BETTER
            Nuts = new Nut[NutsQuantity];
            Screws = new Screw[ScrewQuantity];

            for (var a = 0; a < NutsQuantity; a++)
            {
                Nuts[a] = new Nut(new Random().Next(minDiameterSize, maxDiameterSize));
            }
            for (var a = 0; a < ScrewQuantity; a++)
            {
                Screws[a] = new Screw(new Random().Next(minDiameterSize, maxDiameterSize));
            }
        }

        /// <summary>
        /// Print
        /// </summary>
        public void PrintResult()
        {
            var resultNumber = 1;
            Console.WriteLine("########## Results #############");

            foreach (var match in matches)
            {
                Console.WriteLine("\n");
                Console.WriteLine($"Result #{resultNumber}");
                resultNumber += 1;
                Console.WriteLine($"Diameter: {match.Diameter}");
                Console.WriteLine($"Screw Name: {match.Screw.ScreName}");
                Console.WriteLine($"Nut Name: {match.Nut.NutName}");


            }

            Console.WriteLine($"Total Matches: #{matches.Count}");
            //TODO: Iterate this one
            Console.WriteLine($"Total of Screws not matched: #{Screws.Where(screw => !screw.Matched).Count()}");
            Console.WriteLine($"Total of Nuts not matched: #{Nuts.Where(nut => !nut.Matched).Count()}");
            Console.ReadLine();
        }

        //TODO: MOVE FROM HERE'
        public void Compare(Nut[] _nuts, Screw[] _screws)
        {

            if (_nuts.Length == 0 || _screws.Length == 0)
            {
                throw new Exception("Error - Nuts and Screws have to be greater than 0");
            }

            foreach (var screw in _screws)
            {

                var similarNut = _nuts.FirstOrDefault(nut => nut.Diameter == screw.Diameter && !nut.Matched);

                if (similarNut != null)
                {
                    similarNut.Matched = screw.Matched = true;

                    var match = new Match(similarNut, screw);

                    matches.Add(match);
                }
            }
        }

    }

    public class Match
    {
        public Nut Nut;
        public Screw Screw;
        public int Diameter;

        public Match(Nut _nut, Screw _screw)
        {
            Nut = _nut;
            Screw = _screw;

            if (_nut.Diameter == _screw.Diameter)
            {
                Diameter = _nut.Diameter;
            }
            else
            {
                throw new Exception("Error");
            }
        }
    }
}
