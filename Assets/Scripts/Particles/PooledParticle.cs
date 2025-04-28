using Pool;
using UnityEngine;

namespace Particles
{
    public class PooledParticle : MonoBehaviour, IPoolObject
    {
        [SerializeField] private ParticleSystem _particleSystem;

        [SerializeField] private bool _isFree;

        public bool IsFree => _isFree;
        public ParticleSystem ParticleSystem => _particleSystem;

        public void SetIsFree(bool isFree)
        {
            _isFree = isFree;
        }

        public void SetupAndPlay(Vector3 position, Vector3 scale)
        {
            transform.position = position;
            transform.localScale = scale;
            gameObject.SetActive(true);
            _particleSystem.Play();
            SetIsFree(false);
        }

        public void Stop()
        {
            _particleSystem.Stop();
            SetIsFree(true);
        }
    }
}