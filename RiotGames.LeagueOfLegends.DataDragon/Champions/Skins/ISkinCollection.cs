namespace RiotGames.LeagueOfLegends.DataDragon
{
    public interface ISkinCollection<T> : IDataDragonObject
    {
        public T this[Skin skin] { get; }

        /// <summary>
        /// Doesn't accept the skin name "default" for obvious reasons.
        /// </summary>
        public T this[string skinName] { get; }

        public T this[int skinId] { get; }

        public T this[ISkinId skin] { get; }
    }
}
