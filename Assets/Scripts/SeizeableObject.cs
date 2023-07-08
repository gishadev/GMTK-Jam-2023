using System;
using UnityEngine;

namespace GMTK
{
    public class SeizeableObject : MonoBehaviour
    {
        public event Action<Transform> OnSeizeableObjectSelected; 

        private void OnMouseDown()
        {
            OnSeizeableObjectSelected?.Invoke(transform);
        }
    }
}