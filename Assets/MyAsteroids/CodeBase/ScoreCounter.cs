using System;
using MyAsteroids.CodeBase.Spawners;

namespace MyAsteroids.CodeBase
{
    public class ScoreCounter : IDisposable
    {
        private int _score;
        
        private EnemiesSpawner _enemiesSpawner;

        public string Score => 
            _score.ToString();

        public ScoreCounter(EnemiesSpawner enemiesSpawner)
        {
            _enemiesSpawner = enemiesSpawner;
            _score = 0;

            _enemiesSpawner.EnemieDestroyed += OnEnemieDestroyed;
        }

        private void OnEnemieDestroyed()
        {
            _score++;
        }

        public void Dispose()
        {
            _enemiesSpawner.EnemieDestroyed -= OnEnemieDestroyed;
        }
    }
}