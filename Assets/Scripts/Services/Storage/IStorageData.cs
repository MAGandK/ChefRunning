using System;

namespace Services.Storage
{
    public interface IStorageData
    {
        event Action<string> Changed;

        string Key { get; }

        void Load(IStorageData data);
    }

    public interface IStorageData<in T> : IStorageData
    {
        void IStorageData.Load(IStorageData data)
        {
            if (data is not T tData)
            {
                throw new ArgumentException($"Data is not {typeof(T).Name}");
            }

            Load(tData);
        }

        void Load(T data);
    }
}
