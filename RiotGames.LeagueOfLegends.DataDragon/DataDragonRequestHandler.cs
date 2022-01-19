using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGames.LeagueOfLegends.DataDragon
{
    public abstract class DataDragonRequestHandler
    {
        public abstract Task<string> GetStringAsync(string location, CancellationToken cancellationToken = default);

        public abstract Task<Stream> GetStreamAsync(string location, CancellationToken cancellationToken = default);
        
        public abstract Task<T> GetFromJsonAsync<T>(string location, CancellationToken cancellationToken = default);
    }
}
