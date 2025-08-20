using Assets.Project.Scripts.UIFeature.Enum;
using System;
using UnityEngine;

namespace Assets.Project.Scripts.UIFeature.Models
{
    [Serializable]
    public class CountryModel
    {
        public Country Id;
        public Sprite Flag;
        public string Name;
    }
}