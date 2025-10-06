using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Rigidbody2D rb;
   public Vector2 friction = new Vector2(-.1f, 0);
   public float speed;
   public float jumpForce = 15;
   private void Update()
   {
      HandleJump();
      HandleMovement();
   }

   void HandleMovement()
   {
      if(Input.GetKey(KeyCode.LeftArrow))
         rb.velocity = new Vector2(-speed, rb.velocity.y);
      else if(Input.GetKey(KeyCode.RightArrow))
         rb.velocity = new Vector2(speed, rb.velocity.y);
      
      if(rb.velocity.x > 0)
         rb.velocity += friction;
      else if(rb.velocity.x < 0)
         rb.velocity -= friction;
   }

   void HandleJump()
   {
      if(Input.GetKey(KeyCode.Space))
         rb.velocity = Vector2.up * jumpForce;
   }
}
