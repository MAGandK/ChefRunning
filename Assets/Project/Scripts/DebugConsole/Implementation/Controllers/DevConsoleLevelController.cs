using Constants;
using LevelLogic.LevelLoader;
using Services.Storage;
using Services.Storage.Data.Implementation;
using SRDebugger;
using UnityEngine;
using Zenject;

namespace DebugConsole.Controllers
{
    public class DevConsoleLevelController : AbstractDevConsoleController, ITickable
    {
        private readonly ILevelLoader _levelLoader;
        private LevelProgressStorageData _levelProgressStorageData;
        
        protected override string GroupName => "Levels";
        
        public DevConsoleLevelController(ILevelLoader levelLoader, IStorageService storageService)
        {
            _levelLoader = levelLoader;

            _levelProgressStorageData =
                storageService.GetData<LevelProgressStorageData>(StorageDataNames.LEVEL_PROGRESS_STORAGE_DATA_KEY);
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
            
        }
    }
}