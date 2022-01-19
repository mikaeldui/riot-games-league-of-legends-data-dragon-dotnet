using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGames.LeagueOfLegends.DataDragon
{
    public partial struct Champion : IChampionId, IChampionKey, IDataDragonObject
    {
        public string Id { get; set; }

        public ushort Key { get; set; }

        public string Name { get; set; }


        public static explicit operator Champion(ushort championKey) => FromKey(championKey);

        public static explicit operator Champion(string championName) => FromName(championName);

        public static partial Champion FromKey(ushort championKey);

        public static partial Champion FromName(string championName);

        //public static readonly Champion Sona;
    }
}
