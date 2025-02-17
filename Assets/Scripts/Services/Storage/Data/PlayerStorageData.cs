using System;
using Newtonsoft.Json;

namespace Services.Storage
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PlayerStorageData : IStorageData<PlayerStorageData>
    {
        public event Action<string> Changed;

        [JsonProperty("levelIndex")] private int _levelIndex = 0;

        public int LevelIndex => _levelIndex;
        public string Key { get; }

        public PlayerStorageData(string key)
        {
            Key = key;
        }

        public void Load(PlayerStorageData data)
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
