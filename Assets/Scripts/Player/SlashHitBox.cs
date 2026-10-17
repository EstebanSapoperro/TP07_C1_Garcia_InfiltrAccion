using UnityEngine;

public class SlashHitBox : MonoBehaviour
{
    [SerializeField] private PlayerSo data;
    private float slashDamage;
    private void Start()
    {
        slashDamage = data.slashDamage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemigos"))
        {
            HealthComponent enemyLife = other.GetComponentInChildren<HealthComponent>();
            enemyLife.DoDamage(slashDamage);
        }
    }
}
