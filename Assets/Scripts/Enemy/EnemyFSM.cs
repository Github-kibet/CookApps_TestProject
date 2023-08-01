using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using Enemy.Animation;
using UnityEngine;

public class EnemyFSM : BaseFSM<EnemyStateType>
{
    [SerializeField] private EnemyStateType StartStateType;
    [SerializeField] private Animator animator;

    public EnemyProfile Profile;

    public Animator Animator { get { return animator; } }
    
    private float Hp;
    private void Awake()
    {
        ApplyState();
        
        animator = GetComponent<Animator>();

        Hp = Profile.HP;
    }
    
    private void Start()
    {
        ChangeState(StartStateType);
    }

    public void OnDamged(float damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            ChangeState(EnemyStateType.Dead);
        }
    }
    
    protected override void UpdateExcute()
    {
       
    }
}
