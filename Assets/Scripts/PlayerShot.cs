using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] private BulletMovement bulletPrefab;
    [SerializeField] private Transform body;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private float shotCoolDown = 0.7f;
    private float shotTimer;

    private void Update()
    {
        shotTimer -= Time.deltaTime;

        if (Input.GetMouseButton(0) && shotTimer < 0 && PlayerGameManager.playerAmmo > 0)
        {
            BulletMovement bullet = Instantiate(bulletPrefab, shotPoint.position, Quaternion.identity);
            bullet.Shot(Mathf.Sign(body.transform.right.x));
            PlayerGameManager.playerAmmo -= 1;
            shotTimer = shotCoolDown;
        }
    }

}
