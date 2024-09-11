using System;
using System.Collections.Generic;
using MyAsteroids.CodeBase.Ships;
using MyAsteroids.CodeBase.UI;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase.Logic
{
    public class Restarter : IInitializable, IDisposable
    {
        private DiContainer _container;
        private RestartWindow _restartWindow;
        
        private Ship _ship;
        private ShipTriggerObserver _shipTriggerObserver;

        private List<IRestarter> _restarters;

        public Restarter(DiContainer container, RestartWindow restartWindow, Ship ship)
        {
            _container = container;
            _restartWindow = restartWindow;
            _ship = ship;
        }
        
        public void Initialize()
        {
            _shipTriggerObserver = _ship.ShipTriggerObserver;
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
            _restartWindow.Show();

            _restarters = _container.ResolveAll<IRestarter>();

            foreach (IRestarter restarter in _restarters)
                restarter.Restart();
            
            _ship.Restart();
        }
    }
}