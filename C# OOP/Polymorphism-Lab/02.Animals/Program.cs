using System;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Animal cat = new Cat("Maria", "Whiskas");
            Animal dog = new Dog("Sharo", "Meat");

            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine();
            Console.WriteLine(dog.ExplainSelf());

        }
    }
}
