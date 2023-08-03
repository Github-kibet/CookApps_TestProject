using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Animation;
using Util.Layer;



public class PlayerIdleState : PlayerBaseState
{
    private float minRange;
    private Collider Target;
    public PlayerIdleState()
    {
        stateType = PlayerStateType.Idle;
    }
    public override void Enter()
    {
        enabled = true;
        minRange = float.MaxValue;
    }

    public override void UnNotifyEnter()
    {
       
    }

    private void Update()
    {
        CheckChaseTarget();
    }

    private void CheckChaseTarget()
    {
        var hitColliders = Physics.OverlapSphere(transform.position, FSM.Profile.ChaseRange, GetLayerMasks.Enemy);

        if (hitColliders.Length > 0)
        {
            foreach (var target in hitColliders)
            {
                float distance = Vector3.Distance(transform.position, target.transform.position);

                if (minRange > distance)
                {
                    minRange = distance;
                    Target = target;
                }
            }

            FSM.TargetCollider = Target;
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
