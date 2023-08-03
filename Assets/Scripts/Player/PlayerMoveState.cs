using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Animation;
using Util.Layer;


public class PlayerMoveState : PlayerBaseState
{
    
    public PlayerMoveState()
    {
        stateType = PlayerStateType.Move;
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
      
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, FSM.TargetCollider.transform.position);
        if (FSM.TargetCollider!=null)
        {
            if (distance > FSM.Profile.ChaseRange)
                FSM.ChangeState(PlayerStateType.Idle);
            else if(FSM.Attack2CoolTime<Time.time)
            {
                if (distance < FSM.Profile.Attack2Range)
                    FSM.ChangeState(PlayerStateType.Attack2);
            }
            else if (distance < FSM.Profile.Attack1Range)
                FSM.ChangeState(PlayerStateType.Attack1);
        }
        else
        {
            FSM.ChangeState(PlayerStateType.Idle);
        }
        
        Move2Target();
    }

    private void Move2Target()
    {
        Transform target = FSM.TargetCollider.transform;
        Vector3 targetDir = target.position - transform.position;

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