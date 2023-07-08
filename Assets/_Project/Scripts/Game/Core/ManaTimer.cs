using System;
using GMTK.Infrastructure;
using Zenject;

namespace GMTK.Game.Core
{
    public class ManaTimer : IManaTimer
    {
        [Inject] private GameDataSO _gameDataSO;
        [Inject] private IGameManager _gameManager;

        public float ManaPercentage { get; private set; }
        public event Action OutOfMana;

        public void Init()
        {
            ManaPercentage = 1f;
            SeizeableObject.OnSeizeableObjectSelected += OnSeizeIn;
        }

        private void OnSeizeIn(SeizeableObject seizeableObj)
        {
            ManaPercentage -= _gameDataSO.ManaTimePenaltyPerSeizeInSeconds / _gameDataSO.FullManaTimeInSeconds;
        }

        public void Tick()
        {
            if (!_gameManager.IsPlaying || ManaPercentage <= 0f)
                return;

            ManaPercentage -= _gameDataSO.ManaDecreasePerSecond;
            if (ManaPercentage <= 0f)
            {
                OutOfMana?.Invoke();
                ManaPercentage = 0f;
            }
        }

        public void Dispose()
        {
            SeizeableObject.OnSeizeableObjectSelected -= OnSeizeIn;
        }
    }
}