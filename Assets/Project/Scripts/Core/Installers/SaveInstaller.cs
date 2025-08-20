using Assets.Project.Scripts.Core.Data;
using Zenject;

namespace Assets.Project.Scripts.Core.Installers
{
    public class SaveInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSaveOrganizationData();
        }

        private void BindSaveOrganizationData()
        {
            Container.Bind<SaveOrganizationData>().AsSingle();
        }
    }
}