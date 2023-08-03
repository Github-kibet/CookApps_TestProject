using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerProfile", menuName = "PlayerProfile", order = 0)]
    public class PlayerProfile : ScriptableObject
    {
        public float HP;
        public float ChaseRange;
        public float MoveSpeed;
        public float Attack1Range;
        public float Attack2Range;
        public float Attack2CoolTime;
        public float AttackDamage;
        
        [Range(1,100)]
        public int AttackSpeed;
    }
}