using System;
using GMTK.Infrastructure;
using UnityEngine;

namespace GMTK.Game.Core
{
    public class GameManager : IGameManager
    {
        public event Action OnWin; 

        public void Init()
        {
            Debug.Log("game manager inited");
        }

        public void Tick()
        {
        }

        public void Dispose()
        {
        }

        private void Lose()
        {
            Debug.Log("Lose!");
        }

        private void Win()
        {
            OnWin?.Invoke();
            Debug.Log("Win!");
        }
    }
}