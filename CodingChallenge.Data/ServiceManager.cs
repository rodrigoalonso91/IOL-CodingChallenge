using Microsoft.Extensions.DependencyInjection;

namespace CodingChallenge.Data
{
    public class ServiceManager
    {
        public static ServiceProvider ConfigureService()
        {
            return new ServiceCollection()
                        .ConfigureLanguageHelper()
                        .ConfigureGeometricShapeHandler()
                        .BuildServiceProvider();
        }
    }
}