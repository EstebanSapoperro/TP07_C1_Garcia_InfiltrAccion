using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    private float maxHealth = 100;
    [SerializeField] private AudioSource hitEffect;
    [SerializeField] private AudioClip hitClipEffect;
    [SerializeField] private EnemyDataSo data;
    [SerializeField] private Animator animatio;
    [SerializeField] private Image healthBar;
    private float health;
    private void Start()
    {
        maxHealth = data.enemyHealth;
        health = maxHealth;
    }
    public void DoDamage(float damage) 
    {
        hitEffect.pitch = Random.Range(0.9f, 1.1f);
        hitEffect.PlayOneShot(hitClipEffect);
        health -= damage;
        healthBar.fillAmount = health / maxHealth;
        if (health <= 0) 
        {
            animatio.Play("Death");
        }
    }

}
