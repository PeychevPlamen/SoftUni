using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Animal animal = CreateAnimal(tokens);

                animals.Add(animal);

                string[] foodInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Food food = CreateFood(foodInfo);

                Console.WriteLine(animal.ProduceSound()); 

                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Food CreateFood(string[] foodInfo)
        {
            Food food = null;

            string type = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            if (type == nameof(Vegetable))
            {
                food = new Vegetable(quantity);
            }
            else if (type == nameof(Fruit))
            {
                food = new Fruit(quantity);
            }
            else if (type == nameof(Meat))
            {
                food = new Meat(quantity);
            }
            else if (type == nameof(Seeds))
            {
                food = new Seeds(quantity);
            }

            return food;
        }

        private static Animal CreateAnimal(string[] tokens)
        {
            Animal animal = null;

            //	Felines - "{Type} {Name} {Weight} {LivingRegion} {Breed}";
            //	Birds - "{Type} {Name} {Weight} {WingSize}";
            //	Mice and Dogs - "{Type} {Name} {Weight} {LivingRegion}";

            string type = tokens[0];
            string name = tokens[1];
            double weight = double.Parse(tokens[2]);

            if (type == nameof(Hen))
            {
                double wingSize = double.Parse(tokens[3]);

                animal = new Hen(name, weight, wingSize);
            }
            else if (type == nameof(Owl))
            {
                double wingSize = double.Parse(tokens[3]);

                animal = new Owl(name, weight, wingSize);
            }
            else if (type == nameof(Mouse))
            {
                string livingRegion = tokens[3];

                animal = new Mouse(name, weight, livingRegion);
            }
            else if (type == nameof(Dog))
            {
                string livingRegion = tokens[3];

                animal = new Dog(name, weight, livingRegion);
            }
            else if (type == nameof(Cat))
            {
                string livingRegion = tokens[3];
                string breed = tokens[4];

                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (type == nameof(Tiger))
            {
                string livingRegion = tokens[3];
                string breed = tokens[4];

                animal = new Tiger(name, weight, livingRegion, breed);
            }

            return animal;
        }
    }

}
