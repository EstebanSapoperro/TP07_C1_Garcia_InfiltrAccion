using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] private PlayerSo data;
    [SerializeField] private Animator slashAnimator;
    [SerializeField] private BulletMovement bulletPrefab;
    [SerializeField] private Transform body;
    [SerializeField] private Transform shotPoint;

    private float shotCoolDown;
    private float slashCoolDown;
    private float slashDuration;
    private float shotTimer;
    private float slashTimer;

    private void Update()
    {
        shotCoolDown = data.shotCoolDown;
        slashCoolDown = data.slashCoolDown;
        slashDuration = data.slashDuration;
        shotTimer -= Time.deltaTime;
        slashTimer -= Time.deltaTime;

        if (Input.GetMouseButton(0) && shotTimer < 0 && PlayerGameManager.playerAmmo > 0)
        {
            BulletMovement bullet = Instantiate(bulletPrefab, shotPoint.position, Quaternion.identity);
            bullet.Shot(Mathf.Sign(body.transform.right.x));
            PlayerGameManager.playerAmmo -= 1;
            shotTimer = shotCoolDown;
        }

        if (Input.GetMouseButton(1) && slashTimer < 0)
        {
            slashTimer = slashCoolDown;
            slashAnimator.SetBool("Atack", true);
        }
        if (slashTimer < slashCoolDown - slashDuration) 
        {
            slashAnimator.SetBool("Atack", false);
        }

    }


}
