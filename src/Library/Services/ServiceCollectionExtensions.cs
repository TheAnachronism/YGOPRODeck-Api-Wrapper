using Microsoft.Extensions.DependencyInjection;
using YGOProDeckWrapper.Library.Client;

namespace YGOProDeckWrapper.Library.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddYGOProDeckServices(this IServiceCollection services)
        {
            services.Configure<YGOProClientJsonSerializerOptions>(opt =>
            {
                opt.JsonSerializerOptions = YGOProClientJsonSerializerOptions.DefaultSerializerOptions;
            });
            
            services.AddTransient<IYGOProDeckClient, YGOProDeckClient>();
            services.AddHttpClient<IYGOProHttpClientService, YGOProHttpClientService>();
            return services;
        }
    }
}