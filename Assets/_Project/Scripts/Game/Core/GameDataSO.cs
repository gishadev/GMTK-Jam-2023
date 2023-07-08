using UnityEngine;

namespace GMTK.Game.Core
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 0)]
    public class GameDataSO : ScriptableObject
    {
        [SerializeField] private float fullManaTimeInSeconds = 30f;
        [SerializeField] private float manaTimePenaltyPerSeizeInSeconds = 1f;

        public float ManaDecreasePerSecond => Time.deltaTime / FullManaTimeInSeconds;
        public float ManaTimePenaltyPerSeizeInSeconds => manaTimePenaltyPerSeizeInSeconds;
        public float FullManaTimeInSeconds => fullManaTimeInSeconds;
    }
}