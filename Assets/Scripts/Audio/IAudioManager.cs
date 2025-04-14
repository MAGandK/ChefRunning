namespace Audio
{
    public interface IAudioManager
    {
        public void Play(SoundType soundType, float volume = 1.0f, float pitch = 1.0f);
        public void Play(MusicType musicType, float volume = 1.0f, float pitch = 1.0f);

        public void Stop(SoundType soundType);
        public void Stop(MusicType musicType);

        public void SetMuteSound();
        public void SetMuteAllMusic();
    }
}