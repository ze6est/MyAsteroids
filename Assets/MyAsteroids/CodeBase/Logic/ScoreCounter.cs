using System;
using MyAsteroids.CodeBase.Spawners;

namespace MyAsteroids.CodeBase.Logic
{
    public class ScoreCounter : IDisposable, IRestarter
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