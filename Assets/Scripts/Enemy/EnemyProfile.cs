using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyProfile", menuName = "EnemyProfile", order = 0)]
    public class EnemyProfile : ScriptableObject
    {
        public float HP;
        public float ChaseRange;
        public float AttackRange;
        public float MoveSpeed;

    }
}