using System.Reflection;

using DAL;

using SlnAssembly.Attributes;

namespace API.Gate.Configuration
{
    public static class DALExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var dbStoredModels = GetDbStoredTypes(assembly, typeof(DALRepository));
            foreach (var type in dbStoredModels)
            {
                services.AddRepository(type);
            }
            return services;
        }

        private static IServiceCollection AddRepository(this IServiceCollection services, Type modelType)
        {
            var repository = typeof(Repository<>).MakeGenericType(modelType);
            services.AddTransient(repository);

            return services;
        }

        private static IEnumerable<Type> GetDbStoredTypes(Assembly assembly, Type attributeType)
        {
            foreach(var type in assembly.GetTypes())
            {
                if(type.GetCustomAttributes(attributeType, true).Length > 0)
                {
                    yield return type;
                }
            }
        }
    }
}
