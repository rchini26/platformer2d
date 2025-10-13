using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Rigidbody2D rb;
   [Header("Speed Setup")]
   public Vector2 friction = new Vector2(-.1f, 0);
   public float speed;
   public float runSpeed;
   public float jumpForce = 15;

   [Header("Animation Setup")] 
   public float jumpScaleY = 1.5f;
   public float jumpScaleX = .7f;
   public float animationDuration = 0.3f;
   public Ease ease = Ease.OutBack;

   [Header("Animation Player")] 
   public string boolRun = "Run";
   public Animator animator;
   public float playerSwipeDuration = 0.1f;
   
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
         if(rb.transform.localScale.x != -1)
         {
            rb.transform.DOScaleX(-1, playerSwipeDuration);
         }
         animator.SetBool(boolRun, true);
      }
      else if(Input.GetKey(KeyCode.RightArrow))
      {
         rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);
         if(rb.transform.localScale.x != 1)
         {
            rb.transform.DOScaleX(1, playerSwipeDuration);
         }
         animator.SetBool(boolRun, true);
      }
      else
      {
         animator.SetBool(boolRun, false);
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
      if (Input.GetKeyDown(KeyCode.Space))
      { 
         rb.velocity = Vector2.up * jumpForce;
         rb.transform.localScale = Vector2.one;
         DOTween.Kill(rb.transform);
         HandleJumpScale();
      }
   }

   void HandleJumpScale()
   {
      rb.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
      rb.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
   }
}
