using System.Collections;
using GMTK.Game.EnemyCore;
using UnityEngine;

namespace GMTK.Game.TrapsCore
{
    public class TriggerTrapController : TrapController
    {
        [SerializeField] private AudioSource[] sounds;

        public void OnTriggerEnter(Collider other)
        {
            if (canUse)
            {
                if (other.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(damageType);
                    canUse = false;
                    StartCoroutine(Cooldown());
                    
                    foreach (var audioSource in sounds)
                    {
                        audioSource.Stop();
                    }
                    
                    sounds[Random.Range(0, sounds.Length)].Play();
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