using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Animation;
using Unity.VisualScripting;
using Util.Layer;


public class EnemyAttackState : EnemyBaseState
{
   
    public EnemyAttackState()
    {
        stateType = EnemyStateType.Attack;
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
        FSM.Animator.SetTrigger(GetAnimationParameter.Attack);
        
        FSM.Animator.speed = FSM.Profile.AttackSpeed;
        
        transform.LookAt(FSM.PlayerCollider[0].transform);
    }

    public void OnAttackTrigger()
    {
        if (FSM.PlayerCollider.Length>0)
        {
           FSM.PlayerCollider[0].GetComponent<PlayerFSM>().OnDamged(FSM.Profile.AttackDamage);
        }
    }

    public void OnAttackEnd()
    {
        if (FSM.currentState.StateType!=EnemyStateType.Dead)
        {
            if (Physics.OverlapSphereNonAlloc(transform.position, FSM.Profile.AttackCheckRange, FSM.PlayerCollider,
                    GetLayerMasks.Player) <= 0)
                FSM.ChangeState(EnemyStateType.Move);
            else
                FSM.ChangeState(EnemyStateType.Attack);
        }
    }
}
