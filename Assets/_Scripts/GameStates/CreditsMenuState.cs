using UnityEngine.SceneManagement;

public class CreditsMenuState : IGameState
{
    public void Enter()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Update() { }

    public void Exit() { }
}
