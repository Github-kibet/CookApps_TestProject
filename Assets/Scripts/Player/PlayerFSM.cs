using Player;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerFSM : BaseFSM<PlayerStateType>
{
    [SerializeField] private PlayerStateType StartStateType;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rigidbody;

    public PlayerProfile Profile;
    
    
    [HideInInspector] public Collider[] EnemyCollider = new Collider[1];
    public Animator Animator { get { return animator; } }
    public Rigidbody Rigidbody { get { return rigidbody; } }
    
    private void Awake()
    {
        ApplyState();
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
      
        
    }
    protected override void UpdateExcute()
    {
        
    }
}
