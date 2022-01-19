namespace RiotGames.LeagueOfLegends.DataDragon
{
    public partial class DataDragonImages
    {
        private readonly DataDragon _dataDragon;

        internal DataDragonImages(DataDragon dataDragon) => _dataDragon = dataDragon;


        private ChampionImages? _champions;
        public ChampionImages Champions
        {
            get 
            {
                if (_champions == null)
                    _champions = new ChampionImages(_dataDragon);
                return _champions;
            } 
        }

        private DataDragonRuneImages? _runes;
        public DataDragonRuneImages Runes
        {
            get
            {
                if (_runes == null)
                    _runes = new DataDragonRuneImages(_dataDragon);
                return _runes;
            }
        }

        public partial class ChampionImages : IChampionDictionary<ChampionImages.Champion>
        {
            private readonly DataDragon _dataDragon;

            public ChampionImages(DataDragon dataDragon) => _dataDragon = dataDragon;

            public ChampionImageCollection Icons { get; set; }
            public ChampionSkinImageCollection Centered { get; set; }
            public ChampionSkinImageCollection Loading { get; set; }
            public ChampionSkinImageCollection Splash { get; set; }
            public ChampionSkinImageCollection Tiles { get; set; }

            public Champion this[string championId] => new(championId, this);

            public partial class Champion
            {
                private readonly string _championName;
                private readonly DataDragonImages.ChampionImages _championImagesCollection;
                internal Champion(string championName, DataDragonImages.ChampionImages championImagesCollection)
                {
                    _championName = championName;
                    _championImagesCollection = championImagesCollection;
                }

                public async Task<Stream> GetIconAsync() => await _championImagesCollection.Icons[_championName];

            }
        }

        public partial class DataDragonRuneImages
        {
            private readonly DataDragon _dataDragon;

            public DataDragonRuneImages(DataDragon dataDragon)
            {
                this._dataDragon = dataDragon;
            }
        }
    }
}