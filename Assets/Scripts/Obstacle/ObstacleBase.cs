using UnityEngine;

namespace Obstacle
{
    public abstract class ObstacleBase : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player.Player player))
            {
                player.Die();
            }
        }

        public virtual void Destroy()
        {
            gameObject.SetActive(false);
        }

        public virtual void ResetObstacle()
        {
            if (!gameObject.activeSelf)
            {
                gameObject.SetActive(true);
            }
        }
    }
}