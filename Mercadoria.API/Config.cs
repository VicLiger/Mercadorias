using Mercadorias.DependencyInjection.IoC;

namespace Mercadoria.Teste
{
    public static class Config
    {
        public static void ConfigurationInfraestructure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfraestructure(configuration);
        }
    }
}
