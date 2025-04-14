using System;
using UnityEngine;

namespace Audio
{
    [Serializable]
    public abstract class AbstractAudioPreset
    {
        [SerializeField] private AudioClip _audioClip;

        public AudioClip AudioClip => _audioClip;
    }
}