using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Animation;
using Unity.VisualScripting;
using Util.Layer;



public class PlayerAttack1State : PlayerBaseState
{
    [SerializeField] private Transform AttackPoint;
    
    public PlayerAttack1State()
    {
        stateType = PlayerStateType.Attack1;
    }

    private void OnDrawGizmos()
    {
        if (FSM == null)
            FSM = GetComponent<PlayerFSM>();

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(AttackPoint.position, FSM.Profile.Attack1Range);
    }

    public override void Enter()
    {
        enabled = true;
        
        SetAnimation();
    }

    public override void UnNotifyEnter()
    {
        SetAnimation();
    }

    public override void Exit()
    {
        enabled = false;
    }

    public override void UnNotifyExit()
    {
        
    }
    
    private void SetAnimation()
    {
        FSM.Animator.SetTrigger(GetAnimationParameter.Attack1);
        
        FSM.Animator.speed = FSM.Profile.AttackSpeed;
        
        transform.LookAt(FSM.TargetCollider.transform);
    }

    public void OnAttack1Trigger()
    {
        if (FSM.TargetCollider!=null)
        {
            var target = FSM.TargetCollider;
            
            target.GetComponent<EnemyFSM>().OnDamged(FSM.Profile.AttackDamage);
        }
    }

    public void OnAttack1End()
    {
        FSM.ChangeState(PlayerStateType.Idle);
    }
}
