using UnityEngine;
using UnityEngine.UI;
public enum ButtonAction
{
    ChangeState,
    QuitGame,
    Resume,
}

public class FlexibleUIButton : MonoBehaviour
{
    [SerializeField] private ButtonAction actionType;
    [SerializeField] private string parameter; // Puede ser nombre de escena, nombre de panel, etc.

    private Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PerformAction);
    }

    private void PerformAction()
    {
        switch (actionType)
        {
            case ButtonAction.ChangeState:
                switch (parameter)
                {
                    case "MainMenu":
                        GameManager.Instance.ChangeState(new MainMenuState());
                        break;
                    case "Gameplay":
                        GameManager.Instance.ChangeState(new GameplayState());
                        break;
                    case "Credits":
                        GameManager.Instance.ChangeState(new CreditsState());
                        break;
                }
                break;

            case ButtonAction.QuitGame:
                Application.Quit();
                Debug.Log("Game Quit");
                break;

            case ButtonAction.Resume:
                Time.timeScale = 1;
                GameManager.Instance.ChangeState(new GameplayState());
                break;
        }
    }
}
