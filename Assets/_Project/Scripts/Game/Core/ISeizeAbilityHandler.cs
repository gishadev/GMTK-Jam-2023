using System;
using GMTK.Game.EnemyCore;

namespace GMTK.Game.Core
{
    public interface ISeizeAbilityHandler
    {
        event Action<ISeizeable> SeizedIn, SeizedOut;
        ISeizeable CurrentSeizeable { get; }
        void Init();
        void Dispose();
        void SeizeOut();
    }
}