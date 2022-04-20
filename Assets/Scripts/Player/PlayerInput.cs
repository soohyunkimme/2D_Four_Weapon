using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Xmove { get; private set; }
    public bool Jump { get; private set; }
    public bool Dash { get; private set; }


    private void Update()
    {
        Xmove = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump"))
        {
            Jump = true;
        }
        else
        {
            Jump = false;
        }

        Dash = Input.GetMouseButtonDown(1);
    }

}
