using Enemy.Animation;
using UnityEngine;

namespace Enemy
{
    public class EnemyIdleState : EnemyBaseState
    {
        public EnemyIdleState()
        {
            stateType = EnemyStateType.Idle;
        }
        
    }
}