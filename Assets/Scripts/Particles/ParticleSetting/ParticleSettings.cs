using UnityEngine;

namespace Particles.ParticleSetting
{
    [CreateAssetMenu(menuName = "Particle/Create ParticleSettings", fileName = "ParticleSettings", order = 0)]
    public class ParticleSettings : ScriptableObject, IParticleSettings
    {
        [SerializeField] private ParticlePreset[] _particlePresets;
        [SerializeField] private PooledParticle _pooledParticle;

        public ParticlePreset[] ParticlePresets => _particlePresets;
        public PooledParticle PooledParticlePrefab => _pooledParticle;
    }
}