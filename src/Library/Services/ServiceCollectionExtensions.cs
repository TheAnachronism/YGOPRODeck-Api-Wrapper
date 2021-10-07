using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using YGOProDeckWrapper.Library.Client;
using YGOProDeckWrapper.Library.Converters;

namespace YGOProDeckWrapper.Library.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddYGOProDeckServices(this IServiceCollection services)
        {
            services.Configure<YGOProClientJsonSerializerOptions>(opt =>
            {
                opt.JsonSerializerOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters =
                    {
                        new JsonStringEnumMemberConverter(),
                        new StringDecimalJsonConverter()
                    }
                };
            });
            
            services.AddTransient<IYGOProDeckClient, YGOProDeckClient>();
            services.AddHttpClient<IHttpClientService, HttpClientService>();
            return services;
        }
    }
}