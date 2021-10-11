using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.Json;
using System.Threading;
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
        private const string CardSetsEndpoint = "https://db.ygoprodeck.com/api/v7/cardsets.php";
        private const string CardSetInfoEndpoint = "https://db.ygoprodeck.com/api/v7/cardsetsinfo.php";
        private const string CardArchetypeEndpoint = "https://db.ygoprodeck.com/api/v7/archetypes.php";

        private readonly IYGOProHttpClientService _httpClientService;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public YGOProDeckClient(IYGOProHttpClientService httpClientService,
            IOptions<YGOProClientJsonSerializerOptions> jsonOptions)
        {
            _httpClientService = httpClientService;
            _jsonSerializerOptions = jsonOptions?.Value?.JsonSerializerOptions ??
                                     throw new ArgumentNullException(nameof(jsonOptions));
        }

        public async Task<IEnumerable<BaseCardResponse>> GetCardsAsync(YGOProDeckRequest request,
            CancellationToken cancellationToken = default)
        {
            var query = CardInformationEndpoint + ToQueryString(request.BuildRequest());
            var response = await _httpClientService.GetAsync(query, cancellationToken);
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
                        cards.Add(JsonSerializer.Deserialize<SpellCardResponse>(jsonCardElement.ToString()!,
                            _jsonSerializerOptions));
                        break;
                    }
                    case CardType.SkillCard:
                    {
                        cards.Add(JsonSerializer.Deserialize<SkillCardResponse>(jsonCardElement.ToString()!,
                            _jsonSerializerOptions));
                        break;
                    }
                    case CardType.TrapCard:
                    {
                        cards.Add(JsonSerializer.Deserialize<TrapCardResponse>(jsonCardElement.ToString()!,
                            _jsonSerializerOptions));
                        break;
                    }
                    default:
                    {
                        cards.Add(JsonSerializer.Deserialize<MonsterCardResponse>(jsonCardElement.ToString()!,
                            _jsonSerializerOptions));
                        break;
                    }
                }
            }

            return cards;
        }

        public async Task<IEnumerable<SetResponse>> GetCardSetsAsync(CancellationToken cancellationToken = default)
        {
            var response = await _httpClientService.GetAsync(CardSetsEndpoint, cancellationToken);
            return JsonSerializer.Deserialize<IEnumerable<SetResponse>>(response, _jsonSerializerOptions);
        }

        public async Task<CardSetInformationResponse> GetCardSetInfoAsync(string setCode, CancellationToken cancellationToken = default)
        {
            var query = CardSetInfoEndpoint + ToQueryString(new NameValueCollection { { "setcode", setCode } });
            var response = await _httpClientService.GetAsync(query, cancellationToken);
            return JsonSerializer.Deserialize<CardSetInformationResponse>(response, _jsonSerializerOptions);
        }

        public async Task<IEnumerable<CardArchetypeResponse>> GetCardArchetypesAsync(CancellationToken cancellationToken = default)
        {
            var response = await _httpClientService.GetAsync(CardArchetypeEndpoint, cancellationToken);
            return JsonSerializer.Deserialize<IEnumerable<CardArchetypeResponse>>(response, _jsonSerializerOptions);
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