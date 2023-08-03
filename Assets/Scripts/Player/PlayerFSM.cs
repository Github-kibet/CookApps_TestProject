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

    public PlayerProfile Profile;
    
    
    [HideInInspector] public Collider TargetCollider = new Collider();
    public Animator Animator { get { return animator; } }
    public Rigidbody Rigidbody { get { return rigidbody; } }

    public float Attack2CoolTime { get; set; }
    
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
    }

    public void OnDamged(float damage)
    {
        if (Hp <= 0)
        {
         
        }
        else
        {
            Hp -= damage;

            if (Hp < 0f)
                Hp = 0f;
        }
    }
    protected override void UpdateExcute()
    {
        
    }
}
