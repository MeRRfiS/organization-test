using Assets.Project.Scripts.UIFeature.Views;
using System;

namespace Assets.Project.Scripts.UIFeature.Presenter
{
    public class MainMenuUIPresenter
    {
        private readonly MainMenuUIView _view;

        public MainMenuUIPresenter(MainMenuUIView view)
        {
            _view = view;
            _view.OnChooseOrgButtonClick += HandleChooseOrgButtonClick;
        }

        private void HandleChooseOrgButtonClick()
        {
            _view.EnableListWindow();
        }
    }
}
