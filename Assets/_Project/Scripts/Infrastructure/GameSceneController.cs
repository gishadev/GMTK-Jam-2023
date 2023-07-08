using GMTK.Game.Core;
using Zenject;
using UnityEngine;

namespace GMTK.Infrastructure
{
    public class GameSceneController : MonoBehaviour
    {
        [Inject] private IGameManager _gameManager;
        [Inject] private IManaTimer _manaTimer;
        [Inject] private ISeizeAbilityHandler _seizeAbilityHandler;

        private void Awake()
        {
            _gameManager.Init();
            _manaTimer.Init();
            _seizeAbilityHandler.Init();
        }

        private void Update()
        {
            _manaTimer.Tick();
        }

        private void OnDisable()
        {
            _seizeAbilityHandler.Dispose();
            _gameManager.Dispose();
            _manaTimer.Dispose();
        }
    }
}