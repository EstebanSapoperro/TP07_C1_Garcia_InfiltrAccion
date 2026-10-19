using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    private void Start()
    {
        Time.timeScale = 1.0f;
        PlayerHealth.OnDeathHealth += DeathScreen;
    }

    private void OnDestroy()
    {
        PlayerHealth.OnDeathHealth -= DeathScreen;
    }

    private void Update()
    {
        
    }

    private void DeathScreen() 
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
}
