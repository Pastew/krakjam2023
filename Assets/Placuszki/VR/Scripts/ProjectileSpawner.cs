using Mirror;
using UnityEngine;

namespace Placuszki.VR
{
    public class ProjectileSpawner : NetworkBehaviour
    {
        [SerializeField] private GameObject spawnPoint;
        [SerializeField] private GameObject projectilePrefab;

        private void OnConnectedToServer()
        {
            SpawnNewProjectile();
        }

        [Command(requiresAuthority = false)]
        public void SpawnNewProjectile()
        {
            GameObject newProjectile = Instantiate(projectilePrefab);//TODO: Szymon
            newProjectile.transform.position = spawnPoint.transform.position;
            newProjectile.transform.rotation = spawnPoint.transform.rotation;

            NetworkServer.Spawn(newProjectile);
            
            Projectile projectile = newProjectile.GetComponent<Projectile>();
        }
    }
}
