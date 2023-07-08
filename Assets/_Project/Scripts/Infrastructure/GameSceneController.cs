using System;
using UnityEngine;
using Zenject;

namespace GMTK.Infrastructure
{
    public class GameSceneController : MonoBehaviour
    {
        [Inject] private IGameManager _gameManager;

        private void Awake()
        {
            _gameManager.Init();
        }

        private void Update()
        {
            _gameManager.Tick();
        }

        private void OnDisable()
        {
            _gameManager.Dispose();
        }
    }
}