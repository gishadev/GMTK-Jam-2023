using UnityEngine;

namespace GMTK.Game.Location
{
    [CreateAssetMenu(fileName = "LocationData", menuName = "ScriptableObjects/LocationData", order = 0)]
    public class LocationDataSO : ScriptableObject
    {
        [SerializeField] private Location locationPrefab;

        public Location LocationPrefab => locationPrefab;
    }
}