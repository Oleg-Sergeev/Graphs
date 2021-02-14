using System;

namespace Graphs
{
    public interface IVertex : IEquatable<IVertex>
    {
        string Name { get; }
    }
}
