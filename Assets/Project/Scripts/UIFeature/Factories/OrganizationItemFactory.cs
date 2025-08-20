using Assets.Project.Scripts.Core.Pool;
using Assets.Project.Scripts.UIFeature.Interface;
using Assets.Project.Scripts.UIFeature.Views;
using UnityEngine;
using Zenject;

namespace Assets.Project.Scripts.UIFeature.Factories
{
    public class OrganizationItemFactory: IOrganizationItemFactory
    {
        private readonly OrganizationItemView _prefab;

        [Inject] private ObjectPool _objectPool;

        public OrganizationItemFactory(OrganizationItemView prefab)
        {
            _prefab = prefab;
        }

        public OrganizationItemView CreateOrganizationItem(Transform parent)
        {
            _objectPool.Parent = parent;
            var organizationItem = _objectPool.GetObject<OrganizationItemView>(_prefab);

            return organizationItem;
        }
    }
}
