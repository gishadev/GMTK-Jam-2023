using System;
using GMTK.Game.EnemyCore;
using GMTK.Infrastructure;
using Zenject;

namespace GMTK.Game.Core
{
    public class SeizeAbilityHandler : ISeizeAbilityHandler
    {
        public event Action<ISeizeable> SeizedIn;
        public event Action<ISeizeable> SeizedOut;
        public ISeizeable CurrentSeizeable { get; private set; }

        [Inject] private IGameManager _gameManager;

        public void Init()
        {
            SeizeableObjectSelector.SeizeableObjectSelected += OnSeizeableObjectSelected;
        }

        public void Dispose()
        {
            SeizeableObjectSelector.SeizeableObjectSelected -= OnSeizeableObjectSelected;
        }

        public void SeizeOut()
        {
            if (CurrentSeizeable != null)
            {
                SeizedOut?.Invoke(CurrentSeizeable);
                CurrentSeizeable = null;
            }
        }

        private void OnSeizeableObjectSelected(ISeizeable seizeable)
        {
            if (!_gameManager.IsPlaying)
                return;

            if (CurrentSeizeable == seizeable)
                return;

            if (CurrentSeizeable != null)
                SeizedOut?.Invoke(CurrentSeizeable);

            CurrentSeizeable = seizeable;
            SeizedIn?.Invoke(CurrentSeizeable);
        }
    }
}