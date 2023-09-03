using Dawn;
using System;

namespace CodingChallenge.Data.Classes.Shapes
{
    public class Circle : GeometricShape
    {
        public decimal Diameter { get; private set; }
        public decimal Radius => Diameter / 2;

        public override int Sides => 1;

        public Circle(decimal diameter)
        {
            Guard.Argument(diameter, nameof(diameter)).NotZero().NotNegative();
            Diameter = diameter;
        }

        public override decimal GetArea()
        {
            var radiusSquared = (decimal)Math.Pow(Convert.ToDouble(Radius), 2);
            var pi = (decimal)Math.PI;

            return pi * radiusSquared;
        }

        public override decimal GetPerimeter()
        {
            return (decimal)Math.PI * Diameter;
        }
    }
}