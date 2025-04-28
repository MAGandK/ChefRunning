using System.Collections;
using System.Collections.Generic;
using Particles.ParticleSetting;
using Pool;
using UnityEngine;
using Zenject;

namespace Particles
{
    public class ParticleManager : IParticleManager, IInitializable
    {
        private readonly IPool _pool;
        private readonly IParticleSettings _particleSettings;
        private readonly MonoBehaviour _monoBehaviour;
        private readonly List<PooledParticle> _activeParticles = new();
        public ParticleManager(IPool pool,  IParticleSettings particleSettings,MonoBehaviour monoBehaviour)
        {
            _pool = pool;
            _particleSettings = particleSettings;
            _monoBehaviour = monoBehaviour;
        }

        public void Initialize()
        {
            
        }

        public void Play(Vector3 position)
        {
            var poolData = new PoolData(_particleSettings.PooledParticlePrefab, "PooledParticle");
            var pooledParticle = _pool.Get<PooledParticle>(poolData);
        
            pooledParticle.transform.position = position;
            pooledParticle.gameObject.SetActive(true);
            pooledParticle.Play(position);

            _activeParticles.Add(pooledParticle);

            _monoBehaviour.StartCoroutine(ReturnToPoolCor(pooledParticle));
        }

        public void Stop()
        {
            foreach (var particle in _activeParticles)
            {
                particle.Stop();
                particle.gameObject.SetActive(false);
                particle.SetIsFree(true);
            }
            _activeParticles.Clear();
        }
        
        private IEnumerator ReturnToPoolCor(PooledParticle pooledParticle)
        {
            var main = pooledParticle.GetComponent<ParticleSystem>().main;
            yield return new WaitForSeconds(main.duration + main.startLifetime.constant);

            pooledParticle.Stop();
            pooledParticle.gameObject.SetActive(false);
            pooledParticle.SetIsFree(true);

            _activeParticles.Remove(pooledParticle);
        }
    }
}