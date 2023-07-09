using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GMTK.Game.TrapsCore
{
    public class ProjectileTrapController : TrapController
    {
        [SerializeField] private ProjectileController projectilePrefab;
        [SerializeField] private Transform[] spawnSpots;
        
        [SerializeField] private int projectilesInPool;
        private Queue<ProjectileController> _projectilePool;

        private void Awake()
        {
            _projectilePool = new Queue<ProjectileController>();
            ProjectileController projectile;

            for (int i = 0; i < projectilesInPool; i++)
            {
                projectile = Instantiate(projectilePrefab, spawnSpots[Random.Range(0, spawnSpots.Length)].position, Quaternion.identity);
                projectile.Init(damageType);

                projectile.OnProjectileDisabled += AddToPool;
                
                projectile.gameObject.SetActive(false);
                AddToPool(projectile);
            }
        }

        private void Start()
        {
            StartCoroutine(ShootArrowsRecursively());
        }

        private IEnumerator ShootArrowsRecursively()
        {
            yield return new WaitForSeconds(cooldown);
            _projectilePool.Dequeue().gameObject.SetActive(true); 
            StartCoroutine(ShootArrowsRecursively());
        }

        private void AddToPool(ProjectileController projectile)
        {
            _projectilePool.Enqueue(projectile);
        }
    }
}