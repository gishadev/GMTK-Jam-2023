using UnityEngine;

namespace GMTK.Game.Location
{
    public class Location : MonoBehaviour
    {
        private EnterPoint _enterPoint;
        private ExitPoint _exitPoint;

        private void Awake()
        {
            _enterPoint = GetComponentInChildren<EnterPoint>();
            _exitPoint = GetComponentInChildren<ExitPoint>();

            if (_enterPoint == null)
                Debug.LogError("No enter point on the location");

            if (_exitPoint == null)
                Debug.LogError("No exit point on the location");
        }
        
        
    }
}