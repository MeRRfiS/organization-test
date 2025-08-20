using Assets.Project.Scripts.Core.Interfaces;
using System;
using UnityEngine;

namespace Assets.Project.Scripts.Core.Pool
{
    public class Poolable : MonoBehaviour, IPoolable
    {
        public GameObject GameObject => gameObject;

        public event Action<IPoolable> Destroyed;

        public virtual void Reset()
        {
            Destroyed?.Invoke(this);
        }
    }
}
