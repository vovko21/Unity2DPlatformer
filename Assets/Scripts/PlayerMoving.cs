using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private LayerMask jumpGround;

    private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    private BoxCollider2D collider;
    private float speed = 7f;
    private float jumpForce = 14f;
    private enum MovingState { idle = 0, running = 1, jumping = 2, falling = 3 };
    private float dirX;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        MoveCharacter();

        TryJump();

        UpdateAnimationState();
    }

    void MoveCharacter()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(dirX * speed, rigidbody.velocity.y);
    }

    void TryJump()
    {
        if (Input.GetButton("Jump") && IsGrounded())
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }
    }

    void UpdateAnimationState()
    {
        MovingState state;
        if (dirX > 0f)
        {
            state = MovingState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovingState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovingState.idle;
        }
        if (rigidbody.velocity.y > .1f)
        {
            state = MovingState.jumping;
        }
        else if (rigidbody.velocity.y < -.1f)
        {
            state = MovingState.falling;
        }

        animator.SetInteger("state", (int)state);
    }

    bool IsGrounded()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f,
            Vector2.down, .1f, jumpGround);
    }
}
