using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private BulletDataSo data;
    private float lifeTime;
    private float lifeTimer;
    private float speed;
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
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
    } 
}
