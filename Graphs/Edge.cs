namespace Graphs
{
    public class Edge : IEdge
    {
        public IVertex From { get; }
        public IVertex To { get; }


        public Edge(IVertex from, IVertex to)
        {
            From = from;
            To = to;
        }


        public static bool operator ==(Edge e1, Edge e2) => e1.Equals(e2);
        public static bool operator !=(Edge e1, Edge e2) => !e1.Equals(e2);


        public virtual bool Equals(IEdge edge)
        {
            if (edge == default) return false;

            return (From.Equals(edge.From) && To.Equals(edge.To))
                || (From.Equals(edge.To) && To.Equals(edge.From));
        }
        public override bool Equals(object obj)
        {
            if (obj is not Edge edge) return false;

            return Equals(edge);
        }

        public override int GetHashCode() => From.GetHashCode() + To.GetHashCode();

        public override string ToString() => $"{From}; {To}";
    }
}
