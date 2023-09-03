using CodingChallenge.Data.Classes;
using System.Collections.Generic;

namespace CodingChallenge.Data.Abstractions
{
    public interface IGeometricShapeHandler
    {
        string Print(List<GeometricShape> shapes, string language = "");
    }
}