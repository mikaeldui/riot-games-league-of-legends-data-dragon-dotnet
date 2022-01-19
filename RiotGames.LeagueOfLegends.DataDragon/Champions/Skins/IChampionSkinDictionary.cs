namespace RiotGames.LeagueOfLegends.DataDragon
{
    public interface IChampionSkinCollection<T> : IDataDragonObject
    {
        public T this[byte skinNumber] { get; }

        public T this[string skinName] => this[((Skin)skinName).Number];
    }

    public interface IChampionSkinDictionary<T> : IChampionDictionary<IChampionSkinCollection<Task<Stream>>>, IDataDragonObject
    {
        public T this[string championId, byte skinNumber] { get; }

        public T this[string championId, ISkinNumber skin] => this[championId, skin.SkinNumber];

        public T this[Champion champion, byte skinNumber] => this[champion.Name, skinNumber];

        public T this[Champion champion, ISkinNumber skin] => this[champion.Name, skin.SkinNumber];

        public T this[IChampionId champion, byte skinNumber] => this[champion.Id, skinNumber];

        public T this[IChampionId champion, ISkinNumber skin] => this[champion.Id, skin.SkinNumber];

        public T this[IChampionKey champion, byte skinNumber] => this[champion.Key, skinNumber];

        public T this[IChampionKey champion, ISkinNumber skin] => this[champion.Key, skin.SkinNumber];

        public T this[LeagueOfLegends.IChampionId champion, byte skinNumber] => this[champion.ChampionId, skinNumber];

        public T this[LeagueOfLegends.IChampionId champion, ISkinNumber skin] => this[champion.ChampionId, skin.SkinNumber];

        public T this[ushort championKey, byte skinNumber] => this[(Champion)championKey, skinNumber];

        public T this[ushort championKey, ISkinNumber skin] => this[(Champion)championKey, skin.SkinNumber];
    }
}
