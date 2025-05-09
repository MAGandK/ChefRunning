using LevelLogic.LevelLoader;
using Services.Storage;
using UnityEngine;
using Zenject;

namespace DebugConsole.Controllers
{
    public class DevConsoleLevelController : AbstractDevConsoleController, ITickable
    {
        private readonly ILevelLoader _levelLoader;

        protected override string GroupName => "Levels";
        public override int GroupPriority => 1;

        public DevConsoleLevelController(ILevelLoader levelLoader, IStorageService storageService)
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

        public override void Init()
        {
            AddButton("Load next", () => _levelLoader.LoadNextLevel());
        }
    }
}