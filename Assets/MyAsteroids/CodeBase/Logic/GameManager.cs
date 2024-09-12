using System;
using System.Collections.Generic;
using MyAsteroids.CodeBase.Services.Ads;
using MyAsteroids.CodeBase.Ships;
using MyAsteroids.CodeBase.UI;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Logic
{
    public class GameManager : IInitializable, IDisposable
    {
        private readonly DiContainer _container;
        private readonly RestartWindow _restartWindow;
        private readonly ShopWindow _shopWindow;
        private readonly Ship _ship;
        private readonly InterstitialAds _interstitialAds;
        
        private ShipTriggerObserver _shipTriggerObserver;

        private List<IRestarter> _restarters;

        public GameManager(DiContainer container, RestartWindow restartWindow, Ship ship, InterstitialAds interstitialAds, ShopWindow shopWindow)
        {
            _container = container;
            _restartWindow = restartWindow;
            _ship = ship;
            _interstitialAds = interstitialAds;
            _shopWindow = shopWindow;
        }
        
        public void Initialize()
        {
            _shipTriggerObserver = _ship.TriggerObserver;
            _shipTriggerObserver.Died += OnDied;
            
            _restartWindow.Restart.AddListener(Restart);
            _restartWindow.Hide();
            _shopWindow.Hide();
            
            _shopWindow.Close.AddListener(CloseShop);
        }

        public void Dispose()
        {
            _restartWindow.Restart.RemoveListener(Restart);
            _shopWindow.Close.RemoveListener(CloseShop);

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

        private void CloseShop()
        {
            _shopWindow.Hide();
            Time.timeScale = 1;
        }
    }
}