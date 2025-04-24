using Pool;
using UnityEngine;

namespace Particles
{
    public class Particle : MonoBehaviour,IPoolObject
    {
        [SerializeField] private ParticleSystem _particleSystem;
        public bool _isFree;
        public bool IsFree => _isFree;
        public void SetIsFree(bool isFree)
        {
            _isFree = isFree;
            gameObject.SetActive(!_isFree);
        }
    }
}