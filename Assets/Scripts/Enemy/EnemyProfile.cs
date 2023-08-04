using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyProfile", menuName = "EnemyProfile", order = 0)]
    public class EnemyProfile : ScriptableObject
    {
        public float HP;
        public float EXP;
        public float ChaseRange;
        public float AttackDamage;
        public float AttackCheckRange;
        public float MoveSpeed;

        public int AttackSpeed;

    }
}