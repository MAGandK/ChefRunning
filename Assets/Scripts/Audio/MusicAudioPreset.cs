using System;
using Audio;
using UnityEngine;

[Serializable]
public class MusicAudioPreset : AbstractAudioPreset
{
    [SerializeField] private MusicType _musicType;

    public MusicType MusicType => _musicType;
}