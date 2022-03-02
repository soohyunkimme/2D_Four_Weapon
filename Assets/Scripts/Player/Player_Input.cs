using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    public float xMove { get; private set; }
    public bool Jump { get; private set; }
    public bool Dash { get; private set; }


    private void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        Jump = Input.GetButtonDown("Jump");
        Dash = Input.GetMouseButtonDown(1);
    }
}
