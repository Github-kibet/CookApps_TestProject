using Player;
using UnityEngine;

public class PlayerFSM : BaseFSM<PlayerStateType>
{
    [SerializeField] private PlayerStateType StartStateType;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rigidbody;

    public PlayerProfile Profile;
    
    
    [HideInInspector] public Collider[] EnemyCollides = new Collider[5];
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

    
    protected override void UpdateExcute()
    {
        
    }
}
