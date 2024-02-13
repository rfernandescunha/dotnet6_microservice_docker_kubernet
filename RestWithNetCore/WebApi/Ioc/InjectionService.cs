using WebApi.Services;
using WebApi.Services.Interfaces;

namespace WebApi.Ioc
{
    public static class InjectionService
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPersonServices, PersonServices>();

        }
    }
}