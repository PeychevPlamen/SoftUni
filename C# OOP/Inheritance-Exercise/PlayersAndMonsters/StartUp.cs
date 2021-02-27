using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Elf elf = new Elf("Elfy", 120);
            Knight knight = new Knight("Monster", 999);

            Console.WriteLine(elf);
            Console.WriteLine(knight);
        }
    }
}