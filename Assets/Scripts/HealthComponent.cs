using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private GameObject father;
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
        if (health < 0) 
        {
            particles.Play();
            Destroy(father, 0.5f);

        }
    }

}
