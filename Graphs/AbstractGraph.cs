using System.Collections.Generic;

namespace Graphs
{
    public abstract class AbstractGraph<V, E> : IGraph<V> where V : IVertex where E : IEdge
    {
        public abstract bool IsOriented { get; }

        public V this[string name]
        {
            get => _vertices[name];
            set => _vertices[name] = value;
        }

        public IReadOnlyCollection<V> Vertices => _vertices.Values;
        protected readonly Dictionary<string, V> _vertices;

        public IReadOnlyCollection<E> Edges => _edges;
        protected readonly HashSet<E> _edges;


        public AbstractGraph()
        {
            _vertices = new();
            _edges = new();
        }


        public virtual void AddVertex(V vertex)
        {
            _vertices.Add(vertex.Name, vertex);
        }

        public virtual void AddEdge(E edge)
        {
            _edges.Add(edge);
        }


        public E GetEdge(V v1, V v2)
        {
            foreach (var edge in _edges)
            {
                if (edge.From.Equals(v1) && edge.To.Equals(v2)) return edge;
                else if (!IsOriented && edge.From.Equals(v2) && edge.To.Equals(v1)) return edge;
            }

            return default;
        }

        public IReadOnlyCollection<E> GetChildsEdges(IVertex vertex)
        {
            var vertices = new List<E>();

            foreach (var edge in _edges)
            {
                if (edge.From.Equals(vertex)) vertices.Add(edge);
                else if (!IsOriented && edge.To.Equals(vertex)) vertices.Add(edge);
            }

            return vertices;
        }

        public IReadOnlyCollection<IVertex> GetChildsVertices(IVertex vertex)
        {
            var vertices = new List<IVertex>();

            foreach (var edge in _edges)
            {
                if (edge.From.Equals(vertex)) vertices.Add(edge.To);
                else if (!IsOriented && edge.To.Equals(vertex)) vertices.Add(edge.From);
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
