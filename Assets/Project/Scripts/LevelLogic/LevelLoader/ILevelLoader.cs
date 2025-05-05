using System;

namespace LevelLogic.LevelLoader
{
    public interface ILevelLoader
    {
        void LoadCurrentLevel(Action onFinished = null);
        void LoadNextLevel(Action onFinished = null);
    }
}