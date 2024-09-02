using System;

namespace MyAsteroids.CodeBase.Data.Enemies
{
    [Serializable]
    public class EnemiesSpawnerData
    {
        public float SpawnRadius = 8f;
        public float SpawnTime = 3f;
        public int CountAsteroidsSmall = 3;
    }
}