using CodingChallenge.Data.Abstractions;
using CodingChallenge.Data.Classes;
using CodingChallenge.Data.Classes.Shapes;
using CodingChallenge.Data.Languages;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        private IGeometricShapeHandler geometricShapeHandler;

        [SetUp]
        public void SetUp()
        {
            var serviceManager = ServiceManager.ConfigureService();
            geometricShapeHandler = serviceManager.GetRequiredService<IGeometricShapeHandler>();
        }

        [TearDown]
        public void TearDown()
        {
            // Aquí puedes realizar tareas de limpieza si es necesario
            // Por ejemplo, liberar recursos utilizados por geometricShapeHandler
        }

        [TestCase]
        public void TestSummaryEmptyList()
        {
            var expected = "<h1>Empty list of shapes!</h1>";
            var result = geometricShapeHandler.Print(new List<GeometricShape>(), Language.English);

            Assert.AreEqual(expected, result);
        }

        [TestCase]
        public void TestSummaryEmptyListInSpanish()
        {
            var expected = "<h1>Lista vacía de formas!</h1>";
            var result = geometricShapeHandler.Print(new List<GeometricShape>(), Language.Spanish);

            Assert.AreEqual(expected, result);
        }

        [TestCase]
        public void TestSummaryEmptyListInFrench()
        {
            var expected = "<h1>Liste vide de formes!</h1>";
            var result = geometricShapeHandler.Print(new List<GeometricShape>(), Language.French);

            Assert.AreEqual(expected, result);
        }

        [TestCase]
        public void TestSummaryEmptyListInItalian()
        {
            var expected = "<h1>Lista vuota di forme!</h1>";
            var result = geometricShapeHandler.Print(new List<GeometricShape>(), Language.Italian);

            Assert.AreEqual(expected, result);
        }

        [TestCase]
        public void TestEmptyListPrintsCorrectlyWithoutLanguageChange()
        {
            var expectedFirst = "<h1>Empty list of shapes!</h1>";

            var firstResult = geometricShapeHandler.Print(new List<GeometricShape>(), Language.English);
            var secondResult = geometricShapeHandler.Print(new List<GeometricShape>());

            Assert.AreEqual(expectedFirst, firstResult);
            Assert.AreEqual(firstResult, secondResult);
        }

        [TestCase]
        public void TestEmptyListPrintsCorrectlyWithLanguageChange()
        {
            var expectedFirst = "<h1>Empty list of shapes!</h1>";
            var expectedSecond = "<h1>Lista vacía de formas!</h1>";

            var firstResult = geometricShapeHandler.Print(new List<GeometricShape>(), Language.English);
            var secondResult = geometricShapeHandler.Print(new List<GeometricShape>(), Language.Spanish);

            Assert.AreEqual(expectedFirst, firstResult);
            Assert.AreEqual(expectedSecond, secondResult);
            Assert.AreNotEqual(firstResult, secondResult);
        }

        [TestCase]
        public void TestSummaryListWithSquareInSpanish()
        {
            var expected = "<h1>Reporte de Formas</h1>1 Cuadrado | Área 25 | Perímetro 20 <br/>TOTAL:<br/>1 forma Perímetro 20 Área 25";
            var squareList = new List<GeometricShape> { new Square(sideLength: 5) };

            var result = geometricShapeHandler.Print(squareList, Language.Spanish);

            Assert.AreEqual(expected, result);
        }

        [TestCase]
        public void TestSummaryListWithManySquares()
        {
            var squares = new List<GeometricShape>
            {
                new Square(sideLength: 5),
                new Square(sideLength: 1),
                new Square(sideLength: 3)
            };

            var expected = "<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35";

            var resumen = geometricShapeHandler.Print(squares, Language.English);

            Assert.AreEqual(expected, resumen);
        }

        [TestCase]
        public void TestSummaryListWithManyTypes()
        {
            var shapes = new List<GeometricShape>
            {
                new Square(sideLength: 5),
                new Circle(diameter: 3),
                new EquilateralTriangle(sideLength: 4),
                new Square(sideLength: 2),
                new EquilateralTriangle(sideLength: 9),
                new Circle(diameter: 2.75m),
                new EquilateralTriangle(sideLength: 4.2m)
            };
            var expected = "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13.01 | Perimeter 18.06 <br/>3 Equilateral Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>7 shapes Perimeter 97.66 Area 91.65";

            var result = geometricShapeHandler.Print(shapes, Language.English);

            Assert.AreEqual(expected, result);
        }

        [TestCase]
        public void TestSummaryListWithManyTypesInSpanish()
        {
            var shapes = new List<GeometricShape>
            {
                new Square(sideLength: 5),
                new Circle(diameter: 3),
                new EquilateralTriangle(sideLength: 4),
                new Square(sideLength: 2),
                new EquilateralTriangle(sideLength: 9),
                new Circle(diameter: 2.75m),
                new EquilateralTriangle(sideLength: 4.2m)
            };
            var expected = "<h1>Reporte de Formas</h1>2 Cuadrados | Área 29 | Perímetro 28 <br/>2 Círculos | Área 13,01 | Perímetro 18,06 <br/>3 Triángulos equiláteros | Área 49,64 | Perímetro 51,6 <br/>TOTAL:<br/>7 formas Perímetro 97,66 Área 91,65";

            var result = geometricShapeHandler.Print(shapes, Language.Spanish);

            Assert.AreEqual(expected, result);
        }

        [TestCase]
        public void TestThrowWhenWidthIsZero()
        {
            Assert.Catch(() => new Square(sideLength: 0));
        }

        [TestCase]
        public void TestThrowWhenWidthIsNegative()
        {
            Assert.Catch(() => new Circle(diameter: -5));
        }
    }
}