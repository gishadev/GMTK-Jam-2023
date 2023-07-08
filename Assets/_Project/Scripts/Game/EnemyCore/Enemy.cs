using GMTK.Game.EventsSO;
using UnityEngine;

namespace GMTK.Game.EnemyCore
{
    [RequireComponent(typeof(SeizeableObject))]
    public class Enemy : MonoBehaviour, ISeizeable
    {
        [SerializeField] private EventSO onEnemyDeactivated;
        [SerializeField] private SeizeableObject _seizeableObject;
        
        public bool IsSeized { get; private set; }

        private void OnEnable()
        {
            SeizeableObject.OnSeizeableObjectSelected += OnSeizeableObjectSelected;
            SeizeableObject.OnSeizeableObjectDeselected += OnSeizeableObjectDeselected;

            onEnemyDeactivated.OnInvoked += SeizeOut;
        }
        
        private void OnDisable()
        {
            SeizeableObject.OnSeizeableObjectSelected -= OnSeizeableObjectSelected;
            SeizeableObject.OnSeizeableObjectDeselected -= OnSeizeableObjectDeselected;
            
            onEnemyDeactivated.OnInvoked -= SeizeOut;
        }

        private void OnSeizeableObjectSelected(SeizeableObject seizeableObject)
        {
            if(seizeableObject == _seizeableObject)
                SeizeIn();
        }

        private void OnSeizeableObjectDeselected(SeizeableObject seizeableObject)
        {
            if (seizeableObject == _seizeableObject)
            {
                SeizeOut();
            }
        }

        [ContextMenu("Seize In")]
        public void SeizeIn()
        {
            IsSeized = true;
        }

        [ContextMenu("Seize Out")]
        public void SeizeOut()
        {
            IsSeized = false;
        }
        
        public void DeactivateEnemy()
        {
            onEnemyDeactivated.Invoke();
        }
    }
}