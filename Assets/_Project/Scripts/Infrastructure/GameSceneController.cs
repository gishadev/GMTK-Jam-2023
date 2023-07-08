using GMTK.Game.Core;
using Zenject;
using UnityEngine;

namespace GMTK.Infrastructure
{
    public class GameSceneController : MonoBehaviour
    {
        [Inject] private IGameManager _gameManager;
        [Inject] private IManaTimer _manaTimer;

        private void Awake()
        {
            _gameManager.Init();
            _manaTimer.Init();
        }

        private void Update()
        {
            _gameManager.Tick();
            _manaTimer.Tick();
        }

        private void OnDisable()
        {
            _gameManager.Dispose();
            _manaTimer.Dispose();
        }
    }
}