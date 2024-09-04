using System.Collections;
using MyAsteroids.CodeBase.Ammunitions;
using MyAsteroids.CodeBase.Data;
using MyAsteroids.CodeBase.Data.Ammunitions;
using MyAsteroids.CodeBase.Spawners.Ammunitions;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace MyAsteroids.CodeBase.Gun
{
    public class LaserGun : MonoBehaviour, IRestarter
    {
        [SerializeField] private Laser _prefab;
        [SerializeField] private int _maxLaserCharges = 10;
        [SerializeField] private float _laserFailureTime = 10;
        
        private bool _isRecharged;
        private int _currentLaserCharges;
        private float _currentLaserFailureTime;
        private Transform _transform;
        
        private LaserSpawner _laserSpawner;

        private Coroutine _rechargeJob;
        
        public event UnityAction<int> LaserChargesChanged;
        public event UnityAction<float> LaserFailureTimeChanged;

        [Inject]
        public void Construct(GameData data, IInstantiator instantiator)
        {
            _transform = transform;
            _laserSpawner = new LaserSpawner(_prefab, _transform, data.LaserPoolData, instantiator);
        }
        
        private void Start()
        {
            _isRecharged = true;
            _currentLaserCharges = _maxLaserCharges;
            _currentLaserFailureTime = 0;
            
            LaserChargesChanged?.Invoke(_currentLaserCharges);
            LaserFailureTimeChanged?.Invoke(_currentLaserFailureTime);
        }
        
        public void Shoot()
        {
            if (_isRecharged)
            {
                _laserSpawner.Spawn(_transform.position, _transform.rotation);
                _currentLaserCharges--;
                LaserChargesChanged?.Invoke(_currentLaserCharges);
            }
            
            if (_currentLaserCharges <= 0 && _isRecharged)
            {
                _rechargeJob = StartCoroutine(Recharge());
                _isRecharged = false;
            }
        }
        
        public void Restart()
        {
            _laserSpawner.Restart();
            
            if(_rechargeJob != null)
                StopCoroutine(_rechargeJob);
            
            _currentLaserCharges = _maxLaserCharges;
            _currentLaserFailureTime = 0;
            _isRecharged = true;
            
            LaserChargesChanged?.Invoke(_currentLaserCharges);
            LaserFailureTimeChanged?.Invoke(_currentLaserFailureTime);
        }
        
        private IEnumerator Recharge()
        {
            _currentLaserFailureTime = _laserFailureTime;
            
            while (_currentLaserFailureTime > 0)
            {
                _currentLaserFailureTime -= Time.deltaTime;
                LaserFailureTimeChanged?.Invoke(_currentLaserFailureTime);
                yield return null;
            }

            _currentLaserCharges = _maxLaserCharges;
            _currentLaserFailureTime = 0;
            _isRecharged = true;
            
            LaserChargesChanged?.Invoke(_currentLaserCharges);
        }
    }
}