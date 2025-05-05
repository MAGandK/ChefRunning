using Audio;
using Audio.Types;
using Particles;
using PlayerLogics;
using UnityEngine;
using Zenject;

namespace Obstacle
{
    public class Coin : MonoBehaviour
    {
        private readonly float _rotationSpeed = 200f;

        private IAudioManager _audioManager;
        private IParticleManager _particleManager;

        [Inject]
        public void Construct(IAudioManager audioManager, IParticleManager particleManager)
        {
            _particleManager = particleManager;
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
            _particleManager.Play(ParticleType.CoinCollected,transform.position);
            gameObject.SetActive(false);
        }
    }
}