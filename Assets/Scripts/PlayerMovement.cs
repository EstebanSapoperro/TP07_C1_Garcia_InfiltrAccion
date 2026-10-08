using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool shieldActive = false;

    [SerializeField] private LayerMask floorLayer;

    [SerializeField] private float coyoteTime = 0.1f;
    [SerializeField] private float bufferTime = 0.5f;

    private float coyoteTimer = 0;
    private float bufferTimer = 0;

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
            bufferTimer = bufferTime;
        }
        else
        {
            isPressingUp = false;
            isTappetUp = false;
            bufferTimer -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D)) 
        { 
            goingRight = true; 

        }
        else goingRight = false;

        if (Input.GetKey(KeyCode.A)) 
        { 
            goingLeft = true; 
        
        }
        else goingLeft = false;


        RaycastHit2D hit = Physics2D.Raycast(transform.localPosition, Vector2.down, rayCastLong, floorLayer);
        inFloor = hit.collider != null;

        if (inFloor)
        {
            coyoteTimer = coyoteTime;
        }
        else 
        {
            coyoteTimer -= Time.deltaTime;
        }

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

        if (bufferTimer > 0 && coyoteTimer > 0) 
        {
            rb.linearVelocityY = jumpForce;
            bufferTimer = 0;
            coyoteTimer = 0;
        }

        if(goingRight) rb.linearVelocityX = speed;

        else if (goingLeft) rb.linearVelocityX = -speed;
        else rb.linearVelocityX = 0;

    }

}

