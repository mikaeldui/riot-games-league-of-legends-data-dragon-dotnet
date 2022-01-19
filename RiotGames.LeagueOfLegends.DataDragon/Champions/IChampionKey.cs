namespace RiotGames.LeagueOfLegends.DataDragon
{
    public interface IChampionKey : LeagueOfLegends.IChampionId, IDataDragonObject
    {
        public ushort Key { get; set; }
        ushort LeagueOfLegends.IChampionId.ChampionId { get => Key; set => Key = value; }
    }
}
