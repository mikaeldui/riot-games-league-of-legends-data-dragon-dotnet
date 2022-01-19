namespace RiotGames.LeagueOfLegends.DataDragon
{
    public interface ISkinCollection<T> : IChampionCollection<T>, IDataDragonObject
    {
        public T this[int skinId] { get; }

        public T this[ISkinId skin] => this[skin.SkinId];
    }

    public interface ISkinDictionary<T> : ISkinCollection<T>, IDataDragonObject
    {
        public T this[Skin skin] => this[skin.Number];
    }
}
