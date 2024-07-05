using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand 
{
    void Execute(Rigidbody2D rb, float speed, float jump, bool isJumping, float moveHorizontal, float moveVertical);
}
