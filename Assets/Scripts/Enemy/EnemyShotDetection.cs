using UnityEngine;

public class EnemyShotDetection : MonoBehaviour
{
    [SerializeField] private BulletMovement bulletPrefab;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private Animator animatio;
    [SerializeField] private Transform body;
    private bool canShot = true;
    void Start()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null && canShot && !animatio.GetCurrentAnimatorStateInfo(0).IsName("Death")) 
        {
            animatio.Play("Shot");
        }
    }

    public void Shot() 
    {
        BulletMovement bullet = Instantiate(bulletPrefab, shotPoint.position, Quaternion.identity);
        bullet.Shot(Mathf.Sign(body.transform.right.x));
    }

    public void CanShot(bool Shot) 
    {
        canShot = Shot;
    }
}
