using System;
using UnityEngine;

namespace GMTK
{
    public class SeizeableObject : MonoBehaviour
    {
        public static event Action<SeizeableObject> OnSeizeableObjectSelected;

        private void OnMouseDown()
        {
            OnSeizeableObjectSelected?.Invoke(this);
        }
    }
}