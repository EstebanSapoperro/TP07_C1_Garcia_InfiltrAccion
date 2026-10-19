using UnityEngine;
using System;
public class PlayerShot : MonoBehaviour
{
    public static event Action OnUpdateKinifeTimer;
    public static event Action OnAmmoUsed;
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

    private void Start()
    {
        shotCoolDown = data.shotCoolDown;
        slashCoolDown = data.slashCoolDown;
        PlayerGameManager.readyKnifeTime = data.slashCoolDown;
        slashDuration = data.slashDuration;
    }

    private void Update()
    {
        shotTimer -= Time.deltaTime;
        slashTimer -= Time.deltaTime;
        PlayerGameManager.knifeTimer = slashTimer;
        OnUpdateKinifeTimer?.Invoke();
        OnAmmoUsed?.Invoke();

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
            PlayerGameManager.knifeTimer = slashTimer;
            slashAnimator.SetBool("Atack", true);
        }
        if (slashTimer < slashCoolDown - slashDuration) 
        {
            slashAnimator.SetBool("Atack", false);
        }

    }


}
