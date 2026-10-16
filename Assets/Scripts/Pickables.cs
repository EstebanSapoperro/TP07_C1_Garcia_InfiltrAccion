using Unity.VisualScripting;
using UnityEngine;

public class Pickables : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PickablesDataSo data;
    private float xImpulse;
    private float jumpForce;

    void Start()
    {
        xImpulse = data.xImpulse;
        jumpForce = data.jumpForce;
        rb.AddForce(new Vector2(Random.Range(-xImpulse, xImpulse), jumpForce));
        Destroy(gameObject, 3);
    }
}
