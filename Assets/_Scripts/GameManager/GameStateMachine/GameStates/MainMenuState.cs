public class MainMenuState : IGameState
{
    public void Enter()
    {
        SceneTransitionManager.Instance.LoadScene("MainMenu");
    }

    public void Update() { }

    public void Exit() { }
}
