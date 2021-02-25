using System;

namespace _10._RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGame = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int headsetTrashCount = 0;
            int mouseTrashCount = 0;
            int keyboardTrashCount = 0;
            int displayTrashCount = 0;

            for (int i = 1; i <= lostGame; i++)
            {
                if (i % 2 == 0)
                {
                    headsetTrashCount++;
                }
                if (i % 3 == 0)
                {
                    mouseTrashCount++;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    keyboardTrashCount++;

                    if (keyboardTrashCount % 2 == 0)
                    {
                        displayTrashCount++;
                    }
                }
            }
            double totalExpenses = (headsetTrashCount * headsetPrice) +
                                   (mouseTrashCount * mousePrice) +
                                   (keyboardTrashCount * keyboardPrice) +
                                   (displayTrashCount * displayPrice);

            Console.WriteLine($"Rage expenses: {totalExpenses:f2} lv.");
        }
    }
}
