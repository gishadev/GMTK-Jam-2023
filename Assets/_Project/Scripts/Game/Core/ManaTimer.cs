using System;
using GMTK.Game.EnemyCore;
using GMTK.Infrastructure;
using UnityEngine;
using Zenject;

namespace GMTK.Game.Core
{
    public class ManaTimer : IManaTimer
    {
        [Inject] private GameDataSO _gameDataSO;
        [Inject] private IGameManager _gameManager;
        [Inject] private ISeizeAbilityHandler _seizeAbilityHandler;

        public event Action OutOfMana;

        public float ManaPercentage
        {
            get => _manaPercentage;
            private set => _manaPercentage = Mathf.Clamp01(value);
        }

        private float _manaPercentage;

        public void Init()
        {
            ManaPercentage = 1f;
            _seizeAbilityHandler.SeizedIn += OnSeizedIn;
        }

        private void OnSeizedIn(ISeizeable seizeable)
        {
            ManaPercentage -= _gameDataSO.ManaTimePenaltyPerSeizeInSeconds / _gameDataSO.FullManaTimeInSeconds;
        }

        public void Tick()
        {
            if (!_gameManager.IsPlaying)
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
            _seizeAbilityHandler.SeizedIn -= OnSeizedIn;
        }
    }
}