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
    private AudioSource _audioSourceStart;
    
    [SerializeField]
    private SoundPreset[] _soundPresets; 
    
    private List<AudioSource> _audioSources;
    
    private void Awake()
    {
        _audioSources = new List<AudioSource>();
        if (_audioSourceStart != null)
        {
            _audioSources.Add(_audioSourceStart);
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
        else
        {
            Debug.LogWarning($"Sound of type {soundType} not found or AudioClip is missing.");
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
