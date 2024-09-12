using UnityEngine;
using UnityEngine.UI;

namespace MyAsteroids.CodeBase.UI
{
    public class ShopOpenButton : MonoBehaviour
    {
        [SerializeField] private Button _shopOpenButton;
        [SerializeField] private ShopWindow _shopWindow;

        private void Awake() => 
            _shopOpenButton.onClick.AddListener(ShowShop);

        private void OnDestroy() => 
            _shopOpenButton.onClick.RemoveListener(ShowShop);

        private void ShowShop()
        {
            _shopWindow.Show();
            Time.timeScale = 0;
        }
    }
}