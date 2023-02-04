using UnityEngine;

namespace Placuszki.VR.Scripts
{
    public class ZeroZLerper : MonoBehaviour
    {
        [SerializeField] float power = 0.8f;
        
        private bool _isEnabled = false;
        private float _timeSinceEnabled;
        private float _zWhenEnabled;

        public void SetIsEnabled(bool isEnabled)
        {
            if (_isEnabled == isEnabled)
                return;

            _isEnabled = isEnabled;
            if (isEnabled)
            {
                _timeSinceEnabled = 0;
                _zWhenEnabled = transform.position.z;
            }
        }

        private void Update()
        {
            if (!_isEnabled) return;
            _timeSinceEnabled += Time.deltaTime;

            float targetZ = 0;
            float newZ = Mathf.Lerp(_zWhenEnabled, targetZ, _timeSinceEnabled * power);
            
            Vector3 newPos = transform.position;
            newPos.z = newZ;
            transform.position = newPos;
        }
    }
}