using UnityEngine;

namespace GMTK.Game.EnemyCore
{
    public class Enemy : MonoBehaviour, ISeizeable
    {
        public bool IsSeized { get; private set; }

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