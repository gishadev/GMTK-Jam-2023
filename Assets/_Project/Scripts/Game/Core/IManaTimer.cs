using System;

namespace GMTK.Game.Core
{
    public interface IManaTimer
    {
        float ManaPercentage { get; }
        event Action OutOfMana;
        void Init();
        void Tick();
        void Dispose();
    }
}