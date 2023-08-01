using Enemy.Animation;
using UnityEngine;

namespace Enemy
{
    public class EnemyDeadState : EnemyBaseState
    {
        public EnemyDeadState()
        {
            stateType = EnemyStateType.Dead;
        }

        public override void Enter()
        {
            base.Enter();
            FSM.Animator.SetTrigger(GetAnimationParameter.Dead);
        }

        public void OnDeadEndTrigger()
        {
            Debug.Log("Callded Animation DeadEndTrigger!!");
            
            Destroy(gameObject);
        }
    }
}