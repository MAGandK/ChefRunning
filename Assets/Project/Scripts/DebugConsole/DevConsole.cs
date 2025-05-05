using LevelLogic;
using LevelLogic.LevelLoader;
using UnityEngine;
using Zenject;

namespace DebugConsole
{
    public class DevConsole : IDevConsole, ITickable
    {
        private readonly ILevelLoader _levelLoader;

        public DevConsole(ILevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
        }

        public void Tick()
        {
            LoadLevels();
        }

        private void LoadLevels()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _levelLoader.LoadNextLevel();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                _levelLoader.LoadCurrentLevel();
            }
        }
    }
}