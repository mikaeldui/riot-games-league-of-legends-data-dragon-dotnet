namespace RiotGames.LeagueOfLegends.DataDragon
{
    public interface IChampionCollection<T> : IDataDragonObject
    {
        public T this[string championName] { get; }

        public T this[Champion champion] { get; }

        public T this[IChampionId champion] { get; }

        public T this[ushort championId] { get; }
    }
}
