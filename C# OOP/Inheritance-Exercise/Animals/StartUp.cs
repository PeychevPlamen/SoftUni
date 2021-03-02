using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Beast!")
                {
                    break;
                }

                string[] commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = commands[0];
                int age = int.Parse(commands[1]);
                string gender = commands[2];

                if (string.IsNullOrEmpty(name) || age < 0 || string.IsNullOrEmpty(gender))
                {
                    Console.WriteLine("Invalid input!");

                    continue;
                }

                if (input == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);

                    //Console.WriteLine(dog);
                    //Console.WriteLine(dog.ProduceSound());

                    Console.WriteLine(dog);
                }
                else if (input == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);

                    //Console.WriteLine(cat);
                    //Console.WriteLine(cat.ProduceSound());

                    Console.WriteLine(cat);
                }
                else if (input == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);

                    //Console.WriteLine(frog);
                    //Console.WriteLine(frog.ProduceSound());

                    Console.WriteLine(frog);
                }
                else if (input == "Kittens")
                {
                    Kitten kittens = new Kitten(name, age);

                    //Console.WriteLine(kittens);
                    //Console.WriteLine(kittens.ProduceSound());

                    Console.WriteLine(kittens);
                }
                else if (input == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age);

                    //Console.WriteLine(tomcat);
                    //Console.WriteLine(tomcat.ProduceSound());

                    Console.WriteLine(tomcat);
                }
               
            }
        }
    }
}
