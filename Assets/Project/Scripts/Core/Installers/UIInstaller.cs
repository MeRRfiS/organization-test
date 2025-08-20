using Assets.Project.Scripts.UIFeature.Config;
using Assets.Project.Scripts.UIFeature.Configs;
using Assets.Project.Scripts.UIFeature.Factories;
using Assets.Project.Scripts.UIFeature.Interface;
using Assets.Project.Scripts.UIFeature.Services;
using Assets.Project.Scripts.UIFeature.Views;
using UnityEngine;
using Zenject;

namespace Assets.Project.Scripts.Core.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private CountryConfig _countryConfig;
        [SerializeField] private OrganizationItemView _organizationItemPrefab;

        public override void InstallBindings()
        {
            BindCountryConfigurator();
            BindOrganizationItemFactory();
            BindFormUIService();
            BindListUIService();
        }

        private void BindFormUIService()
        {
            Container.Bind<IFormUIService>().To<FormUIService>().AsSingle();
        }

        private void BindListUIService()
        {
            Container.Bind<IListUIService>().To<ListUIService>().AsSingle();
        }

        private void BindCountryConfigurator()
        {
            Container.Bind<CountryConfigurator>().AsSingle().WithArguments(_countryConfig);
        }

        private void BindOrganizationItemFactory()
        {
            Container.Bind<IOrganizationItemFactory>()
                .To<OrganizationItemFactory>()
                .AsSingle()
                .WithArguments(_organizationItemPrefab);
        }
    }
}