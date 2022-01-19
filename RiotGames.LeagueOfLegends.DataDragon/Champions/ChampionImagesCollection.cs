namespace RiotGames.LeagueOfLegends.DataDragon
{
    public partial class ChampionImagesCollection
    {
        public ChampionImageCollection Icons { get; set; }
        public ChampionSkinImageCollection Centered { get; set; }
        public ChampionSkinImageCollection Loading { get; set; }
        public ChampionSkinImageCollection Splash { get; set; }
        public ChampionSkinImageCollection Tiles { get; set; }

        public ChampionImages this[string championName] => new ChampionImages(championName, this);
        public ChampionImages this[Champion champion] => this[champion.Name];
        public ChampionImages this[IChampionId champion] => this[(Champion)champion];
        public ChampionImages this[ushort championId] => this[(Champion)championId];
    }
}