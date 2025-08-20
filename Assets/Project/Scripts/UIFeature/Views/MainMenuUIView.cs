using Assets.Project.Scripts.UIFeature.Presenter;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.Scripts.UIFeature.Views
{
    public class MainMenuUIView : MonoBehaviour
    {
        [SerializeField] private Button _chooseOrgButton;
        [SerializeField] private ListUIView _listWindow;

        private MainMenuUIPresenter _presenter;

        public event Action OnChooseOrgButtonClick;

        private void Awake()
        {
            _presenter = new MainMenuUIPresenter(this);

            _chooseOrgButton.onClick.AddListener(() => OnChooseOrgButtonClick?.Invoke());
        }

        public void EnableListWindow()
        {
            _listWindow.EnableWindow(gameObject);
        }
    }
}