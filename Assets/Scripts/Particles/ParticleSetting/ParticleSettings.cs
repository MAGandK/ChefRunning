using UnityEngine;

namespace Particles.ParticleSetting
{
    [CreateAssetMenu(menuName = "Particle/Create ParticleSettings", fileName = "ParticleSettings", order = 0)]
    public class ParticleSettings : ScriptableObject, IParticleSettings
    {
        [SerializeField] private ParticlePreset[] _particlePresets;

        public ParticlePreset[] ParticlePresets => _particlePresets;
    }
}