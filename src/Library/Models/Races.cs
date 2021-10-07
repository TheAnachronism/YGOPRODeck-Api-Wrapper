using System.Text.Json.Serialization;

namespace YGOProDeckWrapper.Library.Models
{
    public enum MonsterRace
    {
        Aqua,
        Beast,
        [JsonPropertyName("beast-warrior")]
        BeastWarrior,
        [JsonPropertyName("Creator-god")]
        CreatorGod,
        Cyberse,
        Dinosaur,
        [JsonPropertyName("divine beast")]
        DivineBeast,
        Dragon,
        Fairy,
        Fiend,
        Fish,
        Insect,
        Machine,
        Plant,
        Psychic,
        Pyro,
        Reptile,
        Rock,
        [JsonPropertyName("sea serpent")]
        SeaSerpent,
        SpellCaster,
        Thunder,
        Warrior,
        [JsonPropertyName("winged beast")]
        WingedBeast
    }

    public enum SpellRace
    {
        Normal,
        Field,
        Equip,
        Continuous,
        [JsonPropertyName("Quick-Play")]
        QuickPlay,
        Ritual
    }

    public enum TrapRace
    {
        Normal,
        Continuous,
        Counter
    }
}