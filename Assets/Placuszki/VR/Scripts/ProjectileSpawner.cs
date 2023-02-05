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

        public void SpawnNewProjectile()
        {
            GameObject newProjectile = Instantiate(projectilePrefab);//TODO: Szymon
            newProjectile.transform.position = spawnPoint.transform.position;
            newProjectile.transform.rotation = spawnPoint.transform.rotation;

            Projectile projectile = newProjectile.GetComponent<Projectile>();
        }
    }
}
