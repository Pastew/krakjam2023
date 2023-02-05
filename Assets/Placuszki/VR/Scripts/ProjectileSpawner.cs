using UnityEngine;

namespace Placuszki.VR
{
    public class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject spawnPoint;
        [SerializeField] private GameObject projectilePrefab;

        private void Start()
        {
            SpawnNewProjectile();
        }

        public Projectile SpawnNewProjectile()
        {
            GameObject newProjectile = Instantiate(projectilePrefab, spawnPoint.transform);//TODO: Szymon
            newProjectile.transform.localPosition = Vector3.zero;
            newProjectile.transform.localRotation = Quaternion.identity;

            Projectile projectile = newProjectile.GetComponent<Projectile>();
            return projectile;
        }
    }
}
