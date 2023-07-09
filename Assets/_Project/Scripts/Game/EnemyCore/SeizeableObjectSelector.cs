using System;
using GMTK.Game.EnemyCore;
using UnityEngine;

namespace GMTK
{
    public class SeizeableObjectSelector : MonoBehaviour
    {
        public static event Action<ISeizeable> SeizeableObjectSelected;
        private ISeizeable _seizeable;

        private void Awake()
        {
            _seizeable = GetComponent<ISeizeable>();
        }

        private void OnMouseDown()
        {
            SeizeableObjectSelected?.Invoke(_seizeable);
        }
    }
}