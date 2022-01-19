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

        private DataDragonChampions? _champions;
        public DataDragonChampions Champions
        {
            get
            {
                if (_champions == null)
                    _champions = new DataDragonChampions(this);

                return _champions;
            }
        }

        public static DataDragon OpenDirectory(string path) => new DataDragon(path);
    }

    public class DataDragonChampions
    {
        private readonly DataDragon _dataDragon;

        public DataDragonChampions(DataDragon dataDragon)
        {
            this._dataDragon = dataDragon;
        }
    }
}