using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerProfile", menuName = "PlayerProfile", order = 0)]
    public class PlayerProfile : ScriptableObject
    {
        public float ChaseRange;
        public float MoveSpeed;
    }
}