using UnityEngine;

namespace Placuszki.VR.Scripts
{
    public class VrGameManager : MonoBehaviour
    {
        [SerializeField] private ProjectileSpawner projectileSpawner;
        [SerializeField] private float delayBeforeSpawningNextProjectile = 1;

        private Projectile _currentSpawnedProjectile;

        private void Start()
        {
            //SpawnNewProjectile();
        }

        private void SpawnNewProjectile()
        {
            projectileSpawner.SpawnNewProjectile();
        }

        public void OnProjectileGrabbed(Projectile projectile)
        {
            if (_currentSpawnedProjectile != null)
            {
                _currentSpawnedProjectile = null;
                Invoke(nameof(SpawnNewProjectile), delayBeforeSpawningNextProjectile);
            }
        }

        public void OnProjectileSpawned(Projectile projectile)
        {
            _currentSpawnedProjectile = projectile;
        }
    }
}