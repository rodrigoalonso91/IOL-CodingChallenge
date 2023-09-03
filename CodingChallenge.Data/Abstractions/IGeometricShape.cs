using CodingChallenge.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Abstractions
{
    public interface IGeometricShape
    {
        int Sides { get; }
        decimal GetPerimeter();
        decimal GetArea();
    }
}