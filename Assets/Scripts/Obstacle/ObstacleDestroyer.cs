using UnityEngine;

namespace Obstacle
{
    public class ObstacleDestroyer : MonoBehaviour
    {
        [SerializeField] private GameObject _explosionEffects;
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

            if (other.TryGetComponent(out ObstacleBase obstacle))
            {
                obstacle.Destroy();
                ActivateHitEffects(obstacle.transform);
            }
        }

        public void ActivateHitEffects(Transform obstacleTransform)
        {
            Instantiate(_explosionEffects, obstacleTransform.position, Quaternion.identity);
        }
    }
}