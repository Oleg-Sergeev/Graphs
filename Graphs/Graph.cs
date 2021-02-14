namespace Graphs
{
    public class Graph<V> : AbstractGraph<V, Edge> where V : IVertex
    {
        public override bool IsOriented => false;
    }
}
