Claro, aquí tienes el texto con algunas mejoras en la claridad:

# InvertirOnline.com Coding Challenge - Rodrigo Alonso

## Detalles generales

Por una preferencia personal y dado que el desafío lo permitía, opté por cambiar el idioma de las clases, métodos y propiedades al inglés.

## Antes que nada

- Ejecutar Nuget Restore
- Ejecutar compilación
- Correr los test

## Solución

El objetivo principal era facilitar la incorporación de nuevas figuras geométricas y la adición de idiomas de manera más dinámica.

La clase original "FormaGeométrica" fue reemplazada por una clase llamada "GeometricShapeHandler". Esta última recibe la funcionalidad de manejar diferentes idiomas a través de la inyección de dependencias desde la clase "LanguageHelper".

Para agregar una nueva figura geométrica, simplemente se debe crear una clase en la carpeta **shapes** y hacer que herede de la clase base "GeometricShape". Luego, se implementa la lógica correspondiente para calcular el área, el perímetro y la cantidad de lados, entre otros atributos.

La incorporación de un nuevo idioma requiere la creación de un archivo .resx en la carpeta **Languages** siguiendo el formato: "strings.<idiomaDeseado>.resx", por ejemplo, **strings.de.resx** para el idioma alemán. En este archivo, se deben respetar las claves del archivo original y reemplazar los valores por los mensajes en el idioma correspondiente. Finalmente, se debe agregar el idioma en la clase "Language.cs", ya que este objeto se utiliza en el método "Print" de la clase "GeometricShapeHandler":

```csharp
public static class Language
{
    public const string English = "en";
    public const string Spanish = "es";
    public const string French = "fr";
    public const string Italian = "it";
    public const string German = "de"; <-- Nuevo idioma
}
```
