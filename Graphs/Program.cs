using System;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            WeightedGraph<Vertex, WeightedEdge> graph = new();

            graph["S"] = new("S");
            graph["1"] = new("1");
            graph["2"] = new("2");
            graph["3"] = new("3");
            graph["4"] = new("4");
            graph["F"] = new("F");

            graph.AddEdge(new WeightedEdge(graph["S"], graph["1"], 5));
            graph.AddEdge(new WeightedEdge(graph["S"], graph["2"], 0));
            graph.AddEdge(new WeightedEdge(graph["1"], graph["3"], 15));
            graph.AddEdge(new WeightedEdge(graph["1"], graph["4"], 20));
            graph.AddEdge(new WeightedEdge(graph["2"], graph["3"], 30));
            graph.AddEdge(new WeightedEdge(graph["2"], graph["4"], 35));
            graph.AddEdge(new WeightedEdge(graph["3"], graph["F"], 20));
            graph.AddEdge(new WeightedEdge(graph["4"], graph["F"], 10));

            var path = graph.DijkstraFindPath(graph["S"], graph["F"], out var t);

            Console.WriteLine(string.Join(" -> ", path));
            Console.WriteLine(t);
        }
    }
}
