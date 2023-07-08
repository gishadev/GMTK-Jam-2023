using UnityEngine;
using UnityEngine.AI;

namespace GMTK.Game.Player
{
    public class PlayerAi : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Transform target;
        
        public void MoveToFinish()
        {
            agent.SetDestination(target.position);
        }
    }
}