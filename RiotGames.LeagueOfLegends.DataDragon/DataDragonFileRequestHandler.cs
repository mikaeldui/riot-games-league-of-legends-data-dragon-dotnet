using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace RiotGames.LeagueOfLegends.DataDragon
{
    public class DataDragonFileRequestHandler : DataDragonRequestHandler
    {
        private static readonly JsonSerializerOptions _serializerOptions = new()
        {
            PropertyNameCaseInsensitive = true,
        };

        private readonly string _directory;

        public DataDragonFileRequestHandler(string directory)
        {
            _directory = directory;
        }

        public override async Task<T> GetFromJsonAsync<T>(string location, CancellationToken cancellationToken = default)
        {
            var stream = await GetStreamAsync(location, cancellationToken);
            var result = await JsonSerializer.DeserializeAsync<T>(stream, _serializerOptions, cancellationToken);
            return result ?? throw new Exception($"Error deserializing {location}.");
        }

        public override async Task<Stream> GetStreamAsync(string location, CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => File.OpenRead(Path.Combine(_directory, location)), cancellationToken);
        }

        public override async Task<string> GetStringAsync(string location, CancellationToken cancellationToken = default)
        {
#if !NETSTANDARD2_0
            return await File.ReadAllTextAsync(Path.Combine(_directory, location), cancellationToken);
#else
            return await Task.Run(() => File.ReadAllText(location), cancellationToken);
#endif
        }
    }
}
