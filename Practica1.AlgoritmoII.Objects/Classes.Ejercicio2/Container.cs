using Practica1.AlgoritmoII.Objects.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practica1.AlgoritmoII.Objects.Classes.Ejercicio2
{
    /// <summary>
    /// TODO: Clean Bucket part and get out of this file bucket classes.
    /// </summary>
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


        #region Normal Compare
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
        #endregion

        #region BUCKET

        //TODO: Add a PrintResult for Bucket
        //public void PrintResultBucket()
        //{
        //    var resultNumber = 1;
        //    Console.WriteLine("########## Results #############");

         
        //    else
        //    {
        //        foreach (var match in dictionaryName)
        //        {
        //            Console.WriteLine("\n");
        //            Console.WriteLine($"Result #{resultNumber}");
        //            resultNumber += 1;
        //            Console.WriteLine($"Diameter: {match.Diameter}");
        //            Console.WriteLine($"Screw Name: {match.Screw.ScreName}");
        //            Console.WriteLine($"Nut Name: {match.Nut.NutName}");
        //        }
        //    }

        //    Console.WriteLine("########## End Results #############");

        //    Console.WriteLine("\n");
        //    Console.WriteLine($"Total Matches: #{matches.Count}");

        //    Console.WriteLine($"Total of Screws not matched: #{Screws.Where(screw => !screw.Matched).Count()}");
        //    Console.WriteLine($"Total of Nuts not matched: #{Nuts.Where(nut => !nut.Matched).Count()}");
        //    Console.ReadLine();
        //}

        public Dictionary<Screw, Nut> CompareWithBucketMethod()
        {
            var ScrewsSorted = Sort(maxDiameterSize - minDiameterSize, Screws, minDiameterSize);
            var NutSorted = Sort(maxDiameterSize - minDiameterSize, Nuts, minDiameterSize);

            var DictionaryResult = new Dictionary<Screw, Nut>();


            for (var i = 0; i < ScrewsSorted.Result.Length; i++)
            {
                //No Screws with this diameter, exit
                if (ScrewsSorted.Result[i].Screws.Count == 0)
                    continue;

                foreach (var screw in ScrewsSorted.Result[i].Screws)
                {
                    if (!screw.Matched)
                        if (NutSorted.Result[i].NutMatches != NutSorted.Result[i].Nuts.Count)
                        {
                            //Puedo utilizar el contador NutMatches para saltar el elemento que ya esta matched

                            for (var z = NutSorted.Result[i].NutMatches; z < NutSorted.Result[i].Nuts.Count; z++)
                            {

                                if (!NutSorted.Result[i].Nuts[z].Matched)
                                {
                                    NutSorted.Result[i].NutMatches++;
                                    NutSorted.Result[i].Nuts[z].Matched = screw.Matched = true;
                                    DictionaryResult.Add(screw, NutSorted.Result[i].Nuts[z]);
                                    break;
                                }
                            }

                            //foreach (var nut in NutSorted.Result[i].Nuts)
                            //{
                            //    if (!nut.Matched)
                            //    {
                            //        NutSorted.Result[i].NutMatches++;
                            //        nut.Matched = screw.Matched = true;
                            //        DictionaryResult.Add(screw, nut);
                            //        break;
                            //    }
                            //}
                        }
                }
            }
            return DictionaryResult;
        }

        public class BucketScrews
        {
            public List<Screw> Screws { get; set; }
        }

        public class ResultBucketScrews
        {
            public BucketScrews[] Result { get; set; }
            public readonly int MinRange; //Check if is needed
        
            public ResultBucketScrews(BucketScrews[] _result, int _minRange)
            {
                Result = _result;
                MinRange = _minRange;
            }


        }
        #endregion
        #region Nuts

        public class ResultBucketNuts
        {
            public BucketNuts[] Result { get; set; }
            public readonly int MinRange; //Check if is needed

            public ResultBucketNuts(BucketNuts[] _result, int _minRange)
            {
                Result = _result;
                MinRange = _minRange;
            }
        }
        public class BucketNuts
        {
            public List<Nut> Nuts { get; set; }
            public int NutMatches = 0;
        }
        #endregion

        //Functions FIX Summary
        /// <summary>
        /// Sort with Nuts
        /// </summary>
        /// <param name="range"></param>
        /// <param name="_arrayToBeSort"></param>
        /// <param name="minRange"></param>
        /// <returns></returns>
        public static ResultBucketNuts Sort(int range, Nut[] _arrayToBeSort, int minRange)
        {
            BucketNuts[] count = new BucketNuts[range + 1];

            for (var i = 0; i < count.Length; i++)
            {

                count[i] = new BucketNuts();
                count[i].Nuts = new List<Nut>();
            }

            for (int i = 0; i < _arrayToBeSort.Length; i++)
            {
                count[_arrayToBeSort[i].Diameter - minRange].Nuts.Add(_arrayToBeSort[i]);

            }

            var results = new ResultBucketNuts(count, minRange);

            return results;
        }

        /// <summary>
        /// Sort with Screw
        /// </summary>
        /// <param name="range"></param>
        /// <param name="_arrayToBeSort"></param>
        /// <param name="minRange"></param>
        /// <returns></returns>
        public static ResultBucketScrews Sort(int range, Screw[] _arrayToBeSort, int minRange)
        {
            BucketScrews[] count = new BucketScrews[range + 1];

            //Make generic initializer
            for (var i = 0; i < count.Length; i++)
            {
                count[i] = new BucketScrews();
                count[i].Screws = new List<Screw>();
            }

            for (int i = 0; i < _arrayToBeSort.Length; i++)
            {
                count[_arrayToBeSort[i].Diameter - minRange].Screws.Add(_arrayToBeSort[i]);
            }
            var results = new ResultBucketScrews(count, minRange);
            return results;
        }

    }
}
