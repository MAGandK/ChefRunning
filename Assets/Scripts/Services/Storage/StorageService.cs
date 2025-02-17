using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;

namespace Services.Storage
{
    public class StorageService : IStorageService, IInitializable
    {
        private readonly Dictionary<string, IStorageData> _storageData;

        public StorageService(IEnumerable<IStorageData> storageData)
        {
            _storageData = storageData.ToDictionary(x => x.Key, x => x);
        }

        public void Initialize()
        {
            foreach (var (key, storageData) in _storageData)
            {
                storageData.Changed += StorageDataOnChanged;

                if (!PlayerPrefs.HasKey(key))
                {
                    continue;
                }

                var json = PlayerPrefs.GetString(key);
                var data = (IStorageData)JsonConvert.DeserializeObject(json, storageData.GetType());
                storageData.Load(data);
            }
        }

        public T GetData<T>(string key) where T : class, IStorageData
        {
            _storageData.TryGetValue(key, out var data);

            return data as T;
        }

        private void StorageDataOnChanged(string key)
        {
            if (_storageData.TryGetValue(key, out var data))
            {
                PlayerPrefs.SetString(key, JsonConvert.SerializeObject(data));
            }
        }
    }
}
