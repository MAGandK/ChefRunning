using System;
using System.Collections.Generic;
using Type;
using UnityEngine;

namespace Managers
{
    //public class AudioManager : MonoBehaviour
   // {
    //     [Serializable]
    //     public class SoundPreset
    //     {
    //         [field: SerializeField] public SoundType SoundType { get; private set; }
    //
    //         [field: SerializeField] public AudioClip AudioClip { get; private set; }
    //     }
    //
    //     [SerializeField] private AudioSource _audioGameMusic;
    //
    //     [SerializeField] private AudioSource _audioSourceEffect;
    //
    //     [SerializeField] private SoundPreset[] _soundPresets;
    //
    //     private List<AudioSource> _audioSources;
    //
    //     private void Awake()
    //     {
    //         _audioSources = new List<AudioSource>();
    //         if (_audioSourceEffect != null)
    //         {
    //             _audioSources.Add(_audioSourceEffect);
    //         }
    //
    //         if (_audioGameMusic != null)
    //         {
    //             _audioGameMusic.loop = true;
    //             PlayBackgroundMusic();
    //         }
    //     }
    //
    //     public void PlayBackgroundMusic()
    //     {
    //         if (_audioGameMusic && !_audioGameMusic.isPlaying)
    //         {
    //             _audioGameMusic.Play();
    //         }
    //     }
    //
    //     public void StopMusic()
    //     {
    //         if (_audioGameMusic && _audioGameMusic.isPlaying)
    //         {
    //             _audioGameMusic.Stop();
    //         }
    //     }
    //
    //     public void PlaySound(SoundType soundType)
    //     {
    //         SoundPreset preset = Array.Find(_soundPresets, p => p.SoundType == soundType);
    //
    //         if (preset != null && preset.AudioClip)
    //         {
    //             AudioSource audioSource = GetAvailableAudioSource();
    //             audioSource.PlayOneShot(preset.AudioClip);
    //         }
    //     }
    //
    //
    //     private AudioSource GetAvailableAudioSource()
    //     {
    //         AudioSource availableSource = _audioSources.Find(source => !source.isPlaying);
    //
    //         if (!availableSource)
    //         {
    //             availableSource = gameObject.AddComponent<AudioSource>();
    //             _audioSources.Add(availableSource);
    //         }
    //
    //         return availableSource;
    //     }
    // }
}