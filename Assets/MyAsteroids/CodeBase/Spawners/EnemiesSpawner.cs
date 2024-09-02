using Cysharp.Threading.Tasks;
using MyAsteroids.CodeBase.Data.Enemies;
using MyAsteroids.CodeBase.Enemies;
using MyAsteroids.CodeBase.Pool.Enemies;
using MyAsteroids.CodeBase.Ships;
using UnityEngine;
using UnityEngine.Events;

namespace MyAsteroids.CodeBase.Spawners
{
    public class EnemiesSpawner
    {
        private AsteroidPool _asteroidPool;
        private UfoPool _ufoPool;
        private AsteroidSmallPool _asteroidSmallPool;

        private EnemiesSpawnerData _enemiesSpawnerData;
        private Ship _target;

        public event UnityAction EnemieDestroyed;

        public EnemiesSpawner(EnemiesSpawnerData enemiesSpawnerData, AsteroidPool asteroidPool,
            UfoPool ufoPool, AsteroidSmallPool asteroidSmallPool)
        {
            _enemiesSpawnerData = enemiesSpawnerData;
            _asteroidPool = asteroidPool;
            _ufoPool = ufoPool;
            _asteroidSmallPool = asteroidSmallPool;
        }

        public void Start(Ship ship)
        {
            _target = ship;
            SpawnEnemies().Forget();
        }

        private async UniTaskVoid SpawnEnemies()
        {
            while (true)
            {
                float angle = Random.Range(0, Mathf.PI * 2);
                Vector3 position = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * _enemiesSpawnerData.SpawnRadius;

                int random = Random.Range(0, 101);

                if (random > 50)
                {
                    Asteroid asteroid = _asteroidPool.GetFreeObject();
                    asteroid.transform.position = position;
                    asteroid.CalculateDirectionNormalized();
                    asteroid.StartMove();
                    asteroid.Destroyed += OnEnemieDestroyed;
                }
                else
                {
                    Ufo ufo = _ufoPool.GetFreeObject();
                    ufo.transform.position = position;
                    ufo.Init(_target.transform);
                    ufo.StartMove();
                    ufo.Destroyed += OnEnemieDestroyed;
                }

                await UniTask.WaitForSeconds(_enemiesSpawnerData.SpawnTime); 
            }
        }

        private void OnEnemieDestroyed(Enemie enemie, Vector2 position)
        {
            switch (enemie)
            {
                case Asteroid asteroid:
                    CrashAsteroid(asteroid, position);
                    break;
                case Ufo ufo:
                    CrashUfo(ufo);
                    break;
                case AsteroidSmall asteroidSmall:
                    CrachAsteroidSmall(asteroidSmall);
                    break;
            }
            
            EnemieDestroyed?.Invoke();
        }

        private void CrashAsteroid(Asteroid asteroid, Vector2 position)
        {
            for (int i = 0; i < _enemiesSpawnerData.CountAsteroidsSmall; i++)
            {
                AsteroidSmall asteroidSmall = _asteroidSmallPool.GetFreeObject();
                asteroidSmall.transform.position = position;
                asteroidSmall.CalculateDirectionNormalized();
                asteroidSmall.StartMove();
                asteroidSmall.Destroyed += OnEnemieDestroyed;
            }
            
            asteroid.Destroyed -= OnEnemieDestroyed;
            _asteroidPool.Release(asteroid);
        }

        private void CrashUfo(Ufo ufo)
        {
            ufo.Destroyed -= OnEnemieDestroyed;
            _ufoPool.Release(ufo);
        }

        private void CrachAsteroidSmall(AsteroidSmall asteroidSmall)
        {
            asteroidSmall.Destroyed -= OnEnemieDestroyed;
            _asteroidSmallPool.Release(asteroidSmall);
        }
    }
}