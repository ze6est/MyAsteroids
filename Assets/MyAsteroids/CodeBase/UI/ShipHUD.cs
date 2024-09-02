using System.Collections;
using MyAsteroids.CodeBase.Gun;
using MyAsteroids.CodeBase.Ships;
using TMPro;
using UnityEngine;

namespace MyAsteroids.CodeBase.UI
{
    public class ShipHUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coordinates;
        [SerializeField] private TextMeshProUGUI _angleRotation;
        [SerializeField] private TextMeshProUGUI _speed;
        [SerializeField] private TextMeshProUGUI _laserCharges;
        [SerializeField] private TextMeshProUGUI _laserFailureTime;

        private ShipMover _shipMover;
        private LaserGun _laserGun;
        private Transform _ship;
        
        public void Construct(Ship ship)
        {
            _shipMover = ship.ShipMover;
            _laserGun = ship.LaserGun;
            
            _ship = _shipMover.transform;
            _laserGun.LaserChargesChanged += OnLaserChargesChanged;
            _laserGun.LaserFailureTimeChanged += OnLaserFailureTimeChanged;

            StartCoroutine(UpdateInfo());
        }
        
        private IEnumerator UpdateInfo()
        {
            while (true)
            {
                Vector2 coordinates = _ship.position;
            
                _coordinates.text = $"Coordinates: {coordinates}";
                _angleRotation.text = $"Angle rotation: {(int)_ship.localEulerAngles.z}";
            
                string formattedVelocity = $"{_shipMover.Velocity:F2}";
                _speed.text = $"Speed: {formattedVelocity}";

                yield return null;
            }
        }
        
        private void OnDestroy()
        {
            _laserGun.LaserChargesChanged -= OnLaserChargesChanged;
            _laserGun.LaserFailureTimeChanged -= OnLaserFailureTimeChanged;
        }
        
        private void OnLaserChargesChanged(int currentLaserCharges) => 
            _laserCharges.text = $"Laser charges : {currentLaserCharges}";
        
        private void OnLaserFailureTimeChanged(float currentLaserFailureTime) => 
            _laserFailureTime.text = $"Laser failure time: {currentLaserFailureTime:F2}";
    }
}
