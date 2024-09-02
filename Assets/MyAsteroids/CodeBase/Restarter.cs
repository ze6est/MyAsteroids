using System;
using System.Collections.Generic;
using MyAsteroids.CodeBase.Ships;
using MyAsteroids.CodeBase.UI;
using UnityEngine;
using Zenject;

namespace MyAsteroids.CodeBase
{
    public class Restarter : IDisposable
    {
        private DiContainer _container;
        private ShipTriggerObserver _shipTriggerObserver;
        private RestartWindow _restartWindow;

        private List<IRestarter> _restarters;

        public Restarter(DiContainer container, RestartWindow restartWindow)
        {
            _container = container;
            _restartWindow = restartWindow;
            _restartWindow.Restart.AddListener(Restart);
            _restartWindow.Hide();
        }

        public void SetShipTriggerObserver(ShipTriggerObserver shipTriggerObserver)
        {
            _shipTriggerObserver = shipTriggerObserver;
            _shipTriggerObserver.Died += OnDied;
        }
        
        public void Dispose()
        {
            _restartWindow.Restart.RemoveListener(Restart);
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
        }
    }
}