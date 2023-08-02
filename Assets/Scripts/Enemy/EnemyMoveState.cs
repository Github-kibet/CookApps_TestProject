using Enemy.Animation;
using UnityEngine;
using Util.Layer;

namespace Enemy
{
    public class EnemyMoveState : EnemyBaseState
    {
        public EnemyMoveState()
        {
            stateType = EnemyStateType.Move;
        }
        
        public override void Enter()
        {
            enabled = true;
            FSM.Animator.SetBool(GetAnimationParameter.Move,true);
        }
        public override void UnNotifyEnter()
        {
       
        }
    
        private void Update()
        {
            if (Physics.OverlapSphereNonAlloc(transform.position, FSM.Profile.ChaseRange, FSM.PlayerCollider, GetLayerMasks.Player)==0)
            {
                FSM.ChangeState(EnemyStateType.Idle); 
            }
            else if (Physics.OverlapSphereNonAlloc(transform.position, FSM.Profile.AttackRange, FSM.PlayerCollider, GetLayerMasks.Player) > 0)
            {
                //FSM.ChangeState(EnemyStateType.Attack);
            }
        
        }

        private void FixedUpdate()
        {
            Move2Target();
        }

        private void Move2Target()
        {
            Transform target = FSM.PlayerCollider[0].transform;
            Vector3 targetDir = FSM.PlayerCollider[0].transform.position - transform.position;

            transform.LookAt(target);
            FSM.Rigidbody.velocity = targetDir.normalized * FSM.Profile.MoveSpeed;
        }

        public override void Exit()
        {
            FSM.Animator.SetBool(GetAnimationParameter.Move,false);
            enabled = false;
        }

        public override void UnNotifyExit()
        {
        
        }
    }
}