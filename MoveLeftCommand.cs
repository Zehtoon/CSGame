using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCommand : ICommand
{
    public void Execute(Rigidbody2D rb, float speed, float jump, bool isJumping, float moveHorizontal, float moveVertical)
    {
        rb.AddForce(new Vector2(-speed, 0f), ForceMode2D.Impulse);
    }
}
