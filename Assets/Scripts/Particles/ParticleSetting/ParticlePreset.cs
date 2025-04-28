using UnityEngine;

namespace Particles.ParticleSetting
{
    [CreateAssetMenu(menuName = "Particle/Preset/Create ParticlePreset", fileName = "ParticlePreset", order = 0)]
    public class ParticlePreset : ScriptableObject
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private float _duration = 5f;
        [SerializeField] private Vector3 _scale = Vector3.one;
        
        public ParticleSystem Particle => _particleSystem;
        public float Duration => _duration;
        public Vector3 Scale => _scale;
    }
}