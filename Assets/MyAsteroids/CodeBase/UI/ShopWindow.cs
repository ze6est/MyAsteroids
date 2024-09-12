using UnityEngine;
using UnityEngine.UI;

namespace MyAsteroids.CodeBase.UI
{
    public class ShopWindow : MonoBehaviour, IWindow
    {
        [SerializeField] private Button _shopCloseButton;
        
        public Button.ButtonClickedEvent Close => 
            _shopCloseButton.onClick;
        
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}