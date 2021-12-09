using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("move")]
    private float moveSpeed = 2f;

    [Header("jump")]
    public LayerMask whatIsGround;
    private bool isJump = false;
    public int jumpCount = 1;//ÃÖ´ë Á¡ÇÁ È½¼ö
    private int currentJumpCount = 0;
    private float jumpForce = 7f;

    [Header("dash")]
    public int dashCount;
    private int currentDashCount;
    private bool isDash = false;
    private float dashPower = 20f;
    private float dashCoolTime = 0.1f;

    [Header("dir")]
    public bool facingRight = true;


    private Rigidbody2D rigid;
    private PlayerInput input;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        currentJumpCount = jumpCount;
        currentDashCount = dashCount;
    }

    private void Update()
    {
        if (input.isJump && currentJumpCount > 0)
            isJump = true;

        if (input.isDash && currentDashCount > 0)
        {
            isDash = true;
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        //Jump
        RaycastHit2D groundCheck = Physics2D.Raycast(transform.position, Vector2.down, 0.4f, whatIsGround);
        if (groundCheck.collider != null) currentJumpCount = jumpCount;
        if (isJump)
        {
            currentJumpCount--;
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJump = false;
        }

        //Flip
        if((facingRight && ReturnMousePos().x - transform.position.x < 0) || (!facingRight && ReturnMousePos().x - transform.position.x > 0))
        {
            Flip();
        }

        //Move
        if (!isDash)
            rigid.velocity = new Vector2(input.xMove * moveSpeed, rigid.velocity.y);
    }

    IEnumerator Dash()
    {
        //currentDashCount--;

        Vector2 dir = ReturnMousePos() - transform.position;
        rigid.velocity = Vector3.zero;
        rigid.gravityScale = 0;
        rigid.AddForce(dir.normalized * dashPower, ForceMode2D.Impulse);

        //ÀÌÆåÆ®

        yield return new WaitForSeconds(dashCoolTime);//ÄðÅ¸ÀÓ

        rigid.velocity = Vector3.zero;
        rigid.gravityScale = 1;

        isDash = false;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 local = transform.localScale;
        local.x *= -1;
        transform.localScale = local;
    }

    private Vector3 ReturnMousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }


}
