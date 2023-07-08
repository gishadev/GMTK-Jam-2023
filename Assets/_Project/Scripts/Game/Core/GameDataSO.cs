using UnityEngine;

namespace GMTK.Game.Core
{
    [CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 0)]
    public class GameDataSO : ScriptableObject
    {
        [SerializeField] private float fullManaTimeInSeconds;

        public float ManaDecreasePerSecond => Time.deltaTime / fullManaTimeInSeconds;
    }
}