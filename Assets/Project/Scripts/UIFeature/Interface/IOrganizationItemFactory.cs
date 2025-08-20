using Assets.Project.Scripts.UIFeature.Views;
using UnityEngine;

namespace Assets.Project.Scripts.UIFeature.Interface
{
    public interface IOrganizationItemFactory
    {
        public OrganizationItemView CreateOrganizationItem(Transform parent);
    }
}
