using Assets.Project.Scripts.Core;
using Assets.Project.Scripts.UIFeature.Interface;
using Assets.Project.Scripts.UIFeature.Models;
using Assets.Project.Scripts.UIFeature.Views;

namespace Assets.Project.Scripts.UIFeature.Presenter
{
    public class FormUIPresenter
    {
        private readonly FormUIView _view;
        private readonly OrganizationFormModel _model;
        private readonly IFormUIService _service;

        public FormUIPresenter(FormUIView view, OrganizationFormModel model, IFormUIService service)
        {
            _view = view;
            _model = model;
            _service = service;

            _view.OnSubmitButtonClick += OnSubmitButtonClick;
            _view.OnSelectLogoButtonClick += OnSelectLogo;
            _view.OnInputValueChanged += OnInputValueChanged;
            _view.OnCountryDropdownValueChanged += OnCountryChange;
            _model.OnLogoIsSelected += _view.SetLogoMessage;
            _model.OnNameIsWrote += _view.SetNameMessage;
            _model.OnCountryIsSelected += _view.SetCountryMessage;
        }

        private async void OnSelectLogo()
        {
            var path = FileBrowser.GetPathToImage();
            if (string.IsNullOrEmpty(path)) return;

            var sprite = await _service.LoadImageAsync(_model, path);
            if (sprite == null) return;

            _view.SetLogo(sprite);
            _view.ToggleLogoMessage(false);
        }

        private void OnInputValueChanged(string value)
        {
            var isValid = _service.IsInputFieldValid(_model, value);

            if (!isValid)
            {
                _view.SetNameMessage("Name is invalid");
            }
            else
            {
                _view.ToggleNameMessage(false);
            }
        }

        private void OnCountryChange(int value)
        {
            var isSelected = _service.IsCountrySelected(_model, value);

            if (isSelected)
                _view.ToggleCountryMessage(false);
        }

        private void OnSubmitButtonClick()
        {
            if (!_model.IsFormValid()) return;

            var countryValue = _view.CountryDropdownValue;
            var organizationName = _view.OrganizationName;
            var isAcademy = _view.IsAcademyToggleOn;
            _service.SaveForm(countryValue, organizationName, isAcademy);

            _view.EnableListWindow();
        }
    }
}