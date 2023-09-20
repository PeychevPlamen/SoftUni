using System;
using System.Collections.Generic;

namespace _04._EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int nLines = int.Parse(Console.ReadLine());

            Dictionary<int, int> nums = new Dictionary<int, int>();

            int evenNum = 0;

            for (int i = 0; i < nLines; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!nums.ContainsKey(num))
                {
                    nums.Add(num, 0);
                }

                nums[num]++;
            }

            foreach (var num in nums)
            {
                if (num.Value % 2 == 0)
                {
                    evenNum = num.Key;
                }
            }

           Console.WriteLine(evenNum);
        }
    }
}
