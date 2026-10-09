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
        Debug.Log("salio pa cualquier lugar");
        Destroy(gameObject, 3);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
        }
    }
}
