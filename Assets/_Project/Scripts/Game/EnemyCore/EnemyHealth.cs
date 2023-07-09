using System;
using UnityEngine;

namespace GMTK.Game.EnemyCore
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        public event Action OnDie; 
        
        [SerializeField] private float maxHp;
        public float MaxHp => maxHp;

        private float _currentHp;
        
        private void Awake()
        {
            _currentHp = maxHp;
        }

        public void TakeDamage(float damage)
        {
            if (_currentHp > damage)
            {
                _currentHp -= damage;
            }
            else
            {
                Die();
            }
        }

        private void Die()
        {
            OnDie?.Invoke();
        }
    }
}