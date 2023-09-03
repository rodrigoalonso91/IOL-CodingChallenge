using Dawn;
using System;

namespace CodingChallenge.Data.Classes.Shapes
{
    public class EquilateralTriangle : GeometricShape
    {
        public override int Sides => 3;
        public decimal SideLength { get; private set; }

        public EquilateralTriangle(decimal sideLength)
        {
            Guard.Argument(sideLength, nameof(sideLength)).NotZero().NotNegative();
            SideLength = sideLength;
        }

        public override decimal GetArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * (SideLength * SideLength);
        }

        public override decimal GetPerimeter()
        {
            return SideLength * Sides;
        }
    }
}