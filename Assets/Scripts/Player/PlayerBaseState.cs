public class PlayerBaseState:BaseState<PlayerStateType>
{
    public PlayerFSM FSM { get; protected set; }

    public void SetFSM(PlayerFSM fsm)
    {
        FSM = fsm;
    }
    
    private void Awake()
    {
        SetFSM(GetComponent<PlayerFSM>());
    }
    public override void Enter()
    {

    }

    public override void UnNotifyEnter()
    {

    }

    public override void Exit()
    {

    }

    public override void UnNotifyExit()
    {

    }
}