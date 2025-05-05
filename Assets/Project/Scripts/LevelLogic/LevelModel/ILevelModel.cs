using System;

namespace LevelLogic.LevelModel
{
    public interface ILevelModel
    {
        event Action<LevelState> StateChanged;
        LevelState State { get; }
        void SetState(LevelState newState);
    }
}