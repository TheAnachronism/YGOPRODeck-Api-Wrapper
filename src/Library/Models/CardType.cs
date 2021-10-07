using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace YGOProDeckWrapper.Library.Models
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum CardType
    {
        [EnumMember(Value = "Skill Card")]
        SkillCard,
        [EnumMember(Value = "Spell Card")]
        SpellCard,
        [EnumMember(Value = "Trap Card")]
        TrapCard,
        [EnumMember(Value = "Normal Monster")]
        NormalMonster,
        [EnumMember(Value = "Normal Tuner Monster")]
        NormalTunerMonster,
        [EnumMember(Value = "Effect Monster")]
        EffectMonster,
        [EnumMember(Value = "Tuner Monster")]
        TunerMonster,
        [EnumMember(Value = "Flip Monster")]
        FlipMonster,
        [EnumMember(Value = "Flip Effect Monster")]
        FlipEffectMonster,
        [EnumMember(Value = "Flip Tuner Effect Monster")]
        FlipTunerEffectMonster,
        [EnumMember(Value = "Spirit Monster")]
        SpiritMonster,
        [EnumMember(Value = "Union Effect Monster")]
        UnionEffectMonster,
        [EnumMember(Value = "Gemini Monster")]
        GeminiMonster,
        [EnumMember(Value = "Pendulum Effect Monster")]
        PendulumEffectMonster,
        [EnumMember(Value = "Pendulum Normal Monster")]
        PendulumNormalMonster,
        [EnumMember(Value = "Pendulum Tuner Effect Monster")]
        PendulumTunerEffectMonster,
        [EnumMember(Value = "Ritual Monster")]
        RitualMonster,
        [EnumMember(Value = "Ritual Effect Monster")]
        RitualEffectMonster,
        [EnumMember(Value = "Toon Monster")]
        ToonMonster,
        [EnumMember(Value = "Fusion Monster")]
        FusionMonster,
        [EnumMember(Value = "Synchro Monster")]
        SynchroMonster,
        [EnumMember(Value = "Synchro Tuner Monster")]
        SynchroTunerMonster,
        [EnumMember(Value = "Synchro Pendulum Effect Monster")]
        SynchroPendulumEffectMonster,
        [EnumMember(Value = "XYZ Monster")]
        XYZMonster,
        [EnumMember(Value = "XYZ Pendulum Effect Monster")]
        XYZPendulumEffectMonster,
        [EnumMember(Value = "Link Monster")]
        LinkMonster,
        [EnumMember(Value = "Pendulum Flip Effect Monster")]
        PendulumFlipEffectMonster,
        [EnumMember(Value = "Pendulum Effect Fusion Monster")]
        PendulumEffectFusionMonster,
        Token
    }
}