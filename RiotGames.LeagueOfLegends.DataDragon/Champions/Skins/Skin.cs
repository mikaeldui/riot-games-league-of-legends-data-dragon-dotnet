namespace RiotGames.LeagueOfLegends.DataDragon
{
    public struct Skin : IDataDragonObject, ISkinId, ISkinNumber
    {
        public int Id { get; set; }

        public byte Number { get; set; }

        public string Name { get; set; }

        public bool Chromas { get; set; }

        int ISkinId.SkinId => Id;

        byte ISkinNumber.SkinNumber => Number;
    }
}
