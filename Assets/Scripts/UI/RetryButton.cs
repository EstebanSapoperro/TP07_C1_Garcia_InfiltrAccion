using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RetryButton : MonoBehaviour
{
    [SerializeField] private Button buttonSelected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

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
        PlayerGameManager.playerHealth = 100;
        PlayerGameManager.playerAmmo = 10;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Gameplay");
    }
}
