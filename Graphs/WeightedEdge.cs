namespace Graphs
{
    public class WeightedEdge : Edge, IWeightedEdge
    {
        public int Weight { get; }


        public WeightedEdge(IVertex from, IVertex to, int weight) : base(from, to)
        {
            Weight = weight;
        }

        public override string ToString() => $"{base.ToString()} ({Weight})";
    }
}
