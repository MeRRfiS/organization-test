using System;

namespace Assets.Project.Scripts.UIFeature.Models
{
    public class OrganizationFormModel
    {
        public bool LogoIsSelected { private get; set; }
        public bool NameIsWrote { private get; set; }
        public bool CountryIsSelected { private get; set; }

        public event Action<string> OnLogoIsSelected;
        public event Action<string> OnNameIsWrote;
        public event Action<string> OnCountryIsSelected;

        public bool IsFormValid()
        {
            if(!LogoIsSelected)
                OnLogoIsSelected?.Invoke("Logo is empty");
            if (!NameIsWrote)
                OnNameIsWrote?.Invoke("Name is empty or invalid");
            if (!CountryIsSelected)
                OnCountryIsSelected?.Invoke("Country not select");

            return LogoIsSelected && NameIsWrote && CountryIsSelected;
        }
    }
}