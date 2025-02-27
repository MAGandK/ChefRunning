using Constants;
using Services.Storage;

namespace Level
{
    public class LevelController : ILevelController
    {
        private readonly LevelProgressStorageData _levelProgressStorageData;
        private readonly IStorageService _storageService;

        public LevelController(IStorageService storageService)
        {
            _storageService = storageService; 
            _levelProgressStorageData = storageService.GetData<LevelProgressStorageData>(StorageDataNames.LEVEL_PROGRESS_STORAGE_DATA_KEY);
        }
        
        public void LoadLevel()
        {
            var savedData = _storageService.GetData<LevelProgressStorageData>(StorageDataNames.LEVEL_PROGRESS_STORAGE_DATA_KEY);
            if (savedData != null)
            {
                _levelProgressStorageData.Load(savedData);
            }
        }

        public void NextLevel()
        {
            _levelProgressStorageData.IncrementLevelIndex();
        }
    }
}