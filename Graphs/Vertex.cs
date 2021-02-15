namespace Graphs
{
    public class Vertex : IVertex
    {
        public string Name { get; }


        public Vertex(string name)
        {
            Name = name;
        }


        public static bool operator ==(Vertex v1, Vertex v2) => v1.Equals(v2);
        public static bool operator !=(Vertex v1, Vertex v2) => !v1.Equals(v2);



        public bool Equals(IVertex vertex) => vertex != default && vertex.Name == Name;
        public override bool Equals(object obj) => obj is Vertex vertex && Equals(vertex);

        public override int GetHashCode() => Name.GetHashCode();


        public override string ToString() => Name;
    }
}
