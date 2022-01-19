using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RiotGames.LeagueOfLegends.DataDragon
{
    public class ChampionImageCollection : IChampionDictionary<Task<Stream>>, IDataDragonObject
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

        public Task<Stream> this[string championId] => _requestHandler.GetStreamAsync(Path.Combine(_directory, $"{championId}.{_extension}"));
    }
}
