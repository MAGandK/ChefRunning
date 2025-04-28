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
        private PoolData _test;
        private IParticleManager _particleManager;

        [Inject]
        private void Construct(IParticleManager particleManager)
        {
            _particleManager = particleManager;
        }

        private void Awake()
        {
            _test = new PoolData(_pooledParticle, "PooledParticle");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
               _particleManager.Play(new Vector3(0,0,0));
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _particleManager.Stop();
            }
        }
    }
}