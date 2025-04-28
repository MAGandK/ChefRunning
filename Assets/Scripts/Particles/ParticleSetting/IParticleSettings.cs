namespace Particles.ParticleSetting
{
    public interface IParticleSettings
    { 
        ParticlePreset[] ParticlePresets { get; }
        PooledParticle PooledParticlePrefab { get; }
    }
}