using System;

namespace Graphs
{
    public interface IEdge : IEquatable<IEdge>
    {
        IVertex From { get; }
        IVertex To { get; }
    }
}
