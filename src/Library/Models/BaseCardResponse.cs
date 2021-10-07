﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YGOProDeckWrapper.Library.Models
{
    public class BaseCardResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CardType Type { get; set; }
        [JsonPropertyName("desc")]
        public string Description { get; set; }
        public string Archetype { get; set; }
        [JsonPropertyName("card_sets")]
        public List<CardSetResponse> Sets { get; set; }
        [JsonPropertyName("card_images")]
        public List<CardImageResponse> Images { get; set; }
        [JsonPropertyName("card_prices")]
        public List<CardPriceResponse> Prices { get; set; }
    }

    public class MonsterCardResponse : BaseCardResponse
    {
        public MonsterRace Race { get; set; }
    }

    public class SpellCardResponse : BaseCardResponse
    {
        public SpellRace Race { get; set; }
    }

    public class TrapCardResponse : BaseCardResponse
    {
        public TrapRace Race { get; set; }
    }
}