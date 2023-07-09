using UnityEngine;

namespace GMTK.Game.Location
{
    public class Location : MonoBehaviour
    {
        private EnterPoint _enterPoint;
        private ExitPoint _exitPoint;
        private LocationBounds _locationBounds;

        public EnterPoint EnterPoint => _enterPoint;
        public ExitPoint ExitPoint => _exitPoint;
        public LocationBounds LocationBounds => _locationBounds;

        private void Awake()
        {
            _enterPoint = GetComponentInChildren<EnterPoint>();
            _exitPoint = GetComponentInChildren<ExitPoint>();
            _locationBounds = GetComponentInChildren<LocationBounds>();

            if (EnterPoint == null)
                Debug.LogError("No enter point on the location");

            if (ExitPoint == null)
                Debug.LogError("No exit point on the location");
            
            if (LocationBounds == null)
                Debug.LogError("No location bounds on the location");
        }
        
        
    }
}