using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private Image healthBar;
    private float health;
    private void Start()
    {
        health = maxHealth;
    }

    public void DoDamage(float damage) 
    {
        health -= damage;
        healthBar.fillAmount = health / maxHealth;
    }

}
