using System.Collections;
using GMTK.Game.EnemyCore;
using UnityEngine;

namespace GMTK.Game.TrapsCore
{
    public class TriggerTrapController : MonoBehaviour
    {
        [SerializeField] private DamageType damageType;
        
        [SerializeField] private float cooldown;
        
        private bool _canUse = true;

        public void OnTriggerEnter(Collider other)
        {
            if (_canUse)
            {
                if (other.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(damageType);
                    _canUse = false;
                    StartCoroutine(Cooldown());
                }
            }
        }

        private IEnumerator Cooldown()
        {
            yield return new WaitForSeconds(cooldown);
            _canUse = true;
        }
    }
}