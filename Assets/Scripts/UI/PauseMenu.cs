using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    private bool isPause = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (GameManager.isWiningPanelOn == false) 
            {
                if (isPause)
                {
                    isPause = false;
                    Time.timeScale = 1.0f;
                    pausePanel.SetActive(false);
                }
                else 
                {
                    isPause = true;
                    Time.timeScale = 0.0f;
                    pausePanel.SetActive(true);
                }
            }
        
        }
        
    }
}
