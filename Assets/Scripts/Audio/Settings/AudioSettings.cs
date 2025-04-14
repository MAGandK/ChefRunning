using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(menuName = "Create AudioSettings", fileName = "AudioSettings", order = 0)]
    public class AudioSettings : ScriptableObject
    {
        [SerializeField] private Audio _audioPrefab;
        [SerializeField] private MusicAudioPreset[] _musicAudioPresets;
        [SerializeField] private SoundAudioPreset[] _soundAudioPresets;

        public MusicAudioPreset[] MusicAudioPreset => _musicAudioPresets;
        public SoundAudioPreset[] SoundAudioPreset => _soundAudioPresets;
        public Audio AudioPrefab => _audioPrefab;
        
    }
}