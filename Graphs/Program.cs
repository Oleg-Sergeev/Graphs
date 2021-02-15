using System;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            WeightedGraph<Vertex, WeightedEdge> graph = new(false);

            graph["1"] = new("1");
            graph["2"] = new("2");
            graph["3"] = new("3");
            graph["4"] = new("4");


            graph.TryAddEdge(new(graph["1"], graph["2"], 3));
            graph.TryAddEdge(new(graph["2"], graph["1"], 5));
            graph.TryAddEdge(new(graph["1"], graph["3"], 10));
            graph.TryAddEdge(new(graph["1"], graph["1"], 15));
            graph.TryAddEdge(new(graph["4"], graph["3"], 5));

            Console.WriteLine(string.Join("\n", graph.GetChildsEdges(graph["1"])));
        }
    }
}
