using UnityEngine;

namespace GMTK.Game.EnemyCore
{
    [RequireComponent(typeof(SeizeableObject))]
    public class Enemy : MonoBehaviour, ISeizeable
    {
        [SerializeField] private SeizeableObject _seizeableObject;

        public bool IsSeized { get; private set; }

        private void Awake()
        {
            SeizeableObject.OnSeizeableObjectSelected += OnSeizeableObjectSelected;
        }

        private void OnDisable()
        {
            SeizeableObject.OnSeizeableObjectSelected -= OnSeizeableObjectSelected;
        }

        private void OnSeizeableObjectSelected(SeizeableObject trans)
        {
            if(trans == _seizeableObject)
                SeizeIn();
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
    }
}