using WCSharp.Api;

namespace Source.Data.Dungeons
{
    public struct DungeonGuardData
    {
        public int IDGuard { get; set; }
        public float Face {  get; set; }
        public float X {  get; set; }
        public float Y { get; set; }

        public DungeonGuardData (unit unit)
        {
            X = unit.X;
            Y = unit.Y;
            Face = unit.Facing;
            IDGuard = unit.UnitType;
        }
    }
}
