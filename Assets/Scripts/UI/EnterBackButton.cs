using UnityEngine;
using UnityEngine.UI;

public class EnterBackButton : MonoBehaviour
{
    [SerializeField] private bool IsResumeButton = false;
    [SerializeField] private GameObject enterPanel;
    [SerializeField] private GameObject exitPanel;
    [SerializeField] private GameObject timePanel;

    [SerializeField] private Button exitbutton;
    private void Awake()
    {
        exitbutton.onClick.AddListener(onClick);
    }

    private void OnDestroy()
    {
        exitbutton.onClick.RemoveAllListeners();
    }

    private void onClick()
    {

        if (IsResumeButton == true)
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;

            }
            else if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }

            if (timePanel != null)
            {
                timePanel.SetActive(true);
            }

        }
        if (enterPanel != null)
        {
            enterPanel.SetActive(true);
        }
        exitPanel.SetActive(false);

    }
}
