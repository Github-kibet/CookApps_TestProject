﻿using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerProfile", menuName = "PlayerProfile", order = 0)]
    public class PlayerProfile : ScriptableObject
    {
        public float HP;
        public float EXP;
        public float HpRegenTime;
        public float ChaseRange;
        public float MoveSpeed;
        public float Attack1Range;
        public float Attack2Range;
        public float Attack2CoolTime;
        public float AttackDamage;


        public int AttackSpeed;
    }
}