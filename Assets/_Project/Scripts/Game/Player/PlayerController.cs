using GMTK.Game.Core;
using GMTK.Infrastructure;
using UnityEngine;
using Zenject;

namespace GMTK.Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerAI playerAI;
        [Inject] private IGameManager _gameManager;

        private void OnEnable()
        {
            if (_gameManager != null)
                _gameManager.Won += playerAI.MoveToFinish;
        }

        private void OnDisable()
        {
            if (_gameManager != null)
                _gameManager.Won -= playerAI.MoveToFinish;
        }
    }
}