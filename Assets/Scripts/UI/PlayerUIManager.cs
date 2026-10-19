using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private Image fillHealthBarImage;
    [SerializeField] private Image fillKnifeBarImage;
    [SerializeField] TextMeshProUGUI ammoText;
    private float maxHealth;
    private void Awake()
    {
        PlayerShot.OnAmmoUsed += UpdateAmmo;
        PlayerHealth.OnUpdateHealth += UpdateHealth;
        PlayerShot.OnUpdateKinifeTimer += UpdateKnifeCooldown;
    }

    private void Start()
    {
        maxHealth = PlayerGameManager.playerMaxHealth;

    }
    private void OnDestroy()
    {
        PlayerHealth.OnUpdateHealth -= UpdateHealth;
        PlayerShot.OnAmmoUsed -= UpdateAmmo;
        PlayerShot.OnUpdateKinifeTimer -= UpdateKnifeCooldown;
    }

    private void UpdateHealth()
    {
        fillHealthBarImage.fillAmount = PlayerGameManager.playerHealth / PlayerGameManager.playerMaxHealth;
    }
    private void UpdateAmmo() 
    {
        ammoText.text = PlayerGameManager.playerAmmo.ToString("F0");
    }

    private void UpdateKnifeCooldown() 
    {
        fillKnifeBarImage.fillAmount = Mathf.Clamp01(PlayerGameManager.knifeTimer / PlayerGameManager.readyKnifeTime);
    }
}
