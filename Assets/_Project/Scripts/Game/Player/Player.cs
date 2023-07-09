using System;
using UnityEngine;

namespace GMTK.Game.Player
{
    [RequireComponent(typeof(PlayerAI))]
    public class Player : MonoBehaviour
    {
        private PlayerAI _playerAI;

        public PlayerAI AI => _playerAI;

        private void Awake()
        {
            _playerAI = GetComponent<PlayerAI>();
        }
    }
}