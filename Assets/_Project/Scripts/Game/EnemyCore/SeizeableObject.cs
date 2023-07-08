using System;
using UnityEngine;

namespace GMTK
{
    public class SeizeableObject : MonoBehaviour
    {
        public static event Action<SeizeableObject> OnSeizeableObjectSelected;
        public static event Action<SeizeableObject> OnSeizeableObjectDeselected;
        
        private void OnEnable()
        {
            OnSeizeableObjectSelected += CheckSeizeableObject;
        }

        private void OnMouseDown()
        {
            OnSeizeableObjectSelected?.Invoke(this);
        }

        private void CheckSeizeableObject(SeizeableObject seizeableObject)
        {
            if (seizeableObject != this)
            {
                OnSeizeableObjectDeselected?.Invoke(this);
            }
        }
    }
}