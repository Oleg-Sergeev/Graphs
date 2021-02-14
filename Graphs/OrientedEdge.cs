using System;

namespace Graphs
{
    public class OrientedEdge : Edge
    {
        public OrientedEdge(IVertex from, IVertex to) : base(from, to) { }


        public static bool operator ==(OrientedEdge e1, OrientedEdge e2) => e1.Equals(e2);
        public static bool operator !=(OrientedEdge e1, OrientedEdge e2) => !e1.Equals(e2);


        public override bool Equals(IEdge edge)
        {
            if (edge == default) return false;

            return From.Equals(edge.From) && To.Equals(edge.To);
        }
        public override bool Equals(object obj)
        {
            if (obj is not OrientedEdge edge) return false;

            return Equals(edge);
        }

        public override int GetHashCode() => HashCode.Combine(From, To);

        public override string ToString() => $"{From} -> {To}";
    }
}
