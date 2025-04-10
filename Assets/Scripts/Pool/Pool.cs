using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Pool
{
    public class Pool : IPool
    {
        private readonly DiContainer _diContainer;
        private readonly Dictionary<MonoBehaviour, List<IPoolObject>> _poolObjects = new();
        private readonly Dictionary<MonoBehaviour, Transform> _poolObjectsParents = new();
        private readonly Transform _poolParent;

        public Pool(DiContainer diContainer)
        {
            _diContainer = diContainer;
            _poolParent = _diContainer.CreateEmptyGameObject("Pool").transform;
        }

        public T Get<T>(MonoBehaviour key) where T : class, IPoolObject
        {
            if (_poolObjects.TryGetValue(key, out var poolObjects))
            {
                foreach (var poolObject in poolObjects)
                {
                    if (poolObject.IsFree)
                    {
                        poolObject.SetIsFree(false);

                        return (T)poolObject;
                    }
                }


                var newObject = _diContainer.InstantiatePrefabForComponent<T>(key, _poolObjectsParents[key]);
                poolObjects.Add(newObject);

                newObject.SetIsFree(false);

                return newObject;
            }

            var poolObjectParent = _diContainer.CreateEmptyGameObject(key.transform.name);
            poolObjectParent.transform.SetParent(_poolParent);
            _poolObjectsParents.Add(key, poolObjectParent.transform);

            var firstObject = _diContainer.InstantiatePrefabForComponent<T>(key, poolObjectParent.transform);
            var objects = new List<IPoolObject>();
            objects.Add(firstObject);

            _poolObjects.Add(key, objects);

            firstObject.SetIsFree(false);

            return firstObject;
        }
    }
}