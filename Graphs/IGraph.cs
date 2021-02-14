using System.Collections.Generic;

namespace Graphs
{
    public interface IGraph<V> where V : IVertex
    {
        public IReadOnlyCollection<V> Vertices { get; }

        public V this[string name] { get; set; }

        public bool IsOriented { get; }

        void AddVertex(V vertex);
    }
}
