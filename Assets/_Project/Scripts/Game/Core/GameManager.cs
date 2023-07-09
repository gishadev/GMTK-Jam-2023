using System;
using System.Linq;
using GMTK.Game.EnemyCore;
using GMTK.Infrastructure;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace GMTK.Game.Core
{
    public class GameManager : IGameManager
    {
        [Inject] private IManaTimer _manaTimer;
        [Inject] private ISeizeAbilityHandler _seizeAbilityHandler;

        public bool IsPlaying { get; private set; }

        public event Action Won, Lost;

        public void Init()
        {
            Debug.Log("game manager inited");
            IsPlaying = true;

            _manaTimer.OutOfMana += Lose;
            EnemyHealth.OnDie += OnDie;
        }

        private void OnDie(IDamageable obj)
        {
            var damageables = Object.FindObjectsOfType<MonoBehaviour>().OfType<IDamageable>().ToArray();

            if (damageables.Length == 1 || damageables.Length == 0)
                Win();
        }

        public void Dispose()
        {
            _manaTimer.OutOfMana -= Lose;
            EnemyHealth.OnDie -= OnDie;
        }

        private void Lose()
        {
            _seizeAbilityHandler.SeizeOut();
            IsPlaying = false;
            Debug.Log("Lose!");

            Lost?.Invoke();
        }

        public void Win()
        {
            IsPlaying = false;
            Debug.Log("Win!");

            Won?.Invoke();
        }
    }
}