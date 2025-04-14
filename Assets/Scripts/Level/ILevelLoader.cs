using System;

namespace Level
{
    public interface ILevelLoader
    {
        void LoadCurrentLevel(Action onFinished = null);
        void LoadNextLevel(Action onFinished = null);
    }
}