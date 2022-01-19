namespace RiotGames.LeagueOfLegends.DataDragon
{
    public interface IChampionCollection<T> : IDataDragonObject
    {
        public T this[string championId] { get; }

        public T this[IChampionId champion] => this[champion.Id];

        public T this[ushort championKey] => this[((Champion)championKey).Id];

        public T this[IChampionKey champion] => this[champion.Key];

        public T this[LeagueOfLegends.IChampionId champion] => this[champion.ChampionId];
    }

    public interface IChampionDictionary<T> : IChampionCollection<T>, IDataDragonObject
    {
        public T this[Champion champion] => this[champion.Id];
    }
}
