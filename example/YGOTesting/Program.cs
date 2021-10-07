using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using YGOProDeckWrapper.Library.Client;
using YGOProDeckWrapper.Library.Services;

namespace YGOTesting
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddHttpClient()
                .AddYGOProDeckServices()
                .BuildServiceProvider();

            var client = services.GetRequiredService<IYGOProDeckClient>();
            var request = YGOProDeckRequest.CreateRequest().WithName("Solemn Warning");
            var response = await client.GetCards(request);
        }
    }
}