using UnityEngine;

namespace CustomNameSpase
{
    public abstract class ObstacleBase : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
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
