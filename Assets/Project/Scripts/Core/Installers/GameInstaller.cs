using Assets.Project.Scripts.Core.Interfaces;
using Assets.Project.Scripts.Core.Managers;
using Assets.Project.Scripts.Core.Pool;
using Assets.Project.Scripts.UIFeature.Config;
using Assets.Project.Scripts.UIFeature.Configs;
using UnityEngine;
using Zenject;

namespace Assets.Project.Scripts.Core.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindObjectPool();
            BindImageManager();
            BindSaveManager();
        }

        private void BindImageManager()
        {
            Container.Bind<IImageManager>().To<ImageManager>().AsSingle();
        }

        private void BindSaveManager()
        {
            Container.Bind<ISaveManager>().To<SaveManager>().AsSingle();
        }

        private void BindObjectPool()
        {
            Container.Bind<ObjectPool>().AsSingle().NonLazy();
        }
    }
}