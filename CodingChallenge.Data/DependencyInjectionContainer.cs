using CodingChallenge.Data.Abstractions;
using CodingChallenge.Data.Classes;
using Microsoft.Extensions.DependencyInjection;

namespace CodingChallenge.Data
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection ConfigureLanguageHelper(this IServiceCollection services)
        {
            services.AddSingleton<ILanguageHelper, LanguageHelper>();
            return services;
        }

        public static IServiceCollection ConfigureGeometricShapeHandler(this IServiceCollection services)
        {
            services.AddScoped<IGeometricShapeHandler, GeometricShapeHandler>();
            return services;
        }
    }
}