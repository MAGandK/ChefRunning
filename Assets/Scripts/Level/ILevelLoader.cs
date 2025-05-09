using System;
using System.Collections;

namespace Level
{
    public interface ILevelLoader
    {
        void LoadCurrentLevel(Action onFinished = null);
        void LoadNextLevel(Action onFinished = null);
    }
}