using UnityEngine;

namespace Manager
{
    [CreateAssetMenu(fileName = "EnemySpawnerProfile", menuName = "EnemySpawnerProfile", order = 0)]
    public class EnemySpawnerProfile : SerializableDictionaryAsset<string,GameObject>
    {
        public int SpawnCount;
        public float SpawnTime;
    }
}