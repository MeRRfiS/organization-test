using Assets.Project.Scripts.Core.Interfaces;
using Assets.Project.Scripts.UIFeature.Interface;
using Assets.Project.Scripts.UIFeature.Models;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Project.Scripts.UIFeature.Services
{
    public class FormUIService: IFormUIService
    {
        [Inject] private IImageManager _imageManager;

        public bool IsCountrySelected(OrganizationFormModel model, int value)
        {
            var result = value != 0;
            model.CountryIsSelected = result;

            return result;
        }

        public bool IsInputFieldValid(OrganizationFormModel model, string inputFieldText)
        {
            var result = !string.IsNullOrEmpty(inputFieldText) && inputFieldText.All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'));

            model.NameIsWrote = result;

            return result;
        }

        public async Task<Sprite> LoadImageAsync(OrganizationFormModel model, string path)
        {
            var sprite = await _imageManager.LoadImage(path);

            if (sprite != null)
            {
                model.LogoIsSelected = true;
            }

            return sprite;
        }
    }
}