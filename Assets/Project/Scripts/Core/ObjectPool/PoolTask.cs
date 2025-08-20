using System.Collections.Generic;
using UnityEngine;
using Zenject;
using IPoolable = Assets.Project.Scripts.Core.Interfaces.IPoolable;

namespace Assets.Project.Scripts.Core.Pool
{
    public class PoolTask
    {
        private readonly DiContainer _container;
        private readonly Transform _parent;
        private readonly List<IPoolable> _freeObjects;
        private readonly List<IPoolable> _objectsInUse;

        public PoolTask(Transform parent, DiContainer container)
        {
            _parent = parent;
            _container = container;
            _freeObjects = new List<IPoolable>();
            _objectsInUse = new List<IPoolable>();
        }

        public T GetFreeObejct<T>(T prefab) where T : Component, IPoolable
        {
            T poolable;
            if (_freeObjects.Count > 0)
            {
                poolable = _freeObjects[0] as T;
                _freeObjects.RemoveAt(0);
            }
            else
            {
                var obj = _container.InstantiatePrefab(prefab, _parent);
                poolable = obj.GetComponent<T>();
            }

            poolable.Destroyed += ReturnToPool;
            poolable.GameObject.SetActive(true);
            _objectsInUse.Add(poolable);

            return poolable;
        }

        private void ReturnToPool(IPoolable poolable)
        {
            _objectsInUse.Remove(poolable);
            _freeObjects.Add(poolable);
            poolable.Destroyed -= ReturnToPool;
            poolable.GameObject.SetActive(false);
        }
    }
}
