using UnityEngine;

namespace Placuszki.VR
{
    public class MonkeDamageReceiver : MonoBehaviour
    {
        [SerializeField] private GameObject deadParticlePrefab;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"MonkeDamageReceiver OnTriggerEnter with {other.gameObject.name}");
            
            if (other.GetComponent<Projectile>())
            {
                ReceiveDamage();
                Destroy(other);
            }
        }

        private void ReceiveDamage()
        {
            gameObject.transform.parent.gameObject.SetActive(false);
            var particle = Instantiate(deadParticlePrefab, transform.position, Quaternion.identity);
            particle.transform.parent = null;
            Destroy(particle, 5);
        }
    }
}
