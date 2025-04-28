using System;

namespace LevelLogic
{
    public class LevelModel : ILevelModel
    {
        public event Action<LevelState> StateChanged;

        public LevelState State { get; private set; } = LevelState.Loaded;

        public void SetState(LevelState newState)
        {
            State = newState;

            StateChanged?.Invoke(State);
        }
    }
}