using System;
using System.Text;

namespace Collection
{
    class Program
    {
        public static void Main(string[] args)
        {
            ListyIterator<string> list = new ListyIterator<string>();

            string input = Console.ReadLine().Replace("Create", "");
            list.Create(input.Split(" ", StringSplitOptions.RemoveEmptyEntries));

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                switch (command)
                {
                    case "Move":
                        Console.WriteLine(list.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;
                    case "Print":
                        list.Print();
                        break;
                    case "PrintAll":
                        list.PrintAll(list);
                        break;

                }
            }
        }
    }
}