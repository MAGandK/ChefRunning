using System;
using UnityEngine;

namespace Audio.Settings
{
    [Serializable]
    public class AudioPreset : ScriptableObject
    {
        [SerializeField] private AudioClip _audioClip;

        public AudioClip AudioClip => _audioClip;
    }
}