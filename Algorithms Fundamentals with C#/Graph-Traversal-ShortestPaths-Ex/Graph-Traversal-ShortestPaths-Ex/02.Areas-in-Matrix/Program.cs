using System;
using System.Collections.Generic;

namespace _02.Areas_in_Matrix
{
    public class Program
    {
        private static char[,] graph;
        private static bool[,] visited;
        private static IDictionary<char, int> areas;

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            graph = new char[rows, cols];
            visited = new bool[rows, cols];
            areas = new SortedDictionary<char, int>();

            for (int r = 0; r < rows; r++)
            {
                var rowElements = Console.ReadLine();

                for (int c = 0; c < cols; c++)
                {
                    graph[r, c] = rowElements[c];
                }
            }

            var areasCount = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (visited[r, c])
                    {
                        continue;
                    }

                    var nodeValue = graph[r, c];

                    DFS(r, c, nodeValue);

                    areasCount++;

                    if (areas.ContainsKey(nodeValue))
                    {
                        areas[nodeValue]++;
                    }
                    else
                    {
                        areas.Add(nodeValue, 1);
                    }
                }
            }

            Console.WriteLine($"Areas: {areasCount}");

            foreach (var kvp in areas)
            {
                Console.WriteLine($"Letter '{kvp.Key}' -> {kvp.Value}");
            }
        }

        private static void DFS(int r, int c, char nodeValue)
        {
            if (r < 0 || r >= graph.GetLength(0) || c < 0 || c >= graph.GetLength(1))
            {
                return;
            }

            if (visited[r, c])
            {
                return;
            }

            if (graph[r, c] != nodeValue)
            {
                return;
            }

            visited[r, c] = true;

            DFS(r + 1, c, nodeValue);
            DFS(r - 1, c, nodeValue);
            DFS(r, c - 1, nodeValue);
            DFS(r, c + 1, nodeValue);
        }
    }
}
