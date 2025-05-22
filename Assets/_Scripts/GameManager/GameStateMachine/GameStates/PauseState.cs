using UnityEngine;

public class PauseState : IGameState
{
    public void Enter()
    {
        Time.timeScale = 0f;
        PauseMenu.Instance.ShowPause(true);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.ChangeState(new GameplayState());
        }
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        PauseMenu.Instance.ShowPause(false);
    }
}
