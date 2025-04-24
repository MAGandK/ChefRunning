using Pool;
using UnityEngine;

namespace Particles
{
    public class PooledParticle : MonoBehaviour, IPoolObject
    {
        [SerializeField] private ParticleSystem _prefab;
        
        private bool _isFree;
        public bool IsFree => _isFree;
        public void SetIsFree(bool isFree)
        {
            _isFree = isFree;
        }

        public void Play(Vector3 position)
        {
            transform.position = position;
            _prefab.Play();
            SetIsFree(false);
        }

        public void Stop()
        {
            _prefab.Stop();
            SetIsFree(false);
        }
    }
}