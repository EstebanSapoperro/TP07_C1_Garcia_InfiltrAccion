using Unity.VisualScripting;
using UnityEngine;

public class Pickables : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpx;
    [SerializeField] private float jump;

    void Start()
    {
        rb.AddForce(new Vector2(Random.Range(-jumpx, jumpx), jump));
        Destroy(gameObject, 3);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
        }
    }
}
