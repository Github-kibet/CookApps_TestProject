using UnityEngine;
using Player.Animation;
using Util.Layer;



public class PlayerAttack2State : PlayerBaseState
{
    [SerializeField] private Transform AttackPoint;
    
    public PlayerAttack2State()
    {
        stateType = PlayerStateType.Attack2;
    }
    public override void Enter()
    {
        enabled = true;
        
        SetAnimation();
        FSM.Attack2CoolTime = FSM.Profile.Attack2CoolTime;
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
        FSM.Animator.SetTrigger(GetAnimationParameter.Attack2);
        
        FSM.Animator.speed = FSM.Profile.AttackSpeed;
        
        transform.LookAt(FSM.TargetCollider.transform);
    }

    public void OnAttack2Trigger()
    {
        var hitColliders = Physics.OverlapSphere(transform.position, FSM.Profile.ChaseRange, GetLayerMasks.Enemy);

        if (hitColliders.Length > 0)
        {
            foreach (var target in hitColliders)
            {
                target.GetComponent<EnemyFSM>().OnDamged(FSM.Profile.AttackDamage);
            }
        }
    }

    public void OnAttack2End()
    {
        FSM.ChangeState(PlayerStateType.Idle);
    }
    
    
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (FSM == null)
            FSM = GetComponent<PlayerFSM>();

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(AttackPoint.position, FSM.Profile.Attack2Range);
    }
#endif
}
