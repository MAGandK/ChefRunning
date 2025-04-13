using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Audio.Settings;
using Audio.Stoarge;
using Audio.Types;
using Constants;
using Pool;
using Services.Storage;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace Audio
{
    public class AudioManager : IAudioManager, IInitializable
    {
        private readonly IPool _pool;
        private readonly MonoBehaviour _monoBehaviour;

        private Dictionary<SoundType, AudioClip> _soundMap;
        private Dictionary<MusicType, AudioClip> _musicMap;

        private readonly AudioStorageData _audioStorageData;
        private readonly IAudioSettings _audioSettings;
        private AudioMixerGroup _soundGroup;
        private AudioMixerGroup _musicGroup;

        private readonly Dictionary<SoundType, List<PooledAudio>> _pooledSoundMap = new();
        private readonly List<Coroutine> _stopSoundCoroutines = new();
        private KeyValuePair<MusicType, PooledAudio> _currentMusic;

        public bool IsSoundMuted => _audioStorageData.IsSoundMuted;
        public bool IsMusicMuted => _audioStorageData.IsMusicMuted;

        public AudioManager(IPool pool, IAudioSettings audioSettings, IStorageService storageService,
            MonoBehaviour monoBehaviour)
        {
            _audioSettings = audioSettings;
            _monoBehaviour = monoBehaviour;
            _pool = pool;
            _audioStorageData = storageService.GetData<AudioStorageData>(StorageDataNames.AUDIO_DATA_KEY);
        }

        public void Initialize()
        {
            _soundGroup = _audioSettings.AudioMixer.FindMatchingGroups("Master/Sound")[0];
            _musicGroup = _audioSettings.AudioMixer.FindMatchingGroups("Master/Music")[0];

            _soundMap = _audioSettings.AudioPresets.OfType<SoundPreset>().ToArray()
                .ToDictionary(x => x.SoundType, x => x.AudioClip);
            
            _musicMap = _audioSettings.AudioPresets.OfType<MusicPreset>().ToArray()
                .ToDictionary(x => x.MusicType, x => x.AudioClip);

            SetMuteMusic(_audioStorageData.IsMusicMuted);
            SetMuteSound(_audioStorageData.IsSoundMuted);
        }

        public void Play(SoundType soundType, float volume = 1, float pitch = 1)
        {
            if (_audioStorageData.IsSoundMuted || !_soundMap.TryGetValue(soundType, out var audioClip))
            {
                return;
            }

            var pooledAudio = Play(audioClip, _soundGroup, volume, pitch);

            if (!_pooledSoundMap.TryAdd(soundType, new List<PooledAudio>() { pooledAudio }))
            {
                _pooledSoundMap[soundType].Add(pooledAudio);
            }

            var coroutine =
                _monoBehaviour.StartCoroutine(routine: ReturnToPoolCor(soundType, pooledAudio, audioClip.length));
            _stopSoundCoroutines.Add(coroutine);
        }

        public void Play(MusicType musicType, float volume = 1, float pitch = 1)
        {
            if (!_musicMap.TryGetValue(musicType, out var audioClip))
            {
                return;
            }

            var hasMusic = _currentMusic.Value != null;

            if (_currentMusic.Key == musicType && hasMusic)
            {
                return;
            }

            if (hasMusic)
            {
                _currentMusic.Value.SetIsFree(true);
                _currentMusic.Value.gameObject.SetActive(false);
            }

            var pooledAudio = Play(audioClip, _musicGroup, volume, pitch);
            pooledAudio.SetIsLoop(true);

            _currentMusic = new KeyValuePair<MusicType, PooledAudio>(musicType, pooledAudio);
        }

        public void StopAllSound()
        {
            foreach (var (key, pooledAudios) in _pooledSoundMap)
            {
                foreach (var pooledAudio in pooledAudios)
                {
                    pooledAudio.SetIsLoop(true);
                    pooledAudio.gameObject.SetActive(false);
                }
            }

            _pooledSoundMap.Clear();

            foreach (var coroutine in _stopSoundCoroutines)
            {
                _monoBehaviour.StopCoroutine(coroutine);
            }

            _stopSoundCoroutines.Clear();
        }

        public void SetMuteSound(bool isActiveState)
        {
            _audioStorageData.SetIsSoundMute(isActiveState);

            _audioSettings.AudioMixer.SetFloat("SoundVolume", Mathf.Log10(isActiveState ? 1 : 0.000001f) * 20);
        }

        public void SetMuteMusic(bool isActiveState)
        {
            _audioStorageData.SetIsMusicMute(isActiveState);

            _audioSettings.AudioMixer.SetFloat("MusicVolume", Mathf.Log10(isActiveState ? 1 : 0.000001f) * 20);
        }

        private PooledAudio Play(AudioClip audioClip,
            AudioMixerGroup soundGroup,
            float volume = 1,
            float pitch = 1)
        {
            var pooledAudio = _pool.Get<PooledAudio>(_audioSettings.PooledAudioPrefab);
            pooledAudio.gameObject.SetActive(true);
            pooledAudio.SetupAndPlay(audioClip, volume, pitch, soundGroup);

            return pooledAudio;
        }

        private IEnumerator ReturnToPoolCor(SoundType key, PooledAudio pooledAudio, float audioClipLength)
        {
            yield return new WaitForSeconds(audioClipLength);

            pooledAudio.SetIsFree(true);
            pooledAudio.gameObject.SetActive(false);
            _pooledSoundMap[key].Remove(pooledAudio);
        }
    }
}