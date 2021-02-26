using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList
                (new string[] { "zdrasti", "kak si","chao", "leka vecher", "dobur den", "blagodarq"});

            Console.WriteLine(list.Count);

            Console.WriteLine(list.RandomString());

            Console.WriteLine(list.RandomString());

            Console.WriteLine(list.RandomString());

            Console.WriteLine(list.Count);

            Console.WriteLine(string.Join(", ", list));

        }
    }
}
