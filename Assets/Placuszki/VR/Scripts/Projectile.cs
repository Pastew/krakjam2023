using BNG;
using Placuszki.VR.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace Placuszki.VR
{
    public class Projectile : MonoBehaviour
    {
        public UnityEvent OnProjectileGrabbed;
        
        [SerializeField] private GrabbableUnityEvents grabbableUnityEvents;
        [SerializeField] private Grabbable grabbable;
        [SerializeField] private ZeroZLerper zeroZLerper;

        private Rigidbody _rigidbody;
        
        private void Start()
        {
            grabbableUnityEvents.onGrab.AddListener(ProjectileGrabbed);
            grabbableUnityEvents.onRelease.AddListener(ProjectileReleased);
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void ProjectileGrabbed(Grabber grabber)
        {
            OnProjectileGrabbed.Invoke();
        }
        
        private void ProjectileReleased()
        {
            grabbable.enabled = false;
            _rigidbody.useGravity = true;
            zeroZLerper.SetIsEnabled(true);
        }
    }
}
