using Practica1.AlgoritmoII.Objects.Classes.Ejercicio1;
using System;

namespace Practica1.AlgoritmoII.Ejercicio1
{
    class Program
    {
        protected static int[] arr1;
        protected static int[] arr2;

        static void Main(string[] args)
        {
            while (true)
            {
                if (InitializeParameters())
                {
                    break;
                };
                Console.WriteLine("\n");
            }
            //int[] arr1 = new int[] { 1, 2, 3, 4, 5 };
            //int[] arr2 = new int[] { 1, 3, 4, 5, 10 };
            ContainerExercise1 container = new ContainerExercise1(arr1, arr2);

            container.Sort();
            container.PrintResults();
       
            Console.ReadLine();
        }

        /// <summary>
        /// Initialize all the data needed
        /// </summary>
        /// <returns></returns>
        public static bool InitializeParameters()
        {
            Console.WriteLine("Set first Array [delimited by comma and in order]");

            var firstString = Console.ReadLine();
            var stringAsArray = firstString.Split(',');

            arr1 = new int[stringAsArray.Length];

            for (var a = 0; a < stringAsArray.Length; a++)
            {
                if (!int.TryParse(stringAsArray[a], out arr1[a]))
                {
                    Console.WriteLine("Wrong element");
                    return false;
                };
            }

            Console.WriteLine("\n");
            Console.WriteLine("Set second Array [delimited by comma and in order]");

            var secondString = Console.ReadLine();
            stringAsArray =  secondString.Split(',');

            arr2 = new int[stringAsArray.Length];

            for (var a = 0; a < stringAsArray.Length; a++)
            {
                if (!int.TryParse(stringAsArray[a], out arr2[a]))
                {
                    Console.WriteLine("Wrong element");
                    return false;
                };
            }

            return true;
        }
    }

}
