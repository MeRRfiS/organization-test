using Assets.Project.Scripts.Core.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project.Scripts.Core.Data
{
    public class SaveOrganizationData
    {
        private const string OrganizationFile = "organizationData.dat";

        private OrganizationListData _organizationListData = new();

        private ISaveManager _saveManager;

        public SaveOrganizationData(ISaveManager saveManager)
        {
            _saveManager = saveManager;
        }

        public void SaveOrganizationListData(OrganizationData organizationData)
        {
            _organizationListData.Add(organizationData);

            _saveManager.SaveToFile(OrganizationFile, _organizationListData);
        }

        public List<OrganizationData> LoadOrganizationListData()
        {
            if(_organizationListData == null || _organizationListData.IsEmpty())
                _saveManager.LoadDataFromFile(OrganizationFile, _organizationListData);

            return _organizationListData.Organizations;
        }
    }
}