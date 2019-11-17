using Practica1.AlgoritmoII.Objects.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_AlgoritmoII
{

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
        }

        /// <summary>
        /// Initialize all the data needed for Nuts and Screw Creations
        /// </summary>
        /// <returns></returns>
        public static bool InitializeParameters()
        {

            //TODO: Maybe use an try and catch block and remove all the return false values
         

            Console.WriteLine("Nut Quantity");
            if (!int.TryParse(Console.ReadLine(), out  nutQuantity))
            {
                Console.WriteLine($"{nutQuantity} is not a number");
                return false;
            };

            Console.WriteLine("Screw Quantity");
            if (!int.TryParse(Console.ReadLine(), out  screwQuantity))
            {
                Console.WriteLine($"{screwQuantity} is not a number");
                return false;
            };

            Console.WriteLine("Min Diameter Size: ");
            if (!int.TryParse(Console.ReadLine(), out int minDiameterSize))
            {
                Console.WriteLine($"{minDiameterSize} is not a number");
                return false;
            };

            Console.WriteLine("Max Diameter Size: ");
            if (!int.TryParse(Console.ReadLine(), out int maxDiameterSize))
            {
                Console.WriteLine($"{maxDiameterSize} is not a number");
                return false;
            };

            return true;
        }
    }
}
