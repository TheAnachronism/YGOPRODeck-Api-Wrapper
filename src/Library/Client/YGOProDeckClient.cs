using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Options;
using YGOProDeckWrapper.Library.Models;
using YGOProDeckWrapper.Library.Services;

namespace YGOProDeckWrapper.Library.Client
{
    internal class YGOProDeckClient : IYGOProDeckClient
    {
        private const string CardInformationEndpoint = "https://db.ygoprodeck.com/api/v7/cardinfo.php";
        
        private readonly IHttpClientService _httpClientService;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public YGOProDeckClient(IHttpClientService httpClientService, IOptions<YGOProClientJsonSerializerOptions> jsonOptions)
        {
            _httpClientService = httpClientService;
            _jsonSerializerOptions = jsonOptions?.Value?.JsonSerializerOptions ?? throw new ArgumentNullException(nameof(jsonOptions));
        }
        
        public async Task<List<BaseCardResponse>> GetCards(YGOProDeckRequest request)
        {
            var query = CardInformationEndpoint + ToQueryString(request.BuildRequest());
            var response = await _httpClientService.GetAsync(query);
            var array = JsonDocument.Parse(response);

            var cards = new List<BaseCardResponse>();
            
            foreach (var jsonCardElement in array.RootElement.EnumerateArray())
            {
                var typeString = $"\"{jsonCardElement.GetProperty("type").ToString()}\"";
                var type = JsonSerializer.Deserialize<CardType>(typeString!, _jsonSerializerOptions);
                switch (type)
                {
                    case CardType.SpellCard:
                    {
                        cards.Add(JsonSerializer.Deserialize<SpellCardResponse>(jsonCardElement.ToString()!, _jsonSerializerOptions));
                        break;
                    }
                    case CardType.SkillCard:
                    {
                        cards.Add(JsonSerializer.Deserialize<SkillCardResponse>(jsonCardElement.ToString()!, _jsonSerializerOptions));
                        break;
                    }
                    case CardType.TrapCard:
                    {
                        cards.Add(JsonSerializer.Deserialize<TrapCardResponse>(jsonCardElement.ToString()!, _jsonSerializerOptions));
                        break;
                    }
                    default:
                    {
                        cards.Add(JsonSerializer.Deserialize<MonsterCardResponse>(jsonCardElement.ToString()!, _jsonSerializerOptions));
                        break;
                    }
                }
            }

            return cards;
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