using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Pool
{
    public class Pool : IPool
    {
        private readonly DiContainer _diContainer;
        private readonly Dictionary<PoolData, List<IPoolObject>> _poolObjects = new();
        private readonly Dictionary<PoolData, Transform> _poolObjectsParents = new();
        private readonly Transform _poolParent;

        public Pool(DiContainer diContainer)
        {
            _diContainer = diContainer;
            _poolParent = _diContainer.CreateEmptyGameObject("Pool").transform;
        }

        public T PreparePool<T>(PoolData key, int count) where T : class, IPoolObject
        {
            if (_poolObjects.TryGetValue(key, out var poolObjects))
            {
                int countToCreate = count - poolObjects.Count;
                if (countToCreate > 0)
                {
                    for (int i = 0; i < countToCreate; i++)
                    {
                        CreateNewObject<T>(key, poolObjects);
                    }
                }

                var freeObject = GetFreeObjectFromPool<T>(poolObjects);

                return freeObject;
            }

            return null;
        }

        public List<IPoolObject> GetPool()
        {
            var allObject = new List<IPoolObject>();

            foreach (var pool in _poolObjects.Values)
            {
                allObject.AddRange(pool);
            }
            
            return allObject;
        }

        public T Get<T>(PoolData key) where T : class, IPoolObject
        {
            if (_poolObjects.TryGetValue(key, out var poolObjects))
            {
                var freeObject = GetFreeObjectFromPool<T>(poolObjects);
                if (freeObject != null)
                {
                    return freeObject;
                }

                return CreateNewObject<T>(key, poolObjects);
            }

            var poolObjectParent = _diContainer.CreateEmptyGameObject(key.key).transform;
            poolObjectParent.transform.SetParent(_poolParent);
            _poolObjectsParents.Add(key, poolObjectParent.transform);

            var firstObject = _diContainer.InstantiatePrefabForComponent<T>(key.obj, poolObjectParent.transform);
            var objects = new List<IPoolObject>();
            objects.Add(firstObject);

            _poolObjects.Add(key, objects);

            firstObject.SetIsFree(false);

            return firstObject;
        }


        public void ClearPool()
        {
            _poolObjects.Clear();
            _poolObjectsParents.Clear();
        }

        public void ClearPool(PoolData data)
        {
            if (_poolObjects.ContainsKey(data))
            {
                _poolObjects[data].Clear();
                _poolObjectsParents.Remove(data);
            }
        }

        private T CreateNewObject<T>(PoolData key, List<IPoolObject> poolObjects) where T : class, IPoolObject
        {
            var newObject = _diContainer.InstantiatePrefabForComponent<T>(key.obj, _poolObjectsParents[key]);
            poolObjects.Add(newObject);
            newObject.SetIsFree(false);
            return newObject;
        }

        private T GetFreeObjectFromPool<T>(List<IPoolObject> poolObjects) where T : class, IPoolObject
        {
            foreach (var poolObject in poolObjects)
            {
                if (poolObject.IsFree)
                {
                    poolObject.SetIsFree(false);
                    return (T)poolObject;
                }
            }

            return null;
        }
    }
}