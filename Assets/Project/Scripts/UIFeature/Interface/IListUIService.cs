using Assets.Project.Scripts.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project.Scripts.UIFeature.Interface
{
    public interface IListUIService
    {
        public int CurrentPage { get; }
        public int ItemsAmount { get; }
        public int PageItemAmount { get; }
        public Task<Sprite> GetLogoImage(string imageName);
        public List<OrganizationData> GetOrganizationList();
        public int GetPageAmount();
        public void NextPage();
        public void PrevPage();
        public (int from, int to) GetPageRange();
        public void SetStartPage();
    }
}
