using GMTK.Infrastructure;
using UnityEngine;

namespace GMTK.Game.Core
{
    public class GameManager : IGameManager
    {
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
            Debug.Log("Win!");
        }
    }
}