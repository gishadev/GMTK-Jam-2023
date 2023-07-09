using System;
using GMTK.Infrastructure;
using UnityEngine;
using Zenject;

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
        }
        
        public void Dispose()
        {
            _manaTimer.OutOfMana -= Lose;
        }

        private void Lose()
        {
            _seizeAbilityHandler.SeizeOut();
            IsPlaying = false;
            Debug.Log("Lose!");

            Lost?.Invoke();
        }

        private void Win()
        {
            IsPlaying = false;
            Debug.Log("Win!");

            Won?.Invoke();
        }
    }
}