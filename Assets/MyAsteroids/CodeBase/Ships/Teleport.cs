using UnityEngine;

namespace MyAsteroids.CodeBase.Ships
{
    public class Teleport : MonoBehaviour
    {
        private Camera _camera;
        private float _screenWidth;
        private float _screenHeight;
        private Transform _transform;

        private void Awake()
        {
            _camera = Camera.main;
            _screenWidth = Screen.width;
            _screenHeight = Screen.height;
            _transform = transform;
        }

        private void Update()
        {
            Vector3 screenPosition = _camera.WorldToScreenPoint(_transform.position);
        
            if (screenPosition.x > _screenWidth)
                screenPosition.x = 0;
            else if (screenPosition.x < 0)
                screenPosition.x = _screenWidth;

            if (screenPosition.y > _screenHeight)
                screenPosition.y = 0;
            else if (screenPosition.y < 0)
                screenPosition.y = _screenHeight;

            _transform.position = _camera.ScreenToWorldPoint(screenPosition);
        }
    }
}