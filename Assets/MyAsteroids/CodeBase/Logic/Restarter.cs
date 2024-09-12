using System;
using System.Collections.Generic;
using MyAsteroids.CodeBase.Services.Ads;
using MyAsteroids.CodeBase.Ships;
using MyAsteroids.CodeBase.UI;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Logic
{
    public class Restarter : IInitializable, IDisposable
    {
        private readonly DiContainer _container;
        private readonly RestartWindow _restartWindow;
        private readonly Ship _ship;
        private readonly InterstitialAds _interstitialAds;
        
        private ShipTriggerObserver _shipTriggerObserver;

        private List<IRestarter> _restarters;

        public Restarter(DiContainer container, RestartWindow restartWindow, Ship ship, InterstitialAds interstitialAds)
        {
            _container = container;
            _restartWindow = restartWindow;
            _ship = ship;
            _interstitialAds = interstitialAds;
        }
        
        public void Initialize()
        {
            _shipTriggerObserver = _ship.TriggerObserver;
            _shipTriggerObserver.Died += OnDied;
            
            _restartWindow.Restart.AddListener(Restart);
            _restartWindow.Hide();
        }

        public void Dispose()
        {
            _restartWindow.Restart.RemoveListener(Restart);

            if (_shipTriggerObserver != null)
                _shipTriggerObserver.Died -= OnDied;
        }
        
        private void Restart()
        {
            Time.timeScale = 1;
            _restartWindow.Hide();
        }

        private void OnDied()
        {
            Time.timeScale = 0;
            _interstitialAds.ShowAd();
            
            _restartWindow.Show();

            _restarters = _container.ResolveAll<IRestarter>();

            foreach (IRestarter restarter in _restarters)
                restarter.Restart();
            
            _ship.Restart();
        }
    }
}