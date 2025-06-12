using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Singleton-based PauseMenu controller.
/// Handles showing and hiding the pause menu UI in the scene.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance { get; private set; }

    // Reference to the RawImage UI element representing the pause menu
    private RawImage pauseImage;
    private void Awake()
    {
        // Ensure only one instance of PauseMenu exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    private void Start()
    {
        // Find the RawImage tagged as "PauseMenu" and store its reference
        pauseImage = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<RawImage>();
        // Make sure the pause menu is hidden on start
        ShowPause(false);
    }

    public void ShowPause(bool pause)   // Enables or disables the pause menu UI.
    {
        pauseImage.gameObject.SetActive(pause);
    }
}
