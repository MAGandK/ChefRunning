using UnityEngine;

namespace PlayerLogick
{
    public class ObstacleDestroyer : MonoBehaviour
    {
        private bool _canDestroy;

        public void SetCanDestroy(bool canDestroy)
        {
            _canDestroy = canDestroy;
        }
        
        private void OnTriggerStay(Collider other)
        {
            if (!_canDestroy)
            {
                return;
            }

            if (other.TryGetComponent(out ObstacleBarrel obstacleBarrel))
            {
                obstacleBarrel.Destroy();
            }
        }
    }
}