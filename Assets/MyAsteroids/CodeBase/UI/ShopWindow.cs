using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyAsteroids.CodeBase.UI
{
    public class ShopWindow : MonoBehaviour, IWindow
    {
        [SerializeField] private TextMeshProUGUI _coins;
        [SerializeField] private Button _removeAdsButton;
        [SerializeField] private Button _shopCloseButton;
        
        public Button.ButtonClickedEvent Close => 
            _shopCloseButton.onClick;

        private void Start()
        {
            UpdateRemoveAdsButton();
            UpdateCoins();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void UpdateRemoveAdsButton()
        {
            bool isRemoveAds = PlayerPrefs.GetInt("RemoveAds1") == 1;
            _removeAdsButton.gameObject.SetActive(!isRemoveAds);
        }

        public void UpdateCoins()
        {
            int coins = PlayerPrefs.GetInt("Coins");
            _coins.text = $"{coins.ToString()} coins";
        }
    }
}