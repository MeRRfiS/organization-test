using System.Collections.Generic;
using UnityEngine;
using Zenject;
using IPoolable = Assets.Project.Scripts.Core.Interfaces.IPoolable;

namespace Assets.Project.Scripts.Core.Pool
{
    public class ObjectPool
    {
        private readonly Dictionary<Component, PoolTask> _activePoolTask;

        public Transform Parent { private get; set; }

        private readonly DiContainer _container;

        [Inject]
        public ObjectPool(DiContainer container)
        {
            _container = container;
            _activePoolTask = new Dictionary<Component, PoolTask>();
        }

        public T GetObject<T>(T prefab) where T : Component, IPoolable
        {
            if (!_activePoolTask.TryGetValue(prefab, out var poolTask))
            {
                AddTaskToPool(prefab, out poolTask);
            }

            return poolTask.GetFreeObejct(prefab);
        }

        private void AddTaskToPool<T>(T prefab, out PoolTask poolTask) where T : Component, IPoolable
        {
            poolTask = new PoolTask(Parent, _container);
            _activePoolTask.Add(prefab, poolTask);
        }
    }
}
