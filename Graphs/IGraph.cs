using System.Collections.Generic;

namespace Graphs
{
    public interface IGraph<V, E> where V : IVertex where E : IEdge
    {
        bool IsOriented { get; }

        IReadOnlyCollection<V> Vertices { get; }
        IReadOnlyCollection<E> Edges { get; }


        public void AddVertex(V vertex);

        public void AddEdge(E edge);
    }
}
