using Particles;
using Pool;
using UnityEngine;
using Zenject;

namespace Test
{
    public class TestParticle : MonoBehaviour
    {
        private PooledParticle _pooledParticle;
        private IPool _pool;
        private IParticleManager _particleManager;

        [Inject]
        private void Construct(IParticleManager particleManager)
        {
            _particleManager = particleManager;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _particleManager.Play(ParticleType.CoinCollected, Vector3.zero);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _particleManager.Play(ParticleType.ObstacleDestroy, Vector3.zero);
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                _particleManager.ReturnAllParticle();
            }
        }
    }
}