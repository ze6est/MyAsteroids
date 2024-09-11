using System.Collections;
using UnityEngine;

namespace MyAsteroids.CodeBase.Logic
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _curtain;
        [SerializeField] private float _fadeSpeed = 2f;

        public void Show()
        {
            gameObject.SetActive(true);
            _curtain.alpha = 1f;
        }

        public void Hide() => 
            StartCoroutine(FadeIn());

        private IEnumerator FadeIn()
        {
            while(_curtain.alpha > 0)
            {
                _curtain.alpha -= _fadeSpeed * Time.deltaTime;
                
                yield return null;
            }

            gameObject.SetActive(false);
        }
    }
}