using System;
using GMTK.Game.EnemyCore;
using UnityEngine;

namespace GMTK.Game.TrapsCore
{
    public class ProjectileController : MonoBehaviour
    {
        public event Action<ProjectileController> OnProjectileDisabled; 

        [SerializeField] private float projectileSpeed = 3;
        [SerializeField] private Rigidbody rb;

        private Vector3 _startPosition;
        private DamageType _damageType;

        private void OnEnable()
        {
            rb.velocity = Vector3.back * projectileSpeed;
        }

        private void OnDisable()
        {
            OnProjectileDisabled?.Invoke(this);
            transform.position = _startPosition;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_damageType);
            }
            
            gameObject.SetActive(false);
        }

        public void Init(DamageType damageType)
        {
            _damageType = damageType;
            _startPosition = transform.position;
        }
    }
}