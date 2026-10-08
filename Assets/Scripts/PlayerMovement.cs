using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool shieldActive = false;

    [SerializeField] private LayerMask floorLayer;

    private bool isPressingUp = false;
    private bool isPressingDown = false;
    private bool isTappetUp = false;
    private bool inFloor = false;
    private bool goingRight = false;
    private bool goingLeft = false;
    [SerializeField] private float speed;
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
            isPressingUp = true;
            isTappetUp = true;
        }
        else
        {
            isPressingUp = false;
            isTappetUp = false;
        }

        if (Input.GetKey(KeyCode.D)) goingRight = true;
        else goingRight = false;

        if (Input.GetKey(KeyCode.A)) goingLeft = true;
        else goingLeft = false;


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
            rb.linearVelocityY = jumpForce;
        }

        if(goingRight) rb.linearVelocityX = speed;

        else if (goingLeft) rb.linearVelocityX = -speed;
        else rb.linearVelocityX = 0;

    }

}

