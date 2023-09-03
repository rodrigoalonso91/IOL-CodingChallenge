using Dawn;

namespace CodingChallenge.Data.Classes.Shapes
{
    public class Rectangle : GeometricShape
    {
        public override int Sides => 4;
        public decimal Height { get; private set; }
        public decimal Width { get; private set; }

        public Rectangle(decimal width, decimal height)
        {
            Guard.Argument(width, nameof(width)).NotZero().NotNegative();
            Guard.Argument(height, nameof(height)).NotZero().NotNegative();

            Width = width;
            Height = height;
        }

        public override decimal GetArea()
        {
            return Width * Height;
        }

        public override decimal GetPerimeter()
        {
            return (Width * 2) + (Height * 2);
        }
    }
}