using Practica1.AlgoritmoII.Objects.Classes.Ejercicio2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_AlgoritmoII
{
    /// <summary>
    /// Alternative 
    /// 
    /// Use a bucket algorithm with Matches: 
    /// Arreglo donde cada posicion tenga un arreglo de matches [fix below]
    /// 
    //public class results
    //{
    //    Match[] matchesArray;
    //}
    ///     Diametro equal to index + inferiorLimit
    /// 
    /// -On Compare-
    /// first position -for example, diameter 1 on matches array]
    /// find all the screws and Nuts with diameter 1 and combine then [if one or another end, exit] 
    /// Set on position. [3 KetValuePair founded, then matches[1] = 3]
    /// </summary>

    public class Program
    {
        public static int nutQuantity = 0;
        public static int screwQuantity = 0;
        public static int minDiameterSize = 0;
        public static int maxDiameterSize = 0;

        static void Main(string[] args)
        {
            while (true)
            {

                if (InitializeParameters())
                {
                    break;
                }
            }

            var Container = new Container(nutQuantity, screwQuantity, minDiameterSize, maxDiameterSize);

            //Timer
            var watch = System.Diagnostics.Stopwatch.StartNew();
            //
            Container.Compare();

            //Timer end
            watch.Stop();
            Console.WriteLine("#### Time Tester ####");
            Console.WriteLine($"Miliseconds in execution: {watch.ElapsedMilliseconds} ms");
            Console.WriteLine("#### End Time Tester ####");
            Console.WriteLine("\n");
            Console.ReadLine();
            //

            Container.PrintResult();

            //

        }

        /// <summary>
        /// Initialize all the data needed for Nuts and Screw Creations
        /// </summary>
        /// <returns></returns>
        public static bool InitializeParameters()
        {
            Console.WriteLine("Nut Quantity");
            if (!int.TryParse(Console.ReadLine(), out nutQuantity))
            {
                Console.WriteLine($"{nutQuantity} is not a number");
                return false;
            };

            Console.WriteLine("Screw Quantity");
            if (!int.TryParse(Console.ReadLine(), out screwQuantity))
            {
                Console.WriteLine($"{screwQuantity} is not a number");
                return false;
            };

            Console.WriteLine("Min Diameter Size: ");
            if (!int.TryParse(Console.ReadLine(), out minDiameterSize))
            {
                Console.WriteLine($"{minDiameterSize} is not a number");
                return false;
            };

            Console.WriteLine("Max Diameter Size: ");
            if (!int.TryParse(Console.ReadLine(), out maxDiameterSize))
            {
                Console.WriteLine($"{maxDiameterSize} is not a number");
                return false;
            };

            return true;
        }
    }
}
