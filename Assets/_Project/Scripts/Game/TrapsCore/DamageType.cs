using System;

namespace GMTK.Game.TrapsCore
{
    [Flags]
    public enum DamageType
    {
        Acid = 1,
        Pit = 2,
        Spike = 4,
        ManTrap = 8,
        ChestTrap = 16,
        Arrow = 32,
        SmashWall = 64
    }
}