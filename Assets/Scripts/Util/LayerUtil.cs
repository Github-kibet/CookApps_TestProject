using UnityEngine;

namespace Util.Layer
{
    public static class GetLayerMasks
    {
        public static readonly int Player = 1 << GetLayer.Player;
        public static readonly int Ground = 1 << GetLayer.Ground;
        public static readonly int Enemy = 1 << GetLayer.Enemy;
        public static readonly int Wall = 1 << GetLayer.Wall;
        public static readonly int HardWall = 1 << GetLayer.HardWall;
        public static readonly int Object = 1 << GetLayer.Object;
        public static readonly int EnemyShield = 1 << GetLayer.EnemyShield;
        public static readonly int Platform = 1 << GetLayer.Platform;
        public static readonly int NPC = 1 << GetLayer.NPC;
        public static readonly int Boss = 1 << GetLayer.Boss;
    }

    public static class GetLayer
    {
        public static readonly int Player = UnityEngine.LayerMask.NameToLayer("Player");
        public static readonly int Ground = UnityEngine.LayerMask.NameToLayer("Ground");
        public static readonly int Enemy = UnityEngine.LayerMask.NameToLayer("Enemy");
        public static readonly int Wall = UnityEngine.LayerMask.NameToLayer("Wall");
        public static readonly int HardWall = UnityEngine.LayerMask.NameToLayer("HardWall");
        public static readonly int Object = UnityEngine.LayerMask.NameToLayer("Object");
        public static readonly int EnemyShield = UnityEngine.LayerMask.NameToLayer("EnemyShield");
        public static readonly int Dead = UnityEngine.LayerMask.NameToLayer("Dead");
        public static readonly int EnemyWeakPoint = UnityEngine.LayerMask.NameToLayer("EnemyWeakPoint");
        public static readonly int Platform = UnityEngine.LayerMask.NameToLayer("Platform");
        public static readonly int NPC = UnityEngine.LayerMask.NameToLayer("NPC");
        public static readonly int Boss = UnityEngine.LayerMask.NameToLayer("Boss");
        public static readonly int WeakRange = UnityEngine.LayerMask.NameToLayer("WeakRange");
    }
}
