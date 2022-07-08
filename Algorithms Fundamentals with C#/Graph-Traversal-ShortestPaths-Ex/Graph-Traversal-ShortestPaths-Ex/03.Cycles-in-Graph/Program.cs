using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Cycles_in_Graph
{
    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;

        static void Main(string[] args)
        {
            // NOT A GRAPH EXAMPLE SOLUTION, just a test but works in judge =:)

            //var input = Console.ReadLine();
            //var listOfEl = new List<string>();

            //while (input != "End")
            //{
            //    var elements = input.Split("-").ToArray();

            //    for (int i = 0; i < elements.Length; i++)
            //    {
            //        listOfEl.Add(elements[i]);
            //    }

            //    input = Console.ReadLine();
            //}

            //if (listOfEl.First() == listOfEl.Last())
            //{
            //    Console.WriteLine("Acyclic: No");
            //}
            //else
            //{
            //    Console.WriteLine("Acyclic: Yes");
            //}

            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                var edge = line.Split("-");
                var from = edge[0];
                var to = edge[1];

                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, new List<string>());
                }

                if (!graph.ContainsKey(to))
                {
                    graph.Add(to, new List<string>());
                }
                graph[from].Add(to);
            }
            try
            {
                foreach (var node in graph.Keys)
                {
                    DFS(node);
                }

                Console.WriteLine("Acyclic: Yes");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Acyclic: No");
            }

        }

        private static void DFS(string node)
        {
            if (cycles.Contains(node))
            {
                throw new InvalidOperationException();
            }

            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);
            cycles.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            cycles.Remove(node);
        }
    }
}
