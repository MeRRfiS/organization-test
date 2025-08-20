using Assets.Project.Scripts.UIFeature.Configs;
using Assets.Project.Scripts.UIFeature.Enum;
using Assets.Project.Scripts.UIFeature.Interface;
using Assets.Project.Scripts.UIFeature.Views;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project.Scripts.UIFeature.Presenter
{
    public class ListUIPresenter
    {
        private readonly ListUIView _view;
        private readonly IListUIService _service;
        private readonly CountryConfigurator _configurator;
        private readonly IOrganizationItemFactory _factory;
        private List<OrganizationItemView> _organizationItems = new List<OrganizationItemView>();

        public ListUIPresenter(ListUIView view, IListUIService service, CountryConfigurator configurator, IOrganizationItemFactory factory)
        {
            _view = view;
            _service = service;
            _configurator = configurator;
            _factory = factory;

            _view.OnBackButtonClick += ReturnToPrevWindow;
            _view.OnEnableList += CreateOrganizationItems;
            _view.OnPrevClicked += HandlePrevPage;
            _view.OnNextClicked += HandleNextPage;
            _view.OnScrollValueChanged += SwitchPage;
        }

        private async void CreateOrganizationItems()
        {
            var organizationList = _service.GetOrganizationList();
            foreach (var organization in organizationList)
            {
                var item = _factory.CreateOrganizationItem(_view.GetContentParent);
                _organizationItems.Add(item);
                var flag = _configurator.GetCoutryFlag((Country)organization.CountryId);
                var countryName = _configurator.GetCoutryName((Country)organization.CountryId);
                var logo = await _service.GetLogoImage(organization.LogoImageName);
                item.SetupItem(logo, flag, organization.OrganizationName, countryName, organization.IsAcademy);
            }

            UpdateView();
        }

        private void HandleNextPage()
        {
            _service.NextPage();
            _view.SwitchPage(_service.CurrentPage - 1, 5, _service.PageItemAmount);
            UpdateView();
        }

        private void HandlePrevPage()
        {
            _service.PrevPage();
            _view.SwitchPage(_service.CurrentPage - 1, 5, _service.PageItemAmount);
            UpdateView();
        }

        private void SwitchPage(Vector2 value)
        {
            if (value.y <= 1 - (1f / _service.ItemsAmount * (_service.CurrentPage * 5)))
                _service.NextPage();
            else if (value.y >= 1 - (1f / _service.ItemsAmount * ((_service.CurrentPage - 1) * 5)))
                _service.PrevPage();

            UpdateView();
        }

        private void UpdateView()
        {
            var pageAmount = _service.GetPageAmount();
            if (pageAmount == 1) return;

            _view.ToggleFooter(true);
            _view.ToggleHeader(true);

            var (from, to) = _service.GetPageRange();
            _view.SetPageInfo(_service.CurrentPage, from, to, _service.ItemsAmount);

            _view.SetNavigationInteractable(
                canPrev: _service.CurrentPage > 1,
                canNext: _service.CurrentPage < pageAmount);
        }

        private void ReturnToPrevWindow()
        {
            _view.BackToPrevWindow();
            _service.SetStartPage();
            _view.SwitchPage(_service.CurrentPage - 1, 5, _service.PageItemAmount);
            foreach (var item in _organizationItems)
            {
                item.Reset();
            }
            _organizationItems.Clear();
            UpdateView();
        }
    }
}
