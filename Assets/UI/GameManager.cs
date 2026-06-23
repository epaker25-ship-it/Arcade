using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Animator fadeAnimator;

    void Awake()
    {
        Instance = this;
    }

    public void PlayerDied()
    {
        fadeAnimator.SetTrigger("FadeOut");
        Invoke(nameof(RestartScene), 1f);
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
