public class GameStateMachine
{
    public IGameState CurrentState { get => currentState; set => currentState = value; }

    private IGameState currentState;

    public void ChangeState(IGameState newState)
    {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

    public void Update()
    {
        CurrentState?.Update();
    }

    public IGameState GetCurrentState => CurrentState;

}
