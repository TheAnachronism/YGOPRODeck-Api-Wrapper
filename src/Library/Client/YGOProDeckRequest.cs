using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace YGOProDeckWrapper.Library.Client
{
    public class YGOProDeckRequest
    {
        private const string CardInformationEndpoint = "https://db.ygoprodeck.com/api/v7/cardinfo.php";
        private List<string> Names { get; set; } = new();
        private List<string> SearchValues { get; set; } = new();
        private List<int> Ids { get; set; } = new();
        private List<string> Types { get; set; } = new();
        private int? Atk { get; set; }
        private int? Def { get; set; }
        private int? Level { get; set; }
        private List<string> Races { get; set; } = new();
        private List<string> Attributes { get; set; } = new();
        private int? LinkValue { get; set; }
        private List<LinkMarkerValues> LinkMarkers { get; set; } = new();
        private int? PendulumScale { get; set; }
        private List<string> CardSets { get; set; } = new();
        private List<string> Archetypes { get; set; } = new();
        private string BanList { get; set; }
        private SortTypes? SortType { get; set; }
        private Formats? Format { get; set; }
        
        private YGOProDeckRequest()
        {
        }

        public static YGOProDeckRequest CreateRequest()
        {
            return new YGOProDeckRequest();
        }

        public YGOProDeckRequest WithName(string cardName)
        {
            Names.Add(cardName);
            return this;
        }

        public YGOProDeckRequest WithSearch(string name)
        {
            SearchValues.Add(name);
            return this;
        }

        public YGOProDeckRequest WithId(int id)
        {
            Ids.Add(id);
            return this;
        }

        public YGOProDeckRequest WithType(string type)
        {
            Types.Add(type);
            return this;
        }

        public YGOProDeckRequest WithAtk(int atk)
        {
            Atk = atk;
            return this;
        }

        public YGOProDeckRequest WithDef(int def)
        {
            Def = def;
            return this;
        }

        public YGOProDeckRequest WithLevelOrRank(int levelOrRank)
        {
            Level = levelOrRank;
            return this;
        }

        public YGOProDeckRequest WithRace(string race)
        {
            Races.Add(race);
            return this;
        }

        public YGOProDeckRequest WithAttribute(string attribute)
        {
            Attributes.Add(attribute);
            return this;
        }

        public YGOProDeckRequest WithLinkValue(int linkValue)
        {
            LinkValue = linkValue;
            return this;
        }

        public YGOProDeckRequest WithLinkMarkers(params LinkMarkerValues[] linkMarkers)
        {
            LinkMarkers = linkMarkers.ToList();
            return this;
        }

        public YGOProDeckRequest WithPendulumScale(int scale)
        {
            PendulumScale = scale;
            return this;
        }

        public YGOProDeckRequest WithCardSet(string setName)
        {
            CardSets.Add(setName);
            return this;
        }

        public YGOProDeckRequest WithArchetype(string archetype)
        {
            Archetypes.Add(archetype);
            return this;
        }

        public YGOProDeckRequest WithBanList(string banList)
        {
            BanList = banList;
            return this;
        }

        public YGOProDeckRequest SortBy(SortTypes sortType)
        {
            SortType = sortType;
            return this;
        }

        public YGOProDeckRequest FromFormat(Formats format)
        {
            Format = format;
            return this;
        }

        internal NameValueCollection BuildRequest()
        {
            var query = new NameValueCollection();
            if(Names.Any())
                query.Add("name", string.Join("|", Names));
            if(SearchValues.Any())
                SearchValues.ForEach(x => query.Add("fname", x));
            if(Ids.Any())
                query.Add("id", string.Join(",", Ids));
            if(Types.Any())
                query.Add("type", string.Join(",", Types));
            if(Atk.HasValue)
                query.Add("atk", Atk.ToString());
            if(Def.HasValue)
                query.Add("def", Def.ToString());
            if(Level.HasValue)
                query.Add("level", Level.ToString());
            if (Races.Any())
                query.Add("race", string.Join(",", Races));
            if(Attributes.Any())
                query.Add("attribute", string.Join(",", Attributes));
            if(LinkValue.HasValue)
                query.Add("link", LinkValue.ToString());
            if(LinkMarkers.Any())
                query.Add("linkmarker", string.Join(",", LinkMarkers));
            if(PendulumScale.HasValue)
                query.Add("scale", PendulumScale.ToString());
            if(CardSets.Any())
                CardSets.ForEach(x => query.Add("cardset", x));
            if (Archetypes.Any())
                Archetypes.ForEach(x => query.Add("archetype", x));
            if(!string.IsNullOrEmpty(BanList))
                query.Add("banlist", BanList);
            if(SortType.HasValue)
                query.Add("sort", SortType.ToString());
            if(Format.HasValue)
                query.Add("format", Format.ToString());

            return query;
        }
    }

    public enum Formats
    {
        TCG,
        Goat,
        OCG,
        OCGGoat,
        Speed,
        Rush,
        DuelLinks
    }

    public enum SortTypes
    {
        Atk,
        Def,
        Name,
        Type,
        Level,
        Id,
        New
    }

    public enum LinkMarkerValues
    {
        Top,
        Bottom,
        Left,
        Right,
        BottomLeft,
        BottomRight,
        TopLeft,
        TopRight
    }
}