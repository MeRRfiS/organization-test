using System;
using System.Collections.Generic;

namespace Assets.Project.Scripts.Core.Data
{
	[Serializable]
	public class OrganizationListData
	{
		public List<OrganizationData> Organizations = new();

		public void Add(OrganizationData organizationData)
		{
			Organizations.Add(organizationData);
		}

		public bool IsEmpty()
		{
            return Organizations.Count == 0;
        }
    }
}
