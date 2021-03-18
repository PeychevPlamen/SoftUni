using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double radius = double.Parse(Console.ReadLine());

            Shape rectangle = new Rectangle(a, b);
            Shape circle = new Circle(radius);

            Console.WriteLine(rectangle.Draw());
            Console.WriteLine($"Area is {rectangle.CalculateArea():f2}");
            Console.WriteLine($"Perimeter is {rectangle.CalculatePerimeter():f2}");

            Console.WriteLine();
            Console.WriteLine(circle.Draw());
            Console.WriteLine($"Area is {circle.CalculateArea():f2}");
            Console.WriteLine($"Perimeter is {circle.CalculatePerimeter():f2}");
        }
    }
}
