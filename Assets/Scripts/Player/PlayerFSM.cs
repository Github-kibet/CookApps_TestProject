using System;
using Cinemachine;
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
    [SerializeField] private ExpBarUI expBarUI;
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
    private float HpRegenCoolTime
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

    private int level;
    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
            expBarUI.SetLevel(level);
        }
    }
    
    
    private float exp;
    private float EXP
    {
        get
        {
            return exp;
        }

        set
        {
            exp = value;
            expBarUI.SetEXP(value/(level*Profile.EXP));
        }
    }

    private void Awake()
    {
        ApplyState();
    }

    private void Start()
    {
        Initialize();
        ChangeState(StartStateType);
    }
    
    private void FixedUpdate()
    {
        UpdateExcute();
    }

    protected override void UpdateExcute()
    {
        HpGeneration();
    }


    private void Initialize()
    {
        if (animator == null) animator = GetComponent<Animator>();
        if (rigidbody == null) rigidbody = GetComponent<Rigidbody>();
        if (Profile == null) Profile = Resources.Load<PlayerProfile>("ScriptableObject/Player/PlayerProfile");
        if (hpBarUI == null) hpBarUI = FindObjectOfType<HpBarUI>();
  
      
        hp = Profile.HP;
        Level = 1;
        EXP = 0f;

        Attack2CoolTime = Time.time;
        HpRegenCoolTime = Time.time;
    }
    private void HpGeneration()
    {
        if (HpRegenCoolTime < Time.time&&Hp<Profile.HP)
        {
            Hp += Profile.AttackDamage;
            HpRegenCoolTime = Profile.HpRegenTime;
        }
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

    public void AddExp(float exp)
    {
        float maxExp = Profile.EXP*level;
        EXP += exp;

        if (EXP >= maxExp)
        {
            EXP -= maxExp;
            ++Level;
        }
    }
}
