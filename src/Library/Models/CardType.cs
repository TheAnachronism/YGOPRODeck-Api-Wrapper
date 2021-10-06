using System.Text.Json.Serialization;

namespace YGOProDeckWrapper.Library.Models
{
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum CardType
    {
        [JsonPropertyName("Skill Card")]
        SkillCard,
        [JsonPropertyName("Spell Card")]
        SpellCard,
        [JsonPropertyName("Trap Card")]
        TrapCard,
        [JsonPropertyName("Normal Monster")]
        NormalMonster,
        [JsonPropertyName("Normal Tuner Monster")]
        NormalTunerMonster,
        [JsonPropertyName("Effect Monster")]
        EffectMonster,
        [JsonPropertyName("Tuner Monster")]
        TunerMonster,
        [JsonPropertyName("Flip Monster")]
        FlipMonster,
        [JsonPropertyName("Flip Effect Monster")]
        FlipEffectMonster,
        [JsonPropertyName("Flip Tuner Effect Monster")]
        FlipTunerEffectMonster,
        [JsonPropertyName("Spirit Monster")]
        SpiritMonster,
        [JsonPropertyName("Union Effect Monster")]
        UnionEffectMonster,
        [JsonPropertyName("Gemini Monster")]
        GeminiMonster,
        [JsonPropertyName("Pendulum Effect Monster")]
        PendulumEffectMonster,
        [JsonPropertyName("Pendulum Normal Monster")]
        PendulumNormalMonster,
        [JsonPropertyName("Pendulum Tuner Effect Monster")]
        PendulumTunerEffectMonster,
        [JsonPropertyName("Ritual Monster")]
        RitualMonster,
        [JsonPropertyName("Ritual Effect Monster")]
        RitualEffectMonster,
        [JsonPropertyName("Toon Monster")]
        ToonMonster,
        [JsonPropertyName("Fusion Monster")]
        FusionMonster,
        [JsonPropertyName("Synchro Monster")]
        SynchroMonster,
        [JsonPropertyName("Synchro Tuner Monster")]
        SynchroTunerMonster,
        [JsonPropertyName("Synchro Pendulum Effect Monster")]
        SynchroPendulumEffectMonster,
        [JsonPropertyName("XYZ Monster")]
        XYZMonster,
        [JsonPropertyName("XYZ Pendulum Effect Monster")]
        XYZPendulumEffectMonster,
        [JsonPropertyName("Link Monster")]
        LinkMonster,
        [JsonPropertyName("Pendulum Flip Effect Monster")]
        PendulumFlipEffectMonster,
        [JsonPropertyName("Pendulum Effect Fusion Monster")]
        PendulumEffectFusionMonster,
        Token
    }
}