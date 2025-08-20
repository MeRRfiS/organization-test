using Assets.Project.Scripts.UIFeature.Models;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project.Scripts.UIFeature.Interface
{
    public interface IFormUIService
    {
        public void SaveForm(int countryValue, string name, bool isAcademy);
        public bool IsCountrySelected(OrganizationFormModel model, int value);
        public bool IsInputFieldValid(OrganizationFormModel model, string inputFieldText);
        public Task<Sprite> LoadImageAsync(OrganizationFormModel model, string path);
    }
}