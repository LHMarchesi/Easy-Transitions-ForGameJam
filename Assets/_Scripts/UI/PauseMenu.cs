using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public static PauseMenu Instance { get; private set; }

    [SerializeField] private RawImage pauseImage;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    private void Start()
    {
        pauseImage = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<RawImage>();
        ShowPause(false);
    }

    public void ShowPause(bool  pause)
    {
        pauseImage.gameObject.SetActive(pause);
    }
}
