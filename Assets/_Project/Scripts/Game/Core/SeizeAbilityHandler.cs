using System;
using GMTK.Game.EnemyCore;
using GMTK.Infrastructure;
using UnityEngine;
using Zenject;

namespace GMTK.Game.Core
{
    public class SeizeAbilityHandler : ISeizeAbilityHandler
    {
        [Inject] private IGameManager _gameManager;
        public event Action<ISeizeable> SeizedIn;
        public event Action SeizedOut;
        public ISeizeable CurrentSeizeable { get; private set; }


        public void Init()
        {
            SeizeableObjectSelector.SeizeableObjectSelected += OnSeizeableObjectSelected;
            EnemyHealth.OnDie += OnDie;
        }

        private void OnDie(IDamageable obj)
        {
            SeizeOut();
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                SeizeOut();
        }

        public void Dispose()
        {
            SeizeableObjectSelector.SeizeableObjectSelected -= OnSeizeableObjectSelected;
            EnemyHealth.OnDie -= OnDie;
        }

        public void SeizeOut()
        {
            if (CurrentSeizeable != null)
            {
                CurrentSeizeable = null;
                SeizedOut?.Invoke();
            }
        }

        private void OnSeizeableObjectSelected(ISeizeable seizeable)
        {
            if (!_gameManager.IsPlaying)
                return;

            if (CurrentSeizeable == seizeable)
                return;

            SeizeOut();

            CurrentSeizeable = seizeable;
            SeizedIn?.Invoke(CurrentSeizeable);
        }
    }
}