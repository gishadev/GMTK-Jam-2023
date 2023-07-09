using System.Collections;
using GMTK.Game.EnemyCore;
using UnityEngine;

namespace GMTK.Game.TrapsCore
{
    public class TriggerTrapController : TrapController
    {
        [SerializeField] private bool destroyOnActivate;

        public void OnTriggerEnter(Collider other)
        {
            if (canUse)
            {
                if (other.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(damageType);
                    canUse = false;
                    StartCoroutine(Cooldown());

                    if (destroyOnActivate)
                        Destroy(gameObject);
                }
            }
        }

        private IEnumerator Cooldown()
        {
            yield return new WaitForSeconds(cooldown);
            canUse = true;
        }
    }
}