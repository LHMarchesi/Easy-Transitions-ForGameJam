/// <summary>
/// Manages the current game state using the State pattern.
/// Allows for changing, updating, and retrieving the current state.
/// </summary>
public class GameStateMachine
{
    // Public property to access or assign the current state
    public IGameState CurrentState { get => currentState; set => currentState = value; }

    private IGameState currentState;

    public void ChangeState(IGameState newState)
    {
        CurrentState?.Exit();      // Exit current state if one exists
        CurrentState = newState;   // Set the new state
        CurrentState.Enter();      // Enter the new state
    }

    public void Update()
    {
        CurrentState?.Update();
    }
}
