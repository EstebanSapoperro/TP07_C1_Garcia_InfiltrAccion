using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayExitButton : MonoBehaviour
{
    [SerializeField] private bool playButton = false;
    [SerializeField] private bool mainMenuButton = false;
    [SerializeField] private bool exitButton = false;

    [SerializeField] private Button buttonSelected;

    private void Awake()
    {
        buttonSelected.onClick.AddListener(onClick);
    }


    private void OnDestroy()
    {
        buttonSelected.onClick.RemoveAllListeners();
    }

    private void onClick()
    {
        if (mainMenuButton)
        {
            Time.timeScale = 0.0f;
            SceneManager.LoadScene("MainMenu");
        }

        if (playButton)
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("SampleScene");
        }

        if (exitButton)
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif

        }

    }
}
