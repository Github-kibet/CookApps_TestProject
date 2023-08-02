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

            FSM.CapsuleCollider.enabled = false;
            FSM.Rigidbody.isKinematic = true;
        }

        public void OnDeadEndTrigger()
        {
            Debug.Log("Callded Animation DeadEndTrigger!!");
            
            GetComponent<SpawnCallback>()?.Return();
        }
    }
}