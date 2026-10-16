using UnityEngine;

public class PickPoints : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PickablesDataSo data;
    private float xImpulse;
    private float jumpForce;

    private int ammoDropped;

    void Start()
    {
        ammoDropped = data.ammoDropped;
        xImpulse = data.xImpulse;
        jumpForce = data.jumpForce;
        rb.AddForce(new Vector2(Random.Range(-xImpulse, xImpulse), jumpForce));
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerGameManager.playerAmmo += ammoDropped;
            Destroy(gameObject);
        }
    }

    public void Pick()
    {
        Destroy(gameObject);
    }
}
