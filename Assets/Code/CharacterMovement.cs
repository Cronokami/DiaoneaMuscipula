using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D Rb;
    private CapsuleCollider2D Collider;

    public float walkSpeed;
    public float walkAcceleration;
    public float jumpForce;
    public float gravityScale;

    private Vector2 RbMovement;
    private float prevWalkSpeed;
    private bool isGrounded;

    public PlayerInput playerInput;
    private InputAction Jump;

    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Collider = GetComponent<CapsuleCollider2D>();
        Rb.gravityScale = gravityScale;
    }

    private void Update()
    {
        //FlipSprite();
    }


    void FixedUpdate()
    {
        prevWalkSpeed = Rb.linearVelocity.x;
        Rb.linearVelocity = new Vector2( Mathf.Lerp(prevWalkSpeed, walkSpeed * RbMovement.x, !isGrounded? walkAcceleration : walkAcceleration/2 ), Rb.linearVelocity.y);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        RbMovement.x = movementVector.x;
        FlipSprite();
    }

    private void OnJump()
    {
        if (!isGrounded) return;
        Rb.linearVelocity = new Vector2(Rb.linearVelocity.x, 0);
        Rb.AddForceY(jumpForce, ForceMode2D.Impulse);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.GetContact(0).normal.y > transform.position.y)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void FlipSprite()
    {
        if(RbMovement.x > 0.5)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (RbMovement.x < -0.5)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

}
