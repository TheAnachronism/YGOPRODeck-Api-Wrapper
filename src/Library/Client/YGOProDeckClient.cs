using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Options;
using YGOProDeckWrapper.Library.Services;

namespace YGOProDeckWrapper.Library.Client
{
    internal class YGOProDeckClient : IYGOProDeckClient
    {
        private readonly IHttpClientService _httpClientService;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public YGOProDeckClient(IHttpClientService httpClientService, IOptions<YGOProClientJsonSerializerOptions> jsonOptions)
        {
            _httpClientService = httpClientService;
            _jsonSerializerOptions = jsonOptions?.Value?.JsonSerializerOptions ?? throw new ArgumentNullException(nameof(jsonOptions));
        }
        
        public async Task GetCards(YGOProDeckRequest request)
        {
            var query = ToQueryString(request.BuildRequest());
            var response = await _httpClientService.GetAsync(query);
        }
        
        private static string ToQueryString(NameValueCollection nvc)
        {
            var array = (
                from key in nvc.AllKeys
                from value in nvc.GetValues(key)
                select $"{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(value)}"
            ).ToArray();
            return "?" + string.Join("&", array);
        }
    }
}