using Assets.Project.Scripts.UIFeature.Interface;
using Assets.Project.Scripts.UIFeature.Services;
using Zenject;

namespace Assets.Project.Scripts.Core.Installers
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFormUIService();
        }

        private void BindFormUIService()
        {
            Container.Bind<IFormUIService>().To<FormUIService>().AsSingle();
        }
    }
}