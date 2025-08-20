using Assets.Project.Scripts.Core.Pool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.Scripts.UIFeature.Views
{
    public class OrganizationItemView : Poolable
    {
        [SerializeField] private Image _logo;
        [SerializeField] private Image _flag;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _countryName;
        [SerializeField] private Toggle _isAcademy;

        public void SetupItem(Sprite logo, Sprite flag, string name, string countryName, bool isAcademy)
        {
            _logo.sprite = logo;
            _flag.sprite = flag;
            _name.text = name;
            _countryName.text = countryName;
            _isAcademy.isOn = isAcademy;
        }
    }
}