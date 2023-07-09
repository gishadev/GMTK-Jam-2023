using System;
using GMTK.Game.TrapsCore;
using Unity.Mathematics;
using UnityEngine;

namespace GMTK.Game.EnemyCore
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        public static event Action<IDamageable> OnDie;

        [SerializeField] private DamageType mortaldamageType;
        [SerializeField] private GameObject dieParticles;
        public DamageType MortaldamageType => mortaldamageType;


        [SerializeField] private float maxHp;
        public float MaxHp => maxHp;

        private float _currentHp;

        private void Awake()
        {
            _currentHp = maxHp;
        }

        public void TakeDamage(DamageType damage)
        {
            if (IsMortalDamage(damage))
            {
                Die();
            }
        }

        private void Die()
        {
            ParticleSystem particles = Instantiate(dieParticles, transform.position, quaternion.identity)
                .GetComponent<ParticleSystem>();
            
            particles.Play();
            Destroy(particles.gameObject, particles.main.duration);
            
            OnDie?.Invoke(this);
        }

        private bool IsMortalDamage(DamageType damage)
        {
            return (mortaldamageType & damage) != 0;
        }
    }
}