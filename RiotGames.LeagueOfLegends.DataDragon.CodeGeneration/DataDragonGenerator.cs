using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotGames.LeagueOfLegends.DataDragon.CodeGeneration
{
    internal class DataDragonGenerator
    {
        public async Task GenerateCodeAsync()
        {
            var ddPath = Environment.GetEnvironmentVariable("LOL_DATADRAGON");
            if (ddPath == null)
                throw new Exception("LOL_DATADRAGON not set.");

            var ddClass = new DataDragonClass();
            ddClass.AddMethodsForFiles(Directory.GetFiles(ddPath));
        }
    }
}
