namespace RiotGames.LeagueOfLegends.DataDragon
{
    public interface IChampionSkinCollection<T> : ISkinCollection<T>, IDataDragonObject
    {
        public T this[string championName, byte skinNumber] { get; }
        public T this[string championName, ISkinNumber skin] { get; }

        public T this[Champion champion, byte skinNumber] { get; }
        public T this[Champion champion, ISkinNumber skin] { get; }

        public T this[IChampionId champion, byte skinNumber] { get; }
        public T this[IChampionId champion, ISkinNumber skin] { get; }

        public T this[ushort championId, byte skinNumber] { get; }
        public T this[ushort championId, ISkinNumber skin] { get; }
    }
}
