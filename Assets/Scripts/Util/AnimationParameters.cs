using UnityEngine;

namespace Player.Animation
{
    public static class GetAnimationParameter
    {
        public static readonly int Move = Animator.StringToHash("Move");
        public static readonly int Attack1 = Animator.StringToHash("Attack1");
        public static readonly int Dead = Animator.StringToHash("Dead");

    }
}

namespace Enemy.Animation
{
    public static class GetAnimationParameter
    {
        public static readonly int Dead = Animator.StringToHash("Dead");
    }
}
