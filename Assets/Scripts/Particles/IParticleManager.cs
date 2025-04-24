using UnityEngine;

namespace Particles
{
    public interface IParticleManager
    {
        void Play(Vector3 position);
        void Stop();
    }
}