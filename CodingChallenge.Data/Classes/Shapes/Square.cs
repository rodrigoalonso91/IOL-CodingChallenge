using Dawn;

namespace CodingChallenge.Data.Classes.Shapes
{
    public class Square : GeometricShape
    {
        public override int Sides => 4;
        public decimal SideLength { get; private set; }

        public Square(decimal sideLength)
        {
            Guard.Argument(sideLength, nameof(sideLength)).NotZero().NotNegative();
            SideLength = sideLength;
        }

        public override decimal GetArea()
        {
            return SideLength * SideLength;
        }

        public override decimal GetPerimeter()
        {
            return SideLength * Sides;
        }
    }
}