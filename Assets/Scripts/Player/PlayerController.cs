using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Rigidbody2D rb;
   public Vector2 friction = new Vector2(-.1f, 0);
   public float speed;
   public float runSpeed;
   public float jumpForce = 15;
   private float _currentSpeed;
   private void Update()
   {
      HandleJump();
      HandleMovement();
   }

   void HandleMovement()
   {
      if(Input.GetKey(KeyCode.LeftShift))
      {
         _currentSpeed = runSpeed;
      }
      else
      {
         _currentSpeed = speed;
      }

      if(Input.GetKey(KeyCode.LeftArrow))
      {
         rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);
      }
      else if(Input.GetKey(KeyCode.RightArrow))
      {
         rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);
      }

      if(rb.velocity.x > 0)
      {
         rb.velocity += friction;
      }
      else if(rb.velocity.x < 0)
      {
         rb.velocity -= friction;
      }
   }

   void HandleJump()
   {
      if(Input.GetKey(KeyCode.Space))
         rb.velocity = Vector2.up * jumpForce;
   }
}
