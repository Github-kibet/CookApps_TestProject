
public class EnemyBaseState:BaseState<EnemyStateType>
{
    public EnemyFSM FSM { get; protected set; }

    public void SetFSM(EnemyFSM fsm)
    {
        FSM = fsm;
    }
    
    private void Awake()
    {
        SetFSM(GetComponent<EnemyFSM>());
        enabled = false;
    }
    public override void Enter()
    {
        enabled = true;
    }

    public override void UnNotifyEnter()
    {

    }

    public override void Exit()
    {
        enabled = false;
    }

    public override void UnNotifyExit()
    {

    }
}