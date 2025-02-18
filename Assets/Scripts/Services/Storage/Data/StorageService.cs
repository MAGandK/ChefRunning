using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;

namespace Services.Storage
{
    public class StorageService : IStorageService, IInitializable
    {
        private readonly Dictionary<string, IStorageData> _dataMap;

        public StorageService(IEnumerable<IStorageData> data)
        {
            _dataMap = data.ToDictionary(x => x.Key, x => x);
        }

        public void Initialize()
        {
            foreach (var storageData in _dataMap)
            {
                foreach (var (_, data) in _dataMap)
                {
                    data.Changed += StorageDataOnChanged;

                    if (!PlayerPrefs.HasKey(storageData.Key))
                    {
                        continue;
                    }

                    var json = PlayerPrefs.GetString(storageData.Key);
                    var deserializeStorageData =
                        (IStorageData)JsonConvert.DeserializeObject(json, storageData.GetType());

                    data.Load(deserializeStorageData);
                }
            }
        }

        public T GetData<T>(string key) where T : class, IStorageData
        {
            _dataMap.TryGetValue(key, out var data);
            return data as T;
        }
        private void StorageDataOnChanged(string dataKey)
        {
            if (!_dataMap.TryGetValue(dataKey, out var data))
            {
                return;
            }

            var json = JsonConvert.SerializeObject(data);
            PlayerPrefs.SetString(dataKey, json);
        }
    }
}