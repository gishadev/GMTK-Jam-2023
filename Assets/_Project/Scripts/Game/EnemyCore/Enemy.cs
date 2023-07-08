using UnityEngine;

namespace GMTK.Game.EnemyCore
{
    [RequireComponent(typeof(SeizeableObject))]
    public class Enemy : MonoBehaviour, ISeizeable
    {
        public bool IsSeized { get; private set; }

        private SeizeableObject _seizeableObject;

        private void Awake()
        {
            _seizeableObject = GetComponent<SeizeableObject>();

            _seizeableObject.OnSeizeableObjectSelected += OnSeizeableObjectSelected;
        }

        private void OnDisable()
        {
            _seizeableObject.OnSeizeableObjectSelected -= OnSeizeableObjectSelected;
        }

        private void OnSeizeableObjectSelected(Transform trans)
        {
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