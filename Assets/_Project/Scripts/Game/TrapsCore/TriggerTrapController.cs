using GMTK.Game.EnemyCore;
using UnityEngine;

namespace GMTK.Game.TrapsCore
{
    public class TriggerTrapController : MonoBehaviour
    {
        [SerializeField] private DamageType damageType;
        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damageType);
            }
        }
    }
}