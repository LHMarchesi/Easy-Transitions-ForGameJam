using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Handles scene transitions with animation and timing.
/// Uses Singleton pattern to ensure global access.
/// </summary>

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    // Duration of the transition animation
    [SerializeField] private float transitionTime = 1.5f;

    // Reference to the Animator controlling the transition animation
    private Animator transitionAnimator;

    private void OnEnable()
    {
        transitionAnimator = GetComponent<Animator>();
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);  // Persist through scene loads
    }

    public void LoadScene(string sceneName)     // Call this to start transitioning to a new scene.
    {
        StartCoroutine(TransitionAndLoad(sceneName));
    }

    private IEnumerator TransitionAndLoad(string sceneName)
    {
        transitionAnimator.SetTrigger("StartTransition");       // Trigger the animation (must have a "StartTransition" trigger in Animator)

        // Wait for the duration of the transition before loading the scene
        yield return new WaitForSeconds(transitionTime);      

        // Load the target scene
        SceneManager.LoadScene(sceneName);
    }
}