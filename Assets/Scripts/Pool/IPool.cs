using UnityEngine;

namespace Pool
{
    public interface IPool
    {
        public T Get<T>(MonoBehaviour key) where T : class, IPoolObject;
    }
}