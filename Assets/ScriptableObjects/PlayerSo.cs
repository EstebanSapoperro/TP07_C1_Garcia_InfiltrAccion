using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game/Data/Player")]
public class PlayerSo : ScriptableObject
{
    [SerializeField] public LayerMask floorLayer;
    [SerializeField] public float coyoteTime = 0.15f;
    [SerializeField] public float bufferTime = 0.25f;
    [SerializeField] public float speed = 5;
    [SerializeField] public float jumpForce = 7;
    [SerializeField] public float originalGravityScale = 2.5f;
    [SerializeField] public float jumpGravityScale = 1;
    [SerializeField] public float rayCastLong = 1.2f;
    [SerializeField] public float contactDamage = 20;

    [SerializeField] public float shotCoolDown = 0.7f;
    [SerializeField] public float slashCoolDown = 1.3f;
    [SerializeField] public float slashDuration = 0.5f;
    [SerializeField] public float slashDamage = 20f;

}