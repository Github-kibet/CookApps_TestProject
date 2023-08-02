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
        if (Physics.OverlapSphereNonAlloc(transform.position, FSM.Profile.ChaseRange, FSM.EnemyCollider, GetLayerMasks.Enemy)==0)
        {
            FSM.ChangeState(PlayerStateType.Idle); 
        }
        else if (Physics.OverlapSphereNonAlloc(transform.position, FSM.Profile.AttackCheckRange, FSM.EnemyCollider, GetLayerMasks.Enemy) > 0)
        {
            FSM.ChangeState(PlayerStateType.Attack);
        }
        
    }

    private void FixedUpdate()
    {
        Move2Target();
    }

    private void Move2Target()
    {
        Transform target = FSM.EnemyCollider[0].transform;
        Vector3 targetDir = FSM.EnemyCollider[0].transform.position - transform.position;

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