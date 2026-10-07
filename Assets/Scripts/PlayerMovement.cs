using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool shieldActive = false;

    [SerializeField] private LayerMask floorLayer;

    private bool isPressingUp = false;
    private bool isPressingDown = false;
    private bool isTappetUp = false;
    private bool inFloor = false;
    [SerializeField] private float jumpForce;
    [SerializeField] private float originalGravityScale;
    [SerializeField] private float jumpGravityScale;
    [SerializeField] private float rayCastLong;
    [SerializeField]  public Rigidbody2D rb;

    private void Start()
    {
        rb.gravityScale = originalGravityScale;
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("se apreto salto");
            isPressingUp = true;
            isTappetUp = true;
        }
        else
        {
            isPressingUp = false;
            isTappetUp = false;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.localPosition, Vector2.down, rayCastLong, floorLayer);
        inFloor = hit.collider != null;
    }

    private void FixedUpdate()
    {
        if (isPressingUp)
        {
            rb.gravityScale = jumpGravityScale;
        }
        else
        {
            rb.gravityScale = originalGravityScale;
        }

        if ((isTappetUp) && (inFloor))
        {
            Debug.Log("salto");
            rb.linearVelocityY = jumpForce;
        }

    }

}

