using System;
using System.Collections.Generic;

namespace Graphs
{
    public class WeightedGraph<V, E> : AbstractGraph<V, E> where V : IVertex where E : IWeightedEdge
    {
        public override bool IsOriented => true;


        public IReadOnlyCollection<IVertex> DijkstraFindPath(IVertex start, IVertex end, out int cost)
        {
            if (start == null) throw new ArgumentNullException(nameof(start), "vertex is null");
            if (end == null) throw new ArgumentNullException(nameof(end), "vertex is null");

            cost = 0;

            if (start == end) return new List<IVertex>() { start };


            Dictionary<string, DijkstraNode> nodes = new()
            {
                { start.Name, new(start, 0) }
            };

            foreach (var edge in GetChildsEdges(start))
                nodes.Add(edge.To.Name, new(edge.To, edge.Weight, nodes[start.Name]));

            foreach (var vertex in _vertices.Values)
                nodes.TryAdd(vertex.Name, new(vertex, int.MaxValue));


            DijkstraNode currentNode;
            while ((currentNode = GetTheCheapiestNode()) != null && currentNode.Vertex != end)
            {
                foreach (var node in GetChildsNodes(currentNode.Vertex))
                {
                    var edge = GetEdge((V)currentNode.Vertex, (V)node.Vertex);
                    var totalWeight = currentNode.Weight + edge.Weight;

                    if (totalWeight < node.Weight)
                    {
                        node.Weight = totalWeight;
                        node.Parent = currentNode;
                    }
                }
                currentNode.HasProcessed = true;
            }

            var path = CreatePath(ref cost);

            return path;


            DijkstraNode GetTheCheapiestNode()
            {
                DijkstraNode theCheapiestNode = null;
                var weight = int.MaxValue;

                foreach (var node in nodes.Values)
                {
                    if (node.HasProcessed) continue;

                    if (node.Weight < weight)
                    {
                        weight = node.Weight;
                        theCheapiestNode = node;
                    }
                }


                return theCheapiestNode;
            }

            IEnumerable<DijkstraNode> GetChildsNodes(IVertex vertex)
            {
                List<DijkstraNode> childs = new();

                foreach (var vertex_ in GetChildsVertices(vertex))
                    childs.Add(nodes[vertex_.Name]);

                return childs;
            }

            IReadOnlyCollection<IVertex> CreatePath(ref int pathCost)
            {
                var node = nodes[end.Name];

                var vertices = new List<IVertex>();

                while ((node = node.Parent) != null) 
                    vertices.Add(node.Vertex);

                if (vertices.Count == 0) return vertices;

                node = nodes[end.Name];

                vertices.Reverse();
                vertices.Add(node.Vertex);

                pathCost = node.Weight;

                return vertices;
            }
        }
        public IReadOnlyCollection<IVertex> DijkstraFindPath(IVertex start, IVertex end)
            => DijkstraFindPath(start, end, out _);


        private class DijkstraNode
        {
            public DijkstraNode Parent { get; set; }

            public IVertex Vertex { get; set; }

            public int Weight { get; set; }

            public bool HasProcessed { get; set; }


            public DijkstraNode(IVertex vertex, int weight, DijkstraNode parent = null)
            {
                Vertex = vertex;
                Weight = weight;
                Parent = parent;

                HasProcessed = false;
            }


            public override string ToString() => Vertex.Name;
        }
    }
}
