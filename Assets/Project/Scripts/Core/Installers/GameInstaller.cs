using Assets.Project.Scripts.Core.Interfaces;
using Assets.Project.Scripts.Core.Managers;
using Zenject;

namespace Assets.Project.Scripts.Core.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindImageManager();
        }

        private void BindImageManager()
        {
            Container.Bind<IImageManager>().To<ImageManager>().AsSingle();
        }
    }
}