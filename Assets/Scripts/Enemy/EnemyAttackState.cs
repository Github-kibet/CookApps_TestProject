using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Animation;
using Unity.VisualScripting;
using Util.Layer;



public class EnemyAttackState : EnemyBaseState
{
    [SerializeField] private Transform AttackPoint;
    
    
    public EnemyAttackState()
    {
        stateType = EnemyStateType.Attack;
    }

    private void OnDrawGizmos()
    {
        if (FSM == null)
            FSM = GetComponent<EnemyFSM>();
        
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
        FSM.Animator.SetTrigger(GetAnimationParameter.Attack);
        
        FSM.Animator.speed = FSM.Profile.AttackSpeed;
        
        transform.LookAt(FSM.PlayerCollider[0].transform);
    }

    public void OnAttack1Trigger()
    {
        if (FSM.PlayerCollider.Length>0)
        {
           FSM.PlayerCollider[0].GetComponent<PlayerFSM>().OnDamged(FSM.Profile.AttackDamage);
        }
    }

    public void OnAttack1End()
    {
        if(Physics.OverlapSphereNonAlloc(transform.position, FSM.Profile.AttackCheckRange, FSM.PlayerCollider, GetLayerMasks.Player) <= 0)
            FSM.ChangeState(EnemyStateType.Move);
        else
            FSM.ChangeState(EnemyStateType.Attack);
    }
}
