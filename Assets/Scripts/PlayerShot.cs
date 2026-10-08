using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] private BulletMovement bulletPrefab;
    [SerializeField] private Transform body;
    [SerializeField] private Transform shotPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BulletMovement bullet = Instantiate(bulletPrefab, shotPoint.position, Quaternion.identity);
            bullet.Shot(Mathf.Sign(body.transform.right.x));
        }
    }

}
