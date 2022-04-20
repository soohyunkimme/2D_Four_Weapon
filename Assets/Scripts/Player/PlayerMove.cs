using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //이동.
    public float moveSpeed;

    //점프.
    bool isJump = false;
    public LayerMask ground;
    public int plusJumpCount = 1;
    private int currentJumpCount = 1;
    public float jumpPower;

    //방향
    private Vector2 mousePos;


    private Rigidbody2D rigid;

    private PlayerInput playerInput;
    private PlayerAnim playerAnim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        playerInput = GetComponent<PlayerInput>();
        playerAnim = GetComponent<PlayerAnim>();
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (playerInput.Jump == true)
        {
            isJump = true;
        }
    }

    private void FixedUpdate()
    {
        Flip();
        Move();
        Jump();
    }

    private void Move()
    {

        rigid.velocity = new Vector2(playerInput.Xmove * moveSpeed, rigid.velocity.y);
    }

    private void Jump()
    {
        RaycastHit2D isGround = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, ground);

        if (isJump && currentJumpCount > 0)
        {
            Vector2 force = new Vector2(0, jumpPower);
            rigid.AddForce(force, ForceMode2D.Impulse);
            rigid.velocity = new Vector2(rigid.velocity.x, Mathf.Clamp(rigid.velocity.y, float.MinValue, 6));

            if (isGround.collider == null)
                currentJumpCount--;

            isJump = false;
        }

        if (isGround.collider != null && currentJumpCount < 2)
        {
            currentJumpCount = 1;
        }
    }

    private void Flip()
    {
        if (transform.position.x > mousePos.x)
        {
            Vector2 vector = transform.localScale;
            vector.x = -1;
            transform.localScale = vector;
        }
        else
        {
            Vector2 vector = transform.localScale;
            vector.x = 1;
            transform.localScale = vector;
        }
    }
}
