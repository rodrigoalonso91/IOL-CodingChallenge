using Dawn;
using System;

namespace CodingChallenge.Data.Classes.Shapes
{
    public class RectangularTrapezium : GeometricShape
    {
        public override int Sides => 4;
        public decimal MayorBase { get; private set; }
        public decimal MinorBase { get; private set; }
        public decimal SideLength { get; private set; }
        public decimal Height { get; private set; }

        public RectangularTrapezium(decimal mayorBase, decimal minorBase, decimal sideLength, decimal height)
        {
            Guard.Argument(mayorBase, nameof(mayorBase)).NotZero().NotNegative();
            Guard.Argument(minorBase, nameof(minorBase)).NotZero().NotNegative();
            Guard.Argument(sideLength, nameof(sideLength)).NotZero().NotNegative();
            Guard.Argument(height, nameof(height)).NotZero().NotNegative();

            MayorBase = mayorBase;
            MinorBase = minorBase;
            SideLength = sideLength;
            Height = height;
        }

        public override decimal GetArea()
        {
            return ((MayorBase + MinorBase) * Height) / 2;
        }

        public override decimal GetPerimeter()
        {
            return MayorBase + MinorBase + SideLength + Height;
        }
    }
}