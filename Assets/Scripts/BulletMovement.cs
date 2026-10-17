using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private BulletDataSo data;
    private float lifeTime;
    private float lifeTimer;
    private float speed;
    private float damage;
    private bool enemyBullet;
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        enemyBullet = data.enemyBullet;
        damage = data.damage;
        lifeTime = data.lifeTime;
        speed = data.speed;
        lifeTimer = lifeTime;
    }

    private void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer < 0) Destroy(gameObject);
    }

    public void Shot(float direction) 
    {
        speed = data.speed;
        rb.linearVelocityX = direction * speed;
        Vector3 directio = new Vector3(direction,0,0);
        transform.up = directio;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (enemyBullet == false) 
        {
        
            if (other.gameObject.layer == LayerMask.NameToLayer("Solidos")) 
            {
                Destroy(gameObject);
            }
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemigos"))
            {
                HealthComponent enemyLife = other.GetComponentInChildren<HealthComponent>();
                enemyLife.DoDamage(damage);
                Destroy(gameObject);
            }
        }
        if (enemyBullet) 
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Solidos"))
            {
                Destroy(gameObject);
            }
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                PlayerHealth playerHealth = other.GetComponentInChildren<PlayerHealth>();
                playerHealth.TakeDamage(damage);
                Destroy(gameObject);
            }

        }
    }
}
