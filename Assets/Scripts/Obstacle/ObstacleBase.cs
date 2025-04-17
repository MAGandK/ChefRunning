using Audio;
using Audio.Types;
using PlayerLogics;
using UnityEngine;
using Zenject;

namespace Obstacle
{
    public abstract class ObstacleBase : MonoBehaviour
    {
        private IAudioManager _audioManager;

        [Inject]
        private void Construct(IAudioManager audioManager)
        {
            _audioManager = audioManager;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.Die();
            }
        }

        public virtual void Destroy()
        {
            _audioManager.Play(SoundType.ObstacleDestroed);
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