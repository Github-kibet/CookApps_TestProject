using UnityEngine;
using Util.Layer;

namespace Enemy
{
    public class EnemyIdleState : EnemyBaseState
    {
        public EnemyIdleState()
        {
            stateType = EnemyStateType.Idle;
        }
        
        private void Update()
        {
            if (Physics.OverlapSphereNonAlloc(transform.position, FSM.Profile.ChaseRange, FSM.PlayerCollider, GetLayerMasks.Player)>0)
            {
                FSM.ChangeState(EnemyStateType.Move);   
            }
        }
        
    }
}