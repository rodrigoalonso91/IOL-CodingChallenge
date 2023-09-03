using CodingChallenge.Data.Abstractions;
using Dawn;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public class GeometricShapeHandler : IGeometricShapeHandler
    {
        private readonly ILanguageHelper _languageHelper;

        public GeometricShapeHandler(ILanguageHelper languageHelper)
        {
            _languageHelper = languageHelper;
        }

        public string Print(List<GeometricShape> shapes, string language = "")
        {
            if (!string.IsNullOrWhiteSpace(language))
            {
                _languageHelper.ChangeLanguage(language);
            }

            var sb = new StringBuilder();

            if (!shapes.Any())
            {
                var emptyListMsg = _languageHelper.GetString("EmptyListMsg");
                EnsureTextIsNotEmpty("EmptyListMsg", emptyListMsg);

                sb.Append(emptyListMsg);
                return sb.ToString();
            }

            var headerText = _languageHelper.GetString("Header");
            EnsureTextIsNotEmpty("Header", headerText);
            sb.Append(headerText);

            var groupedShapes = shapes.GroupBy(shape => shape.GetType());
            var shapesAmount = groupedShapes.ToDictionary(group => group.Key.Name, group => group.Count());
            var shapeAreas = groupedShapes.ToDictionary(group => group.Key.Name, group => group.Select(shape => shape.GetArea()).Aggregate((item, acc) => item + acc));
            var shapePerimeters = groupedShapes.ToDictionary(group => group.Key.Name, group => group.Select(shape => shape.GetPerimeter()).Aggregate((item, acc) => item + acc));

            var areaText = _languageHelper.GetString("Area");
            var perimeterText = _languageHelper.GetString("Perimeter");

            EnsureTextIsNotEmpty("Area", areaText);
            EnsureTextIsNotEmpty("Perimeter", perimeterText);

            foreach (var shape in shapesAmount)
            {
                var keyText = _languageHelper.GetString(shape.Key);
                var pluralKeyText = _languageHelper.GetString(shape.Key + "s");
                EnsureTextIsNotEmpty(shape.Key, keyText);
                EnsureTextIsNotEmpty(shape.Key + "s", pluralKeyText);

                var text = (shape.Value == 1)
                            ? $"1 {keyText} | {areaText} {shapeAreas[shape.Key]:#.##} | {perimeterText} {shapePerimeters[shape.Key]:#.##} <br/>"
                            : $"{shape.Value} {pluralKeyText} | {areaText} {shapeAreas[shape.Key]:#.##} | {perimeterText} {shapePerimeters[shape.Key]:#.##} <br/>";

                sb.Append(text);
            }

            var totalText = _languageHelper.GetString("Total");
            EnsureTextIsNotEmpty("Total", totalText);
            sb.Append(totalText);

            var whiteSpace = " ";
            var shapeText = _languageHelper.GetString("shape");
            var shapeTextInPlural = _languageHelper.GetString("shapes");

            EnsureTextIsNotEmpty("shape", shapeText);
            EnsureTextIsNotEmpty("shapes", shapeTextInPlural);

            sb.Append(shapes.Count().ToString() + whiteSpace + (shapes.Count() > 1 ? shapeTextInPlural : shapeText) + whiteSpace);
            sb.Append($"{perimeterText} " + shapePerimeters.Values.Sum().ToString("#.##") + whiteSpace);
            sb.Append($"{areaText} " + shapeAreas.Values.Sum().ToString("#.##"));

            return sb.ToString();
        }

        private void EnsureTextIsNotEmpty(string key, string text)
        {
            Guard.Argument(text, key).NotEmpty($"The text associated with key '{key}' must not be empty. Please refer to the '{_languageHelper.GetCurrentLanguage()}' .resx file");
        }
    }
}