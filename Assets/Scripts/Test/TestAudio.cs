using Audio;
using Audio.Types;
using Pool;
using UnityEngine;
using Zenject;

namespace Test
{
    public class TestAudio : MonoBehaviour
    { 
        private PooledAudio _pooledAudio;
        private IPool _pool;
        private PoolData _audio;
        private IAudioManager _audioManager;

        [Inject]
        private void Construct(IAudioManager audioManager)
        {
            _audioManager = audioManager;
        }

        private void Awake()
        {
            _audio = new PoolData(_pooledAudio, "PooledAudio");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _audioManager.Play(MusicType.Background1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _audioManager.Play(MusicType.Background2);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _audioManager.Play(SoundType.CoinCollected);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                _audioManager.Play(SoundType.Damaged);
            }
        }
    }
}