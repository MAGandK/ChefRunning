using LevelLogic.LevelLoader;
using SRDebugger;
using UnityEngine;
using Zenject;

namespace DebugConsole.Controllers
{
    public class LevelDevConsoleController : IDevConsoleController, ITickable
    {
        private const string CategoryName = "Level";

        private readonly ILevelLoader _levelLoader;

        public LevelDevConsoleController(ILevelLoader levelLoader)
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

        public void Init()
        {
            var optionDefinition =
                OptionDefinition.FromMethod("Next level", () => _levelLoader.LoadNextLevel(), CategoryName);
            SRDebug.Instance.AddOption(optionDefinition);
            optionDefinition =
                OptionDefinition.FromMethod("Reload level", () => _levelLoader.LoadCurrentLevel(), CategoryName);
            SRDebug.Instance.AddOption(optionDefinition);
        }
    }
}