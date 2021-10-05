using System;
using System.Text.Json;
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
    }
}