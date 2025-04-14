using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public interface IPool
    {
        public T PreparePool<T>(PoolData poolData, int count) where T : class, IPoolObject;
        public List<IPoolObject> GetPool();
        public T Get<T>(PoolData key) where T : class, IPoolObject;

        public void ClearPool();
        public void ClearPool(PoolData data);
    }
}

public struct PoolData
{
    public MonoBehaviour obj;
    public string key;

    public PoolData(MonoBehaviour obj, string key)
    {
        this.obj = obj;
        this.key = key;
    }

    public override bool Equals(object obj)
    {
        if (obj is PoolData otherData)
        {
            return obj == otherData.obj && key == otherData.key;
        }

        return false;
    }
    
    public override int GetHashCode()
    {
        return (obj, key).GetHashCode();
    }
}