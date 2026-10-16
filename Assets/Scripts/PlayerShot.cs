using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] private Animator slashAnimator;
    [SerializeField] private BulletMovement bulletPrefab;
    [SerializeField] private Transform body;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private float shotCoolDown = 0.7f;
    [SerializeField] private float slashCoolDown = 1.3f;
    [SerializeField] private float slashDuration = 0.5f;
    private float shotTimer;
    private float slashTimer;

    private void Update()
    {
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
            Debug.Log("se ataco con el cuchillo");
            slashAnimator.SetBool("Atack", true);
        }
        if (slashTimer < slashCoolDown - slashDuration) 
        {
            slashAnimator.SetBool("Atack", false);
        }

    }

}
