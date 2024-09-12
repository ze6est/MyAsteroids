using MyAsteroids.CodeBase.UI;
using UnityEngine;
using UnityEngine.Purchasing;

namespace MyAsteroids.CodeBase.Services.IAP
{
    public class InAppPurchaser : MonoBehaviour
    {
        [SerializeField] private ShopWindow _shopWindow;
        
        public void OnPurchaseCompleted(Product product)
        {
            switch (product.definition.id)
            {
                case "com.RomanKopylov.MyAsteroids.RemoveAds":
                    RemoveAds();
                    break;
                case "com.RomanKopylov.MyAsteroids.100Coins":
                    Add100Coins();
                    break;
            }
        }

        private void RemoveAds()
        {
            PlayerPrefs.SetInt("RemoveAds1", 1);
            _shopWindow.UpdateRemoveAdsButton();
        }

        private void Add100Coins()
        {
            int coins = PlayerPrefs.GetInt("Coins");
            coins += 100;
            PlayerPrefs.SetInt("Coins", coins);
            _shopWindow.UpdateCoins();
        }
    }
}