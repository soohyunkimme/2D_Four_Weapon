using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float xMove { get; private set; }
    public bool isJump { get; private set; }
    public bool isDash { get; private set; }
    public bool isAttack { get; private set; }
    public bool isSwap { get; private set; }

    private void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        isJump = Input.GetButtonDown("Jump");
        isDash = Input.GetMouseButtonDown(1);
        isAttack = Input.GetMouseButtonDown(0);
    }
}
