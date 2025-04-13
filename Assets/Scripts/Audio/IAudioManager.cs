using Audio.Types;

namespace Audio
{
    public interface IAudioManager
    {
        void Play(SoundType soundType, float volume = 1, float pitch = 1);
        void Play(MusicType musicType, float volume = 1, float pitch = 1);
        void StopAllSound();
        
        void SetMuteSound(bool isActiveState);
        void SetMuteMusic(bool isActiveState);
        bool IsSoundMuted { get; }
        bool IsMusicMuted { get; }
    }
}