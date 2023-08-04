using UnityEngine;

namespace Util.Layer
{
    public static class GetLayerMasks
    {
        public static readonly int Player = 1 << GetLayer.Player;
        public static readonly int Ground = 1 << GetLayer.Ground;
        public static readonly int Enemy = 1 << GetLayer.Enemy;
    }

    public static class GetLayer
    {
        public static readonly int Player = UnityEngine.LayerMask.NameToLayer("Player");
        public static readonly int Ground = UnityEngine.LayerMask.NameToLayer("Ground");
        public static readonly int Enemy = UnityEngine.LayerMask.NameToLayer("Enemy");
    }
}
