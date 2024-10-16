using System;
using System.Collections.Generic;
using UnityEngine;
public enum SoundType 
{
    Coin,
    Game,
    Fail,
    Push,
    Finish
}
public class AudioManager : MonoBehaviour
{
    [Serializable]
    public class SoundPreset
    {
        [field: SerializeField]
        public SoundType SoundType
        {
            get;
            private set;
        }

        [field: SerializeField]
        public AudioClip AudioClip
        {
            get;
            private set;
        }
    }
    
    [SerializeField]
    private AudioSource _audioSourceMusic;
    
    [SerializeField]
    private AudioSource _audioSourceEffect;
    
    [SerializeField]
    private SoundPreset[] _soundPresets; 
    
    private List<AudioSource> _audioSources;
    
    private void Awake()
    {
        _audioSources = new List<AudioSource>();
        if (_audioSourceEffect != null)
        {
            _audioSources.Add(_audioSourceEffect);
        }
    }

    public void PlaySound(SoundType soundType)
    {
        SoundPreset preset = Array.Find(_soundPresets, p => p.SoundType == soundType);
        
        if (preset != null && preset.AudioClip != null)
        {
            AudioSource audioSource = GetAvailableAudioSource();
            audioSource.PlayOneShot(preset.AudioClip);
        }
    }
    
    public void StopMusic()
    {
        if (_audioSourceMusic != null && _audioSourceMusic.isPlaying)
        {
            _audioSourceMusic.Stop();
        }
    }
    private AudioSource GetAvailableAudioSource()
    {

        AudioSource availableSource = _audioSources.Find(source => !source.isPlaying);

        if (availableSource == null)
        {
            availableSource = gameObject.AddComponent<AudioSource>();
            _audioSources.Add(availableSource);
        }

        return availableSource;
    }
}
