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
            
        //TRS행렬에서 회전행렬을 곱하여 회전 변환 해준다.
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

    private void Update()
    {
       
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
    }

    public void OnAttack1Trigger()
    {
        Debug.Log("Callded Animation Attack1Trigger!!");
        var targets = Physics.OverlapBox(AttackPoint.position, Vector3.one * 0.5f * FSM.Profile.AttackRange, AttackPoint.rotation, GetLayerMasks.Enemy);

        if (targets.Length>0)
        {
            foreach (var target in targets)
            {
                target.GetComponent<EnemyFSM>().OnDamged(FSM.Profile.AttackDamage);
            }
        }
    }

    public void OnAttack1End()
    {
        Debug.Log("Callded Animation Attack1End!!");
        
        FSM.ChangeState(PlayerStateType.Attack);
    }
}
