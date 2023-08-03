using System;
using Player;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class PlayerFSM : BaseFSM<PlayerStateType>
{
    [SerializeField] private PlayerStateType StartStateType;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private HpBarUI hpBarUI;
    [SerializeField] private CoolTimeUI attack2CoolTimeUI;
    [SerializeField] private CoolTimeUI hpRegenCoolTimeUI;

    public PlayerProfile Profile;
    
    
    [HideInInspector] public Collider TargetCollider = new Collider();
    public Animator Animator { get { return animator; } }
    public Rigidbody Rigidbody { get { return rigidbody; } }

    private float attack2CoolTime;
    public float Attack2CoolTime
    {
        get
        {
            return attack2CoolTime;
        }
        set
        {
            attack2CoolTimeUI.SetCoolTime(value);
            attack2CoolTime = Time.time+value;
        }
    }
    
    private float hpRegenCoolTime;
    public float HpRegenCoolTime
    {
        get
        {
            return hpRegenCoolTime;
        }
        set
        {
            hpRegenCoolTimeUI.SetCoolTime(value);
            hpRegenCoolTime = Time.time+value;
        }
    }
    
    private float hp;


    
    private float Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            hp = Mathf.Min(hp, Profile.HP);
            hp = Mathf.Max(hp, 0f);
            
            hpBarUI.SetHp(Hp/Profile.HP);
        }
    }
    
    private void Awake()
    {
        ApplyState();
        Initialize();
    }

    private void Start()
    {
        ChangeState(StartStateType);
    }

    private void Initialize()
    {
        if (animator == null) animator = GetComponent<Animator>();
        if (rigidbody == null) rigidbody = GetComponent<Rigidbody>();
        if (Profile == null) Profile = Resources.Load<PlayerProfile>("ScriptableObject/Player/PlayerProfile");
        if (hpBarUI == null) hpBarUI = FindObjectOfType<HpBarUI>();
  
      
        hp = Profile.HP;
        Attack2CoolTime = Time.time;
        HpRegenCoolTime = Time.time;
    }

    public void OnDamged(float damage)
    {
        if (Hp <= 0)
        {
         
        }
        else
        {
            Hp -= damage;
        }
    }

    private void FixedUpdate()
    {
        UpdateExcute();
    }

    protected override void UpdateExcute()
    {
        HpGeneration();
    }

    private void HpGeneration()
    {
        if (HpRegenCoolTime < Time.time&&Hp<Profile.HP)
        {
            Hp += Profile.AttackDamage;
            HpRegenCoolTime = Profile.HpRegenTime;
        }
    }
}
