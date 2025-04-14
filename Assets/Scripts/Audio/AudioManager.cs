using System.Collections;
using System.Collections.Generic;
using Pool;
using UnityEngine;

namespace Audio
{
    public class AudioManager : IAudioManager
    {
        private readonly AudioSettings _audioSettings;
        private readonly IPool _pool;
        private readonly PoolData _monoBehaviour;

        private readonly Dictionary<SoundType, List<Coroutine>> _returnSoundCoroutines = new();
        private readonly Dictionary<MusicType,List<Coroutine>> _returnMusicCoroutines = new();

        public AudioManager(AudioSettings audioSettings, IPool pool, PoolData monoBehaviour)
        {
            _audioSettings = audioSettings;
            _pool = pool;
            _monoBehaviour = monoBehaviour;
        }

        public void Play(SoundType soundType, float volume = 1, float pitch = 1)
        {
            var presets = _audioSettings.SoundAudioPreset;

            foreach (var preset in presets)
            {
                if (preset.SoundType == soundType)
                {
                   // var audio = _pool.Get<Audio>(_audioSettings.AudioPrefab);
                   // audio.Setup(preset.AudioClip, volume,pitch);
                   // var startCoroutine =
                       // _monoBehaviour.StartCoroutine(ReturnAudioInPool(audio, preset.AudioClip.length));
                }
            }
        }

        public void Play(MusicType musicType, float volume = 1, float pitch = 1)
        {
            var presets = _audioSettings.MusicAudioPreset;

            foreach (var preset in presets)
            {
                if (preset.MusicType == musicType)
                {
                   // var audio = _pool.Get<Audio>(_audioSettings.AudioPrefab);
                  //  audio.Setup(preset.AudioClip, volume,pitch);
                  //  var startCoroutine =
                     //   _monoBehaviour.StartCoroutine(ReturnAudioInPool(audio, preset.AudioClip.length));
                }
            }
        }

        public void Stop(SoundType soundType)
        {
            var returnSoundCoroutines = _returnSoundCoroutines[soundType];
            foreach (var soundCoroutine  in returnSoundCoroutines)
            {
              //  _monoBehaviour.StopCoroutine(soundCoroutine);
            }
        }

        public void Stop(MusicType musicType)
        {
        }

        public void SetMuteSound()
        {
        }

        public void SetMuteAllMusic()
        {
        }
        
        private IEnumerator ReturnAudioInPool(Audio audio, float returnDuration)
        {
            yield return new WaitForSeconds(returnDuration);
            audio.SetIsFree(true);
        }
    }
}