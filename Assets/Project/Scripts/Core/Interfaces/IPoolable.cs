using System;
using UnityEngine;

namespace Assets.Project.Scripts.Core.Interfaces
{
    public interface IPoolable
    {
        public event Action<IPoolable> Destroyed;
        public GameObject GameObject { get; }
        public void Reset();
    }
}