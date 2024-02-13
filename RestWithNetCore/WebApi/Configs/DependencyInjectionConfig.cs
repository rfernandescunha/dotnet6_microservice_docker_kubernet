using WebApi.Ioc;

namespace WebApi.Configs
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //InjectionRepository.Register(services, configuration);
            InjectionService.Register(services);
        }
    }
}
