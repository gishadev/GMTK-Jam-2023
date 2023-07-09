using UnityEngine;

namespace GMTK.Game.Location
{
    [RequireComponent(typeof(Collider))]
    public class LocationBounds : MonoBehaviour
    {
        private Collider _collider;

        public Collider Collider => _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }
    }
}