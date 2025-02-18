using System;

namespace Services.Storage
{
    public class StorageData : IStorageData<StorageData>
    {
        public event Action<string> Changed;
        private int _levelIndex;
        public string Key => "player.data";
        
        public StorageData()
        {
            _levelIndex = 0; 
        }
        
        public int GetLevelIndex() => _levelIndex;
        public void Load(StorageData data)
        {
            _levelIndex = data._levelIndex;
        }

        public void IncrementLevelIndex()
        {
            _levelIndex++;
            
            Changed?.Invoke(Key);
        }
    }
}