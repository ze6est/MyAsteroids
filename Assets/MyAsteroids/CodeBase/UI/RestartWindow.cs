using MyAsteroids.CodeBase.Logic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MyAsteroids.CodeBase.UI
{
    public class RestartWindow : MonoBehaviour, IWindow
    {
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private Button _restartButton;

        private ScoreCounter _scoreCounter;

        public Button.ButtonClickedEvent Restart => 
            _restartButton.onClick;

        [Inject]
        public void Construct(ScoreCounter scoreCounter) => 
            _scoreCounter = scoreCounter;

        public void Show()
        {
            gameObject.SetActive(true);
            _score.text = $"Score: {_scoreCounter.Score}";
        }

        public void Hide() => 
            gameObject.SetActive(false);
    }
}