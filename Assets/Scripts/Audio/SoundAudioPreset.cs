using System;
using Audio;
using UnityEngine;

[Serializable]
public class SoundAudioPreset : AbstractAudioPreset
{
    [SerializeField] private SoundType _soundType;

    public SoundType SoundType => _soundType;
}