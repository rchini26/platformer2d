using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
   public Rigidbody2D rb;
   public HealthBase healthBase;
   
   [Header("Speed Setup")]
   public Vector2 friction = new Vector2(-.1f, 0);
   public float speed;
   public float runSpeed;
   public float jumpForce = 15;

   [Header("Animation Setup")] 
   public SOFloat soJumpScaleY;
   public SOFloat soJumpScaleX;
   public SOFloat soAnimationDuration;
   public Ease ease = Ease.OutBack;

   [Header("Animation Player")] 
   public string boolRun = "Run";
   public string triggerDeath = "Death";
   public Animator animator;
   public float playerSwipeDuration = 0.1f;
   
   private float _currentSpeed;
   

   private void Awake()
   {
      if (healthBase != null)
      {
         healthBase.OnKill += OnPlayerKill;
      }
   }

   private void OnPlayerKill()
   {
      healthBase.OnKill -= OnPlayerKill;
      animator.SetTrigger(triggerDeath);
   }
   private void Update()
   {
      HandleMovement();
      HandleJump();
   }

   void HandleMovement()
   {
      if(Input.GetKey(KeyCode.LeftShift))
      {
         _currentSpeed = runSpeed;
         animator.speed = 1.5f;
      }
      else
      {
         _currentSpeed = speed;
         animator.speed = 1;
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
         Vector3 s = rb.transform.localScale;
         rb.transform.localScale = new Vector3(s.x, 1f, s.z);
         DOTween.Kill(rb.transform);
         HandleJumpScale();
      }
   }

   void HandleJumpScale()
   {
      float xSign = Mathf.Sign(rb.transform.localScale.x);
      rb.transform.DOScaleY(soJumpScaleY.value, soAnimationDuration.value).SetLoops(2, LoopType.Yoyo).SetEase(ease);
      rb.transform.DOScaleX(soJumpScaleX.value * xSign, soAnimationDuration.value).SetLoops(2, LoopType.Yoyo).SetEase(ease);
   }

   public void DestroyMe()
   {
      Destroy(gameObject);
   }
}
