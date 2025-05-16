using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayState : IGameState
{
    
    public void Enter()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.ChangeState(new PauseState());
        }
    }

    public void Exit() { }
}
