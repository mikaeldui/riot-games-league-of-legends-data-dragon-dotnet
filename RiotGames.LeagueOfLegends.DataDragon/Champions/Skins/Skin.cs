namespace RiotGames.LeagueOfLegends.DataDragon
{
    public partial struct Skin : IDataDragonObject, ISkinId, ISkinNumber
    {
        public int Id { get; set; }

        public byte Number { get; set; }

        public string Name { get; set; }

        public bool Chromas { get; set; }

        int ISkinId.SkinId => Id;

        byte ISkinNumber.SkinNumber => Number;


        public static explicit operator Skin(int skinId) => FromId(skinId);


        public static explicit operator Skin(string skinName) => FromName(skinName);

        public static partial Skin FromId(int skinId);

        public static partial Skin FromName(string skinName);
    }
}
