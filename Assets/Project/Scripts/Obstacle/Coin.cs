using Audio;
using Audio.Types;
using PlayerLogics;
using UnityEngine;
using Zenject;

namespace Obstacle
{
    public class Coin : MonoBehaviour
    {
        private readonly float _rotationSpeed = 200f;

        private IAudioManager _audioManager;

        [Inject]
        public void Construct(IAudioManager audioManager)
        {
            _audioManager = audioManager;
        }

        private void Update()
        {
            transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<Player>(out _))
            {
                return;
            }
            
            _audioManager.Play(SoundType.CoinCollected);
            gameObject.SetActive(false);
        }
    }
}