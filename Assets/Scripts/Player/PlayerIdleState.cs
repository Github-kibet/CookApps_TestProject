using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Animation;
using Util.Layer;



public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState()
    {
        stateType = PlayerStateType.Idle;
    }
    public override void Enter()
    {
        enabled = true;
    }

    public override void UnNotifyEnter()
    {
       
    }

    private void Update()
    {
        if (Physics.OverlapSphereNonAlloc(transform.position, FSM.Profile.ChaseRange, FSM.EnemyCollides, GetLayerMasks.Enemy)>0)
        {
            FSM.ChangeState(PlayerStateType.Move);   
        }
    }

    public override void Exit()
    {
        enabled = false;
    }

    public override void UnNotifyExit()
    {
        
    }
}
