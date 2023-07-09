using GMTK.Game.Location;
using UnityEngine;

namespace GMTK.Game.Core
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 0)]
    public class GameDataSO : ScriptableObject
    {
        [SerializeField] private GameObject playerPrefab;

        [SerializeField] private float fullManaTimeInSeconds = 30f;
        [SerializeField] private float manaTimePenaltyPerSeizeInSeconds = 1f;

        [SerializeField] private LocationDataSO[] locations;


        public float ManaDecreasePerSecond => Time.deltaTime / FullManaTimeInSeconds;
        public float ManaTimePenaltyPerSeizeInSeconds => manaTimePenaltyPerSeizeInSeconds;
        public float FullManaTimeInSeconds => fullManaTimeInSeconds;

        public LocationDataSO[] Locations => locations;

        public GameObject PlayerPrefab => playerPrefab;
    }
}