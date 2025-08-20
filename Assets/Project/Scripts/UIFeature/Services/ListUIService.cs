using Assets.Project.Scripts.Core.Data;
using Assets.Project.Scripts.Core.Interfaces;
using Assets.Project.Scripts.UIFeature.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Project.Scripts.UIFeature.Services
{
    public class ListUIService : IListUIService
    {
        private const int PageMaxItems = 5;
        private List<OrganizationData> _organizationListData = new List<OrganizationData>();

        [Inject] private IImageManager _imageManager;
        [Inject] private SaveOrganizationData _organizationData;

        public int ItemsAmount { get => _organizationListData.Count; }
        public int CurrentPage { get; private set; } = 1;
        public int PageItemAmount { get { return CurrentPage != GetPageAmount() ? PageMaxItems : ItemsAmount % PageMaxItems; } }

        public async Task<Sprite> GetLogoImage(string imageName)
        {
            return await _imageManager.LoadImageFromProject(imageName);
        }

        public List<OrganizationData> GetOrganizationList()
        {
            _organizationListData = _organizationData.LoadOrganizationListData();

            return _organizationListData;
        }

        public int GetPageAmount()
        {
            if (_organizationListData == null || _organizationListData.Count == 0)
                GetOrganizationList();

            int pageAmount = _organizationListData.Count / PageMaxItems;

            return (_organizationListData.Count % PageMaxItems == 0) ? pageAmount : pageAmount + 1;
        }

        public void NextPage()
        {
            CurrentPage = Mathf.Min(CurrentPage + 1, GetPageAmount());
        }

        public void PrevPage()
        {
            CurrentPage = Mathf.Max(CurrentPage - 1, 1);
        }

        public (int from, int to) GetPageRange()
        {
            int from = (CurrentPage - 1) * PageMaxItems + 1;
            int to = Mathf.Min((from - 1) + PageMaxItems, _organizationListData.Count);
            return (from, to);
        }

        public void SetStartPage()
        {
            CurrentPage = 1;
        }
    }
}
