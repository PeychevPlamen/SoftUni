using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();

            string[] input = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                if (input.Length < 3)
                {
                    if (input[0] == "Add")
                    {
                        nums.Add(int.Parse(input[1]));
                    }
                    else if (input[0] == "Remove")
                    {
                        int index = int.Parse(input[1]);

                        if (index > nums.Count || index < 0)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            nums.RemoveAt(index);
                        }
                    }
                }
                else
                {
                    if (input[0] == "Insert")
                    {
                        int element = int.Parse(input[1]);
                        int index = int.Parse(input[2]);

                        if (index > nums.Count || index < 0)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            nums.Insert(index, element);
                        }

                    }
                    if (input[0] == "Shift")
                    {
                        if (input[1] == "left")
                        {
                            for (int i = 0; i < int.Parse(input[2]); i++)
                            {
                                int numToRotate = nums[0];
                                nums.Add(numToRotate);
                                nums.RemoveAt(0);
                            }
                        }
                        else if (input[1] == "right")
                        {
                            for (int i = 0; i < int.Parse(input[2]); i++)
                            {
                                int numToRotate = nums[nums.Count - 1];
                                nums.Insert(0, numToRotate);
                                nums.RemoveAt(nums.Count - 1);
                            }
                        }
                    }

                }

                input = Console.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(" ", nums));
        }
       
    }
}
