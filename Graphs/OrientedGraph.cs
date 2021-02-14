namespace Graphs
{
    public class OrientedGraph<V> : AbstractGraph<V, OrientedEdge> where V : IVertex
    {
        public override bool IsOriented => true;
    }
}
