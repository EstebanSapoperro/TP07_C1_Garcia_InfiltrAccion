
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AudioSource jumpSFX;
    [SerializeField] private Animator animato;
    private float coyoteTimer = 0;
    private float bufferTimer = 0;

    private bool isPressingUp = false;
    private bool isTappetUp = false;
    private bool inFloor = false;
    private bool goingRight = false;
    private bool goingLeft = false;
    private bool walkAnimationPlayed = false;
    private bool idleAnimationPlayed = true;

    private LayerMask floorLayer;
    private float coyoteTime;
    private float bufferTime;
    private float speed;
    private float jumpForce;
    private float originalGravityScale;
    private float jumpGravityScale;
    private float rayCastLong;
    [SerializeField]  public Rigidbody2D rb;
    [SerializeField] Transform body;
    [SerializeField] PlayerSo data;

    private void Start()
    {
        floorLayer = data.floorLayer;
        coyoteTime = data.coyoteTime;
        bufferTime = data.bufferTime;
        speed = data.speed;
        jumpForce = data.jumpForce;
        originalGravityScale = data.originalGravityScale;
        jumpGravityScale = data.jumpGravityScale;
        rayCastLong = data.rayCastLong;

        rb.gravityScale = originalGravityScale;
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            isPressingUp = true;
            isTappetUp = true;
            bufferTimer = bufferTime;
            animato.Play("Jump");
            
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
            body.transform.right = new Vector3(0, 0, 0);
            if (walkAnimationPlayed == false && isPressingUp == false) 
            {
                animato.Play("PlayerWalk");
                walkAnimationPlayed = true;
            }
            idleAnimationPlayed = false;
        }
        else 
        {
            animato.SetBool("IsWalk", false);
            goingRight = false;
            walkAnimationPlayed = false;
        }

        if (Input.GetKey(KeyCode.A)) 
        {
            goingLeft = true;
            body.transform.right = new Vector3(-180, 0, 0);
            if (walkAnimationPlayed == false && isPressingUp == false)
            {
                animato.Play("PlayerWalk");
                walkAnimationPlayed = true;
            }
            idleAnimationPlayed = false;
        }
        else
        {
            animato.SetBool("IsWalk", false);
            walkAnimationPlayed = false;
            goingLeft = false;
        }


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
            jumpSFX.Play();
            rb.linearVelocityY = jumpForce;
            bufferTimer = 0;
            coyoteTimer = 0;
        }

        if(goingRight) rb.linearVelocityX = speed;

        else if (goingLeft) rb.linearVelocityX = -speed;
        else rb.linearVelocityX = 0;

    }


}

