using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Animation;
using Unity.VisualScripting;
using Util.Layer;



public class PlayerAttackState : PlayerBaseState
{
    [SerializeField] private Transform AttackPoint;
    
    
    public PlayerAttackState()
    {
        stateType = PlayerStateType.Attack;
    }

    private void OnDrawGizmos()
    {
        if (FSM == null)
            FSM = GetComponent<PlayerFSM>();
        
        Matrix4x4 rotMatrix = Matrix4x4.TRS(AttackPoint.position, AttackPoint.rotation, AttackPoint.lossyScale);
        Gizmos.matrix = rotMatrix;
            
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one * FSM.Profile.AttackRange);
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
        
        transform.LookAt(FSM.EnemyCollider[0].transform);
    }

    public void OnAttack1Trigger()
    {
        var targets = Physics.OverlapBox(AttackPoint.position, Vector3.one * 0.5f * FSM.Profile.AttackRange, AttackPoint.rotation, GetLayerMasks.Enemy);

        if (targets.Length>0)
        {
            foreach (var target in targets)
            {
                if (target != null)
                {
                    target.GetComponent<EnemyFSM>().OnDamged(FSM.Profile.AttackDamage);
                }
            }
        }
    }

    public void OnAttack1End()
    {
        if(Physics.OverlapSphereNonAlloc(transform.position, FSM.Profile.AttackCheckRange, FSM.EnemyCollider, GetLayerMasks.Enemy) <= 0)
            FSM.ChangeState(PlayerStateType.Move);
        else
            FSM.ChangeState(PlayerStateType.Attack);
    }
}
