using System;
using System.Linq;

namespace _04.Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rotation = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotation; i++)
            {
                int firstElement = array[0];

                int[] newArr = new int[array.Length];

                for (int j = 1; j < array.Length; j++)
                {
                    newArr[j - 1] = array[j];
                }
                newArr[newArr.Length - 1] = firstElement;
                array = newArr;
            }
            Console.WriteLine(String.Join(' ', array));
        }
    }
}
