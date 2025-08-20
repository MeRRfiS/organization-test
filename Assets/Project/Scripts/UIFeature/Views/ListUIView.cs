using Assets.Project.Scripts.UIFeature.Configs;
using Assets.Project.Scripts.UIFeature.Interface;
using Assets.Project.Scripts.UIFeature.Presenter;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Project.Scripts.UIFeature.Views
{
    public class ListUIView : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private Transform _contentParent;
        [SerializeField] private GameObject _header;
        [SerializeField] private GameObject _footer;
        [SerializeField] private Button _backButton;

        [Header("Header's elements")]
        [SerializeField] private TMP_Text _itemsText;

        [Header("Footer's elements")]
        [SerializeField] private TMP_Text _pageText;
        [SerializeField] private Button _prevButton;
        [SerializeField] private Button _nextButton;

        private ListUIPresenter _presenter;
        private const int ItemHeight = 146;
        private string _itemsTextFormat;
        private string _pageTextFormat;
        private GameObject _prevWindow;

        [Inject] private IListUIService _listUIService;
        [Inject] private CountryConfigurator _countryConfigurator;
        [Inject] private IOrganizationItemFactory _organizationItemFactory;

        public event Action OnBackButtonClick;
        public event Action OnEnableList;
        public event Action OnPrevClicked;
        public event Action OnNextClicked;
        public event Action<Vector2> OnScrollValueChanged;

        public Transform GetContentParent => _contentParent;

        private void Awake()
        {
            _presenter = new ListUIPresenter(this, _listUIService, _countryConfigurator, _organizationItemFactory);
            _itemsTextFormat = _itemsText.text;
            _pageTextFormat = _pageText.text;
        }

        private void OnEnable()
        {
            _backButton.onClick.AddListener(() => OnBackButtonClick?.Invoke());
            _prevButton.onClick.AddListener(() => OnPrevClicked?.Invoke());
            _nextButton.onClick.AddListener(() => OnNextClicked?.Invoke());
            _scrollRect.onValueChanged.AddListener((value) => { OnScrollValueChanged?.Invoke(value); });

            OnEnableList?.Invoke();
        }

        private void OnDisable()
        {
            _backButton.onClick.RemoveAllListeners();
            _prevButton.onClick.RemoveAllListeners();
            _nextButton.onClick.RemoveAllListeners();
            _scrollRect.onValueChanged.RemoveAllListeners();
        }

        public void ToggleHeader(bool status)
        {
            _header.SetActive(status);
        }

        public void ToggleFooter(bool status)
        {
            _footer.SetActive(status);
        }

        public void SwitchPage(int currentPage, int maxPageItems, int pageItemsAmount)
        {
            var newY = (currentPage * maxPageItems - (maxPageItems - pageItemsAmount)) * (ItemHeight + 5);
            var newPosition = new Vector2(_contentParent.localPosition.x,
                                          newY);
            _contentParent.localPosition = newPosition;
        }

        public void SetPageInfo(int currentPage, int from, int to, int totalItems)
        {
            _itemsText.text = string.Format(_itemsTextFormat, $"{from}-{to}", totalItems);
            _pageText.text = string.Format(_pageTextFormat, currentPage);
        }

        public void SetNavigationInteractable(bool canPrev, bool canNext)
        {
            _prevButton.interactable = canPrev;
            _nextButton.interactable = canNext;
        }

        public void EnableWindow(GameObject prevWindow)
        {
            _prevWindow = prevWindow;
            gameObject.SetActive(true);
        }

        public void BackToPrevWindow()
        {
            _prevWindow.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}