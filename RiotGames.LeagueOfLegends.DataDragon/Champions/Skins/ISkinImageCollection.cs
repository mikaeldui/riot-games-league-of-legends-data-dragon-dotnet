namespace RiotGames.LeagueOfLegends.DataDragon
{
    public interface ISkinImageCollection : IDataDragonObject
    {
        public Task<Stream> this[byte skinNumber] { get; }
        public Task<Stream> this[ISkinNumber skin] { get; }
    }
}
