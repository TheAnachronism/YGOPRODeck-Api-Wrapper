using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace YGOProDeckWrapper.Library.Services
{
    public interface IHttpClientService
    {
        Task<string> GetAsync(string url, CancellationToken cancellationToken = default);
    }

    internal class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAsync(string url, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync(url, cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw new HttpFailedRequestException(response.StatusCode, response.ReasonPhrase, url);

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            var document = JsonDocument.Parse(content);
            
            if (document.RootElement.ValueKind is JsonValueKind.Array ||
                !document.RootElement.TryGetProperty("data", out var dataProperty))
                return content;
            
            return dataProperty.ToString();
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