namespace RiotGames.LeagueOfLegends.DataDragon
{
    public class ChampionSkinImageCollection : IChampionDictionary<SkinImageCollection>, IChampionSkinDictionary<Task<Stream>>, IDataDragonObject
    {
        private readonly string _directory;
        private readonly string _extension;
        private readonly DataDragonRequestHandler _requestHandler;

        IChampionSkinCollection<Task<Stream>> IChampionCollection<IChampionSkinCollection<Task<Stream>>>.this[string championId] => throw new NotImplementedException();

        internal ChampionSkinImageCollection(string directory, string extension, DataDragonRequestHandler requestHandler)
        {
            _directory = directory;
            _extension = extension;
            _requestHandler = requestHandler;
        }

        public Task<Stream> this[string championId, byte skinNumber] => _requestHandler.GetStreamAsync(Path.Combine(_directory, $"{championId}_{skinNumber}.{_extension}"));

        public Task<Stream> this[int skinId] => throw new NotImplementedException();
        public SkinImageCollection this[string championId] => new(championId, this);

    }

    public class SkinImageCollection : IChampionSkinCollection<Task<Stream>>
    {
        private readonly string _championId;
        private readonly ChampionSkinImageCollection _championSkins;

        internal SkinImageCollection(string championId, ChampionSkinImageCollection championSkins)
        {
            _championId = championId;
            _championSkins = championSkins;
        }

        public Task<Stream> this[byte skinNumber] => _championSkins[_championId, skinNumber];
    }
}
