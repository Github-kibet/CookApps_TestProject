using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerProfile", menuName = "PlayerProfile", order = 0)]
    public class PlayerProfile : ScriptableObject
    {
        public float ChaseRange;
        public float MoveSpeed;
        public float AttackCheckRange;
        public float AttackRange;
        public float AttackDamage;
        
        [Range(1,100)]
        public int AttackSpeed;
    }
}