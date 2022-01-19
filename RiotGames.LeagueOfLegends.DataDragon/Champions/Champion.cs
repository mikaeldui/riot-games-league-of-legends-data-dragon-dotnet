using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGames.LeagueOfLegends.DataDragon
{
    public partial struct Champion : IChampionId, IDataDragonObject
    {
        public ushort Id { get; set; }

        public string Name { get; set; }

        ushort IChampionId.ChampionId { get => Id; set => Id = value; }

        public static explicit operator Champion(ushort championId)
        {
            return FromId(championId);
        }

        public static explicit operator Champion(string championName)
        {
            return FromName(championName);
        }

        public static partial Champion FromId(ushort championId);
        public static partial Champion FromName(string championName);

        //public static readonly Champion Sona;
    }
}
