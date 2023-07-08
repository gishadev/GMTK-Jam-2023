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
            SeizeableObject.OnSeizeableObjectDeselected += OnSeizeableObjectDeselected;
        }

        private void OnDisable()
        {
            SeizeableObject.OnSeizeableObjectSelected -= OnSeizeableObjectSelected;
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
    }
}