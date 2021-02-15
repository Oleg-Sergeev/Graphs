using System;
using System.Collections.Generic;

namespace Graphs
{
    public class Graph<V, E> : IGraph<V,E> where V : IVertex where E : IEdge
    {
        public virtual bool IsOriented { get; }

        public V this[string name]
        {
            get => _vertices[name];
            set => _vertices[name] = value;
        }
        public E this[V v1, V v2] => GetEdge(v1, v2);

        public IReadOnlyCollection<V> Vertices => _vertices.Values;
        public IReadOnlyCollection<E> Edges => _edges.Values;
        

        protected readonly Dictionary<string, V> _vertices;
        protected readonly Dictionary<int, E> _edges;


        public Graph(bool isOriented = false)
        {
            _vertices = new();
            _edges = new();

            IsOriented = isOriented;
        }


        public virtual void AddVertex(V vertex)
        {
            if (!TryAddVertex(vertex))
                throw new ArgumentException($"An item with the same key has already been added. Key: {vertex}", nameof(vertex));
        }
        public virtual bool TryAddVertex(V vertex) 
            => _vertices.TryAdd(vertex.Name, vertex);

        public virtual void AddEdge(E edge)
        {
            if (!TryAddEdge(edge))
                throw new ArgumentException($"An item with the same key has already been added. Key: {edge}", nameof(edge));
        }
        public virtual bool TryAddEdge(E edge)
        {
            var hashCode = edge.GetHashCode();

            if (IsOriented || !_edges.ContainsKey(-hashCode)) return _edges.TryAdd(hashCode, edge);
            else return false;
        }


        public E GetEdge(V v1, V v2)
        {
            foreach (var edge in Edges)
            {
                if (edge.From.Equals(v1) && edge.To.Equals(v2)) return edge;
                else if (!IsOriented && edge.From.Equals(v2) && edge.To.Equals(v1)) return edge;
            }

            return default;
        }


        public IReadOnlyCollection<E> GetChildsEdges(IVertex vertex)
        {
            var vertices = new List<E>();

            foreach (var edge in Edges)
            {
                if (edge.From.Equals(vertex)) vertices.Add(edge);
                else if (!IsOriented && edge.To.Equals(vertex)) vertices.Add(edge);
            }

            return vertices;
        }

        public IReadOnlyCollection<V> GetChildsVertices(IVertex vertex)
        {
            var vertices = new List<V>();

            foreach (var edge in Edges)
            {
                if (edge.From.Equals(vertex)) vertices.Add((V)edge.To);
                else if (!IsOriented && edge.To.Equals(vertex)) vertices.Add((V)edge.From);
            }

            return vertices;
        }


        public override string ToString()
        {
            var graph = "";
            foreach (var vertex in _vertices.Values)
                graph += $"{vertex}: {string.Join(", ", GetChildsVertices(vertex))}\n";

            return graph;
        }
    }
}
