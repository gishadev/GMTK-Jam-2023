using System;
using GMTK.Game.EnemyCore;

namespace GMTK.Game.Core
{
    public interface ISeizeAbilityHandler
    {
        event Action<ISeizeable> SeizedIn;
        event Action SeizedOut;
        ISeizeable CurrentSeizeable { get; }
        void Init();
        void Tick();
        void Dispose();
        void SeizeOut();
    }
}