using Enemy;
using UnityEngine;

public class EnemyFSM : BaseFSM<EnemyStateType>
{
    [SerializeField] private EnemyStateType StartStateType;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private CapsuleCollider capsuleCollider;

    public EnemyProfile Profile;
    
    [HideInInspector] public Collider[] PlayerCollider = new Collider[1];

    public Animator Animator { get { return animator; } }
    public Rigidbody Rigidbody { get { return rigidbody; } }
    public CapsuleCollider CapsuleCollider { get { return capsuleCollider; } }
    
    private float Hp;
    private void Awake()
    {
        ApplyState();

        Initialize();
    }
    
    private void Start()
    {
        ChangeState(StartStateType);
    }

    private void OnEnable()
    {
        if (currentState?.StateType==EnemyStateType.Dead)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        Initialize();
        ChangeState(StartStateType);
    }

    private void Initialize()
    {
        if (animator == null)  animator = GetComponent<Animator>();
        if (rigidbody == null) rigidbody = GetComponent<Rigidbody>();
        if (capsuleCollider == null) capsuleCollider = GetComponent<CapsuleCollider>();
        if (Profile == null) Profile = Resources.Load<EnemyProfile>("ScriptableObject/Enemy/EnemyProfile");

        CapsuleCollider.enabled = true;
        Rigidbody.isKinematic = false;
        
        Hp = Profile.HP;
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
