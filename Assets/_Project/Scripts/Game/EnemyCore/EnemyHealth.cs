using System;
using GMTK.Game.TrapsCore;
using UnityEngine;

namespace GMTK.Game.EnemyCore
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        public static event Action<IDamageable> OnDie;

        [SerializeField] private DamageType mortaldamageType;
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
            OnDie?.Invoke(this);
        }

        private bool IsMortalDamage(DamageType damage)
        {
            return (mortaldamageType & damage) != 0;
        }
    }
}