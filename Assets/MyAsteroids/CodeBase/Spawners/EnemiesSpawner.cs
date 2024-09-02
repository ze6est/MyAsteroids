using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MyAsteroids.CodeBase.Data.Enemies;
using MyAsteroids.CodeBase.Enemies;
using MyAsteroids.CodeBase.Pool.Enemies;
using MyAsteroids.CodeBase.Ships;
using UnityEngine;
using UnityEngine.Events;

namespace MyAsteroids.CodeBase.Spawners
{
    public class EnemiesSpawner : IRestarter
    {
        private AsteroidPool _asteroidPool;
        private UfoPool _ufoPool;
        private AsteroidSmallPool _asteroidSmallPool;

        private List<Asteroid> _activeAsteroids;
        private List<AsteroidSmall> _activeAsteroidsSmall;
        private List<Ufo> _activeUfos;

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

            _activeAsteroids = new();
            _activeAsteroidsSmall = new ();
            _activeUfos = new();
        }

        public void Start(Ship ship)
        {
            _target = ship;
            SpawnEnemies().Forget();
        }
        
        public void Restart()
        {
            foreach (Asteroid asteroid in _activeAsteroids)
            {
                asteroid.Destroyed -= OnEnemieDestroyed;
                _asteroidPool.Release(asteroid);
            }
            
            foreach (AsteroidSmall asteroidSmall in _activeAsteroidsSmall)
            {
                asteroidSmall.Destroyed -= OnEnemieDestroyed;
                _asteroidSmallPool.Release(asteroidSmall);
            }
            
            foreach (Ufo ufo in _activeUfos)
            {
                ufo.Destroyed -= OnEnemieDestroyed;
                _ufoPool.Release(ufo);
            }
            
            _activeAsteroids.Clear();
            _activeAsteroidsSmall.Clear();
            _activeUfos.Clear();
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
                    _activeAsteroids.Add(asteroid);
                    asteroid.transform.position = position;
                    asteroid.CalculateDirectionNormalized();
                    asteroid.StartMove();
                    asteroid.Destroyed += OnEnemieDestroyed;
                }
                else
                {
                    Ufo ufo = _ufoPool.GetFreeObject();
                    _activeUfos.Add(ufo);
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
                _activeAsteroidsSmall.Add(asteroidSmall);
                asteroidSmall.transform.position = position;
                asteroidSmall.CalculateDirectionNormalized();
                asteroidSmall.StartMove();
                asteroidSmall.Destroyed += OnEnemieDestroyed;
            }

            _activeAsteroids.Remove(asteroid);
            asteroid.Destroyed -= OnEnemieDestroyed;
            _asteroidPool.Release(asteroid);
        }

        private void CrashUfo(Ufo ufo)
        {
            _activeUfos.Remove(ufo);
            ufo.Destroyed -= OnEnemieDestroyed;
            _ufoPool.Release(ufo);
        }

        private void CrachAsteroidSmall(AsteroidSmall asteroidSmall)
        {
            _activeAsteroidsSmall.Remove(asteroidSmall);
            asteroidSmall.Destroyed -= OnEnemieDestroyed;
            _asteroidSmallPool.Release(asteroidSmall);
        }
    }
}