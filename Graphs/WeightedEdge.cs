namespace Graphs
{
    public class WeightedEdge : OrientedEdge, IWeightedEdge
    {
        public int Weight { get; set; }

        public WeightedEdge(IVertex from, IVertex to, int weight) : base(from, to)
        {
            Weight = weight;
        }


        public override string ToString() => $"{From} -> {To} ({Weight})";
    }
}
