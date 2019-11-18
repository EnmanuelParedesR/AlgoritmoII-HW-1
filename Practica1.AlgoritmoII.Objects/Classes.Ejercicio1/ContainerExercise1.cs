using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.AlgoritmoII.Objects.Classes.Ejercicio1
{
    public class ContainerExercise1
    {
        public readonly int[] ArrayToBeSort;
        public readonly int MinRange;
        public readonly int MaxRange;
        public readonly int Range;

        public ContainerExercise1(int[] arr1, int[] arr2)
        {
            MinRange = arr1[0] < arr2[0] ? arr1[0] : arr2[0];
            MaxRange = arr1[arr1.Length - 1] > arr2[arr2.Length - 1] ? arr1[arr1.Length - 1] : arr2[arr2.Length - 1];
            Range = MaxRange - MinRange;
            var merge = arr1.Concat(arr2);
            ArrayToBeSort = merge.ToArray();
        }

        public void Sort()
        {
            int[] count = new int[Range + 1];

            for (int i = 0; i < ArrayToBeSort.Length; i++)
            {
                count[ArrayToBeSort[i] - MinRange]++;
            }

            int j = 0;

            for (int i = 0; i < count.Length; i++)
            {
                for (; count[i] > 0; (count[i])--)
                {
                    ArrayToBeSort[j++] = i + MinRange;
                }
            }
        }

        public void PrintResults()
        {
            Console.WriteLine("\n");
            Console.WriteLine("###### Results ######");
            Console.Write("[");
            Console.Write($"{string.Join(",", ArrayToBeSort)}");
            Console.Write("]");
        }
    }
}
