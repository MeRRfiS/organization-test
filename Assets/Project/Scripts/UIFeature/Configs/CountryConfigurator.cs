using Assets.Project.Scripts.UIFeature.Config;
using Assets.Project.Scripts.UIFeature.Enum;
using System.Linq;
using UnityEngine;

namespace Assets.Project.Scripts.UIFeature.Configs
{
    public class CountryConfigurator
    {
        private readonly CountryConfig _config;

        public CountryConfigurator(CountryConfig config)
        {
            _config = config;
        }

        public Sprite GetCoutryFlag(Country id)
        {
            return _config.Models.FirstOrDefault(m => m.Id == id)?.Flag;
        }

        public string GetCoutryName(Country id)
        {
            return _config.Models.FirstOrDefault(m => m.Id == id)?.Name;
        }
    }
}