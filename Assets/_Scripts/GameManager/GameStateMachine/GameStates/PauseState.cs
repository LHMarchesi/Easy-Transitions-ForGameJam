using UnityEngine;
/// <summary>
/// Represents the pause state of the game.
/// Freezes time and displays the pause menu. Returns to gameplay on Escape key.
/// </summary>
public class PauseState : IGameState
{
    public void Enter()
    {
        Time.timeScale = 0f;    // Freeze the game
        PauseMenu.Instance.ShowPause(true);  // Show the pause menu UI
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Switch back to gameplay state
            GameManager.Instance.ChangeState(new GameplayState());
        }
    }

    public void Exit()
    {
        Time.timeScale = 1f;    // Resume the game
        PauseMenu.Instance.ShowPause(false);
    }
}
