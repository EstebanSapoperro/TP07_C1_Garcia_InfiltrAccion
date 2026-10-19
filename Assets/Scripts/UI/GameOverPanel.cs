using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winingPanel;
    private void Start()
    {
        Time.timeScale = 1.0f;
        PlayerHealth.OnDeathHealth += DeathScreen;
        WinCondition.OnWining += WiningScreen;
    }

    private void OnDestroy()
    {
        PlayerHealth.OnDeathHealth -= DeathScreen;
        WinCondition.OnWining -= WiningScreen;
    }

    private void DeathScreen() 
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    private void WiningScreen()
    {
        Time.timeScale = 0;
        winingPanel.SetActive(true);
    }
}
