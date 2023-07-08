using GMTK.Game.Core;
using GMTK.Game.EventsSO;
using UnityEngine;
using Zenject;

namespace GMTK.Game.EnemyCore
{
    [RequireComponent(typeof(SeizeableObjectSelector))]
    public class Enemy : MonoBehaviour, ISeizeable
    {
        [SerializeField] private EventSO onEnemyDeactivated;

        [Inject] private ISeizeAbilityHandler _seizeAbilityHandler;

        public bool IsSeized { get; private set; }

        private void OnEnable()
        {
            _seizeAbilityHandler.SeizedIn += OnSeizedIn;
            _seizeAbilityHandler.SeizedOut += OnSeizedOut;
            onEnemyDeactivated.OnInvoked += OnSeizeOut;
        }

        private void OnDisable()
        {
            _seizeAbilityHandler.SeizedIn -= OnSeizedIn;
            _seizeAbilityHandler.SeizedOut -= OnSeizedOut;
            onEnemyDeactivated.OnInvoked -= OnSeizeOut;
        }

        private void OnSeizedIn(ISeizeable seizeable)
        {
            if ((Enemy) seizeable == this)
                OnSeizeIn();
        }

        private void OnSeizedOut(ISeizeable seizeable)
        {
            if ((Enemy) seizeable == this)
                OnSeizeOut();
        }

        public void OnSeizeIn()
        {
            IsSeized = true;
        }

        public void OnSeizeOut()
        {
            IsSeized = false;
        }

        public void DeactivateEnemy()
        {
            onEnemyDeactivated.Invoke();
        }
    }
}