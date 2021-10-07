using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace YGOProDeckWrapper.Library.Models
{
    public enum MonsterCardRace
    {
        Aqua,
        Beast,
        [EnumMember(Value = "beast-warrior")]
        BeastWarrior,
        [EnumMember(Value = "Creator-god")]
        CreatorGod,
        Cyberse,
        Dinosaur,
        [EnumMember(Value = "divine beast")]
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
        [EnumMember(Value = "sea serpent")]
        SeaSerpent,
        SpellCaster,
        Thunder,
        Warrior,
        [EnumMember(Value = "winged beast")]
        WingedBeast,
        Wyrm,
        Zombie
    }

    public enum SpellCardRace
    {
        Normal,
        Field,
        Equip,
        Continuous,
        [EnumMember(Value = "Quick-Play")]
        QuickPlay,
        Ritual
    }

    public enum SkillCardRace
    {
        Andrew,
        Arkana,
        Bonz,
        Christine,
        David,
        Emma,
        [EnumMember(Value = "Espa Roba")]
        EspaRoba,
        Ishizu,
        [EnumMember(Value = "Ishizu Ishtar")]
        IshizuIshtar,
        Joey,
        [EnumMember(Value = "Joey Wheeler")]
        JoeyWheeler,
        Kaiba,
        Keith,
        [EnumMember(Value = "Lumis Umbra")]
        LumisUmbra,
        Mai,
        [EnumMember(Value = "Mai Valentine")]
        MaiValentine,
        Mako,
        Odion,
        Pegasus,
        Rex,
        [EnumMember(Value = "Seto Kaiba")]
        SetoKaiba,
        [EnumMember(Value = "Tea Gardner")]
        TeaGardner,
        Weevil,
        [EnumMember(Value = "Yami Bakura")]
        YamiBakura,
        [EnumMember(Value = "Yami Marik")]
        YamiMarik,
        [EnumMember(Value = "Yami Yugi")]
        YamiYugi,
        Yugi
    }
    
    public enum TrapCardRace
    {
        Normal,
        Continuous,
        Counter
    }
}