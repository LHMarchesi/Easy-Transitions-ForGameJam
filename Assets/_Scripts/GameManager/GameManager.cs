using UnityEngine;

/// <summary>
/// Singleton GameManager that handles game state transitions using a state machine.
/// </summary>
/// 
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // The game state machine managing different IGameState instances
    private GameStateMachine stateMachine;

    private void Awake()
    {
        // Ensure there's only one instance of GameManager (Singleton pattern)
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Initialize the state machine and set the initial state
        stateMachine = new GameStateMachine();
        stateMachine.ChangeState(new GameplayState());
    }

    private void Update()
    {
        stateMachine?.Update();
    }

    public void ChangeState(IGameState newState)    // Public method to change the current game state.
    {
        stateMachine.ChangeState(newState);
        Debug.Log(stateMachine.CurrentState);
    }
}
