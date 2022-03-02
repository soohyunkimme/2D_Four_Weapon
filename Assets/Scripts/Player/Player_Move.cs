using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    //이동.
    private float xMove;
    public float moveSpeed;

    //점프.
    public LayerMask ground;
    private int jumpCount = 2;
    private int currentJumpCount;
    private bool isJumping = false;
    public float jumpPower;


    private Rigidbody2D rigid;

    private Player_Input input;
    private Player_Anim anim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        input = GetComponent<Player_Input>();
        anim = GetComponent<Player_Anim>();
    }

    private void Update()
    {
        xMove = input.xMove;

        //RaycastHit2D groundCheck = Physics2D.Raycast(transform.position, Vector2.down, 1f, ground);
        //if (groundCheck.collider != null)
        //{
        //    currentJumpCount = jumpCount;
        //}
        if (input.Jump && currentJumpCount > 0 && !isJumping)
        {

            currentJumpCount--;
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(xMove * moveSpeed, rigid.velocity.y);


        if (isJumping)
            Jump();
    }

    private void Jump()
    {
        Debug.Log("1");
        Vector2 force = new Vector2(0, jumpPower);
        rigid.AddForce(force, ForceMode2D.Impulse);
        isJumping = false;
    }
}
