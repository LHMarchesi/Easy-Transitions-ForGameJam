using UnityEngine.SceneManagement;

public class CreditsState : IGameState
{
    public void Enter()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Update() { }

    public void Exit() { }
}
