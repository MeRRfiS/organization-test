using Assets.Project.Scripts.UIFeature.Interface;
using Assets.Project.Scripts.UIFeature.Models;
using Assets.Project.Scripts.UIFeature.Presenter;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Project.Scripts.UIFeature.Handlers
{
    public class FormUIView : MonoBehaviour
    {
        [SerializeField] private Button _submitButton;
        [SerializeField] private GameObject _listWindow;

        [Header("Form's Elements")]
        [SerializeField] private TMP_InputField _organizationNameInput;
        [SerializeField] private TMP_Dropdown _countryDropdown;
        [SerializeField] private TMP_Text _nameMessageText;
        [SerializeField] private TMP_Text _countryMessageText;

        [Header("Logo's Elements")]
        [SerializeField] private Button _loadLogoButton;
        [SerializeField] private Image _logoImage;
        [SerializeField] private GameObject _buttonText;
        [SerializeField] private TMP_Text _logoMessageText;

        private OrganizationFormModel _organizationFormModel;
        private FormUIPresenter _presenter;

        [Inject] private IFormUIService _formUIService;

        public event Action OnSelectLogoButtonClick;
        public event Action OnSubmitButtonClick;
        public event Action<int> OnCountryDropdownValueChanged;
        public event Action<string> OnInputValueChanged;

        private void Awake()
        {
            _organizationFormModel = new();
            _presenter = new FormUIPresenter(this, _organizationFormModel, _formUIService);
        }

        private void OnEnable()
        {
            _submitButton.onClick.AddListener(() => { OnSubmitButtonClick?.Invoke(); });
            _loadLogoButton.onClick.AddListener(() => { OnSelectLogoButtonClick?.Invoke(); });
            _organizationNameInput.onValueChanged.AddListener((value) => { OnInputValueChanged?.Invoke(value); });
            _countryDropdown.onValueChanged.AddListener((value) => { OnCountryDropdownValueChanged?.Invoke(value); });
        }

        private void OnDisable()
        {
            _submitButton.onClick.RemoveAllListeners();
            _loadLogoButton.onClick.RemoveAllListeners();
            _organizationNameInput.onValueChanged.RemoveAllListeners();
            _countryDropdown.onValueChanged.RemoveAllListeners();
        }

        public void SetLogo(Sprite sprite)
        {
            _logoImage.sprite = sprite;
            _logoImage.gameObject.SetActive(true);
            _buttonText.SetActive(false);
        }

        public void SetLogoMessage(string message)
        {
            _logoMessageText.text = message;
            _logoMessageText.gameObject.SetActive(true);
        }

        public void SetNameMessage(string message)
        {
            _nameMessageText.text = message;
            _nameMessageText.gameObject.SetActive(true);
        }

        public void SetCountryMessage(string message)
        {
            _countryMessageText.text = message;
            _countryMessageText.gameObject.SetActive(true);
        }

        public void ToggleLogoMessage(bool status)
        {
            _logoMessageText.gameObject.SetActive(status);
        }

        public void ToggleNameMessage(bool status)
        {
            _nameMessageText.gameObject.SetActive(status);
        }

        public void ToggleCountryMessage(bool status)
        {
            _countryMessageText.gameObject.SetActive(status);
        }

        public void ToggleListWindow()
        {
            _listWindow.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}