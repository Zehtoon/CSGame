using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : ICommand
{
     public void Execute(Rigidbody2D rb, float speed, float jump, bool isJumping, float moveHorizontal, float moveVertical)
    {
        if(!isJumping && moveVertical > 0.1f)
        {
            rb.AddForce(new Vector2(0f, jump * moveVertical), ForceMode2D.Impulse);
        }
    }
}
