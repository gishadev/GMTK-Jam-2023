using GMTK.Cameras;
using GMTK.Game.Core;
using GMTK.Game.EventsSO;
using GMTK.Infrastructure;
using UnityEngine;
using Zenject;

namespace GMTK.Game.EnemyCore
{
    [RequireComponent(typeof(SeizeableObjectSelector))]
    public class Enemy : MonoBehaviour, ISeizeable, IFollowable
    {
        [Inject] private ISeizeAbilityHandler _seizeAbilityHandler;
        [Inject] private IGameManager _gameManager;

        public bool IsSeized { get; private set; }

        private void OnEnable()
        {
            _seizeAbilityHandler.SeizedIn += OnSeizedIn;
            _seizeAbilityHandler.SeizedOut += OnSeizedOut;
            _gameManager.Lost += SeizeOut;
            _gameManager.Won += SeizeOut;
        }

        private void OnDisable()
        {
            _seizeAbilityHandler.SeizedIn -= OnSeizedIn;
            _seizeAbilityHandler.SeizedOut -= OnSeizedOut;
            _gameManager.Lost -= SeizeOut;
            _gameManager.Won -= SeizeOut;
        }

        private void OnSeizedIn(ISeizeable seizeable)
        {
            if ((Enemy) seizeable == this)
                SeizeIn();
        }

        private void OnSeizedOut()
        {
            SeizeOut();
        }

        public void SeizeIn()
        {
            IsSeized = true;
        }

        public void SeizeOut()
        {
            IsSeized = false;
        }
    }
}