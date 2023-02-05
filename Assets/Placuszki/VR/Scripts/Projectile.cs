using BNG;
using Placuszki.VR.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace Placuszki.VR
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private GrabbableUnityEvents grabbableUnityEvents;
        [SerializeField] private Grabbable grabbable;
        [SerializeField] private ZeroZLerper zeroZLerper;

        private Rigidbody _rigidbody;
        
        private void Start()
        {
            grabbableUnityEvents.onGrab.AddListener(ProjectileGrabbed);
            grabbableUnityEvents.onRelease.AddListener(ProjectileReleased);
            _rigidbody = GetComponent<Rigidbody>();
            
            FindObjectOfType<VrGameManager>().OnProjectileSpawned(this);

        }

        private void ProjectileGrabbed(Grabber grabber)
        {
            FindObjectOfType<VrGameManager>().OnProjectileGrabbed(this);
        }
        
        private void ProjectileReleased()
        {
            grabbable.enabled = false;
            zeroZLerper.SetIsEnabled(true);
            _rigidbody.useGravity = true;
            // _rigidbody.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            
            // var rot = transform.rotation;
            // rot.z = 0;
            // rot.y = 0;
            // transform.rotation = rot;
        }
    }
}
