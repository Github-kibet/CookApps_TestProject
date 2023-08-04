using System.Linq;
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
            FSM.PlayerCollider[0].GetComponent<PlayerFSM>().AddExp(FSM.Profile.EXP);
            GetComponent<SpawnCallback>()?.Return();
        }
    }
}