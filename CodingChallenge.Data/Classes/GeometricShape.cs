using CodingChallenge.Data.Abstractions;

namespace CodingChallenge.Data.Classes
{
    public abstract class GeometricShape : IGeometricShape
    {
        public abstract int Sides { get; }

        public abstract decimal GetArea();

        public abstract decimal GetPerimeter();
    }
}