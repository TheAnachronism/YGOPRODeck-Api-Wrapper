using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace YGOProDeckWrapper.Library.Services
{
    public interface IHttpClientService
    {
        Task<string> GetAsync(string url);
    }

    internal class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new HttpFailedRequestException(response.StatusCode, response.ReasonPhrase, url);

            var content = await response.Content.ReadAsStringAsync();
            var document = JsonDocument.Parse(content);
            return document.RootElement.ValueKind == JsonValueKind.Array
                ? content
                : document.RootElement.GetProperty("data")
                    .ToString();
        }
    }
    
    internal class HttpFailedRequestException : Exception
    {
        public HttpFailedRequestException(HttpStatusCode statusCode, string reasonPhrase, string url)
            : this(GenerateGetException(statusCode, reasonPhrase, url))
        {
        }
        
        private static string GenerateGetException(HttpStatusCode statusCode, string reasonPhrase, string url)
            => $"Status Code : {(int)statusCode} - Reason Phrase: {reasonPhrase} : url: {url}";
        
        public HttpFailedRequestException(string message) : base(message)
        {
        }
    }
}