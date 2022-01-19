using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RiotGames.LeagueOfLegends.DataDragon
{
    public class ChampionImageCollection : IChampionCollection<Task<Stream>>, IDataDragonObject
    {
        private readonly string _directory;
        private readonly string _extension;
        private readonly DataDragonRequestHandler _requestHandler;

        internal ChampionImageCollection(string directory, string extension, DataDragonRequestHandler requestHandler)
        {
            _directory = directory;
            _extension = extension;
            _requestHandler = requestHandler;
        }

        public Task<Stream> this[string championName] => _requestHandler.GetStreamAsync(Path.Combine(_directory, championName, _extension));

        public Task<Stream> this[Champion champion] => this[champion.Name];

        public Task<Stream> this[IChampionId champion] => this[(Champion)champion];

        public Task<Stream> this[ushort championId] => this[(Champion)championId];
    }

    public class SkinImageCollection : IChampionCollection<Task<Stream>>, IDataDragonObject
    {
        private readonly string _directory;
        private readonly string _extension;
        private readonly DataDragonRequestHandler _requestHandler;

        internal SkinImageCollection(string directory, string extension, DataDragonRequestHandler requestHandler)
        {
            _directory = directory;
            _extension = extension;
            _requestHandler = requestHandler;
        }

        public Task<Stream> this[string championName] => _requestHandler.GetStreamAsync(Path.Combine(_directory, championName, _extension));

        public Task<Stream> this[Champion champion] => this[champion.Name];

        public Task<Stream> this[IChampionId champion] => this[(Champion)champion];

        public Task<Stream> this[ushort championId] => this[(Champion)championId];
    }

    public class ChampionSkinImageCollection : IChampionSkinCollection<Task<Stream>>, IDataDragonObject
    {
        private readonly string _directory;
        private readonly string _extension;
        private readonly DataDragonRequestHandler _requestHandler;

        internal ChampionSkinImageCollection(string directory, string extension, DataDragonRequestHandler requestHandler)
        {
            _directory = directory;
            _extension = extension;
            _requestHandler = requestHandler;
        }

        public Task<Stream> this[string championName, byte skinNumber] => _requestHandler.GetStreamAsync(Path.Combine(_directory, $"{championName}_{skinNumber}.{_extension}", _extension));

        public Task<Stream> this[string championName, ISkinNumber skin] => this[championName, skin.SkinNumber];

        public Task<Stream> this[Champion champion, byte skinNumber] => this[champion.Name, skinNumber];

        public Task<Stream> this[Champion champion, ISkinNumber skin] => this[champion.Name, skin.SkinNumber];

        public Task<Stream> this[IChampionId champion, byte skinNumber] => this[(Champion)champion, skinNumber];

        public Task<Stream> this[IChampionId champion, ISkinNumber skin] => this[(Champion)champion, skin.SkinNumber];

        public Task<Stream> this[ushort championId, byte skinNumber] => this[(Champion)championId, skinNumber];

        public Task<Stream> this[ushort championId, ISkinNumber skin] => this[(Champion)championId, skin.SkinNumber];


        public Task<Stream> this[Skin skin] => throw new NotImplementedException();

        /// <summary>
        /// Doesn't accept the skin name "default" for obvious reasons.
        /// </summary>
        public Task<Stream> this[string skinName] => throw new NotImplementedException();

        public Task<Stream> this[int skinId] => throw new NotImplementedException();

        public Task<Stream> this[ISkinId skin] => throw new NotImplementedException();
    }
}
