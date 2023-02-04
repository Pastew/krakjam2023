using System;
using BNG;
using UnityEngine;
using UnityEngine.Events;

namespace Placuszki.VR
{
    public class Projectile : MonoBehaviour
    {
        public UnityEvent OnProjectileGrabbed;
        
        [SerializeField] private GrabbableUnityEvents grabbableUnityEvents;

        private void Start()
        {
            grabbableUnityEvents.onGrab.AddListener(ProjectileGrabbed);
        }

        private void ProjectileGrabbed(Grabber arg0)
        {
            OnProjectileGrabbed.Invoke();
        }
    }
}
