using GMTK.Game.Core;
using GMTK.Game.Location;
using Zenject;
using UnityEngine;

namespace GMTK.Infrastructure
{
    public class GameSceneController : MonoBehaviour
    {
        [Inject] private IGameManager _gameManager;
        [Inject] private IManaTimer _manaTimer;
        [Inject] private ISeizeAbilityHandler _seizeAbilityHandler;
        [Inject] private ILocationLoader _locationLoader;

        private void Awake()
        {
            _gameManager.Init();
            _manaTimer.Init();

            _locationLoader.Init();

            _seizeAbilityHandler.Init();
        }

        private void Update()
        {
            _manaTimer.Tick();
            _seizeAbilityHandler.Tick();
        }

        [ContextMenu("Force Win")]
        public void ForceWin()
        {
            var gameManager = (GameManager) _gameManager;
            gameManager.Win();
        }

        private void OnDisable()
        {
            _gameManager.Dispose();
            _manaTimer.Dispose();

            _locationLoader.Dispose();

            _seizeAbilityHandler.Dispose();
        }
    }
}