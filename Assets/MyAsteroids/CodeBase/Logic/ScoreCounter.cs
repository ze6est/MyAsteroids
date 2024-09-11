using System;
using MyAsteroids.CodeBase.Spawners;
using Zenject;

namespace MyAsteroids.CodeBase.Logic
{
    public class ScoreCounter : IInitializable, IDisposable, IRestarter
    {
        private int _score;
        
        private EnemiesSpawner _enemiesSpawner;

        public string Score => 
            _score.ToString();

        public ScoreCounter(EnemiesSpawner enemiesSpawner)
        {
            _enemiesSpawner = enemiesSpawner;
        }
        
        public void Initialize()
        {
            _score = 0;
            _enemiesSpawner.EnemieDestroyed += OnEnemieDestroyed;
        }
        
        public void Dispose()
        {
            _enemiesSpawner.EnemieDestroyed -= OnEnemieDestroyed;
        }
        
        public void Restart()
        {
            _score = 0;
        }

        private void OnEnemieDestroyed()
        {
            _score++;
        }
    }
}