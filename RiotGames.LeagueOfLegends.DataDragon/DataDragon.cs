namespace RiotGames.LeagueOfLegends.DataDragon
{
    public partial class DataDragon
    {
        internal readonly DataDragonRequestHandler RequestHandler;

        /// <summary>
        /// Constructs the <see cref="DataDragon"/> with a <see cref="DataDragonFileRequestHandler"/> for accessing a local <see cref="DataDragon"/>.
        /// </summary>
        /// <param name="directory">The <see cref="DataDragon"/> directory.</param>
        public DataDragon(string directory) : this(new DataDragonFileRequestHandler(directory))
        {
        }

        public DataDragon(DataDragonRequestHandler requestHandler)
        {
            RequestHandler = requestHandler ?? throw new ArgumentNullException(nameof(requestHandler));
        }

        public static DataDragon OpenDirectory(string path) => new DataDragon(path);

        private DataDragonImages? _images;

        public DataDragonImages Images
        {
            get
            {
                if (_images == null)
                    _images = new DataDragonImages(this);

                return _images;
            }
        }
    }

    public partial class DataDragonImages
    {
        public ChampionImagesCollection Champions
        {
            get; set;
        }

        public DataDragonRuneImages Runes
        {
            get;set;
        }
    }

    public partial class ChampionImages
    {
        private string _championName;
        private ChampionImagesCollection _championImagesCollection;
        internal ChampionImages(string championName, ChampionImagesCollection championImagesCollection)
        {
            _championName = championName;
            _championImagesCollection = championImagesCollection;
        }

        public async Task<Stream> GetIconAsync() => await _championImagesCollection.Icons[_championName];
        public async ISkinCollection<Task<Stream>>
    }

    public partial class DataDragonRuneImages
    {

    }
}