using UnityEngine;
using Zenject;

namespace Particles
{
    public class ParticleManager : IParticleManager, IInitializable
    {
        private readonly PooledParticle _pooled;
        private readonly MonoBehaviour _monoBehaviour;

        public ParticleManager(PooledParticle pooled, MonoBehaviour monoBehaviour)
        {
            _pooled = pooled;
            _monoBehaviour = monoBehaviour;
        }

        public void Initialize()
        {
            
        }

        public void Play(Vector3 position)
        {
            
        }

        public void Stop()
        {
            
        }
    }
}