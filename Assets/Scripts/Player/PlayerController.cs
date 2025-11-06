using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
   public Rigidbody2D rb;
   public HealthBase healthBase;
   
   [Header("Setup")]
   public SOPlayerSetup playerSetup;
   
   private float _currentSpeed;
   public Animator animator;
   public AudioSource jumpSound;
   
   [Header("Jump Collision Check")]
   public bool isOnGround;
   public ParticleSystem jumpParticles;
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
      animator.SetTrigger(playerSetup.triggerDeath);
   }
   private void Update()
   {
      HandleMovement();
      HandleJump();
   }

   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy"))
      {
         isOnGround = true;
      }
   }
   void HandleMovement()
   {
      if(Input.GetKey(KeyCode.LeftShift))
      {
         _currentSpeed = playerSetup.runSpeed;
         animator.speed = 1.5f;
      }
      else
      {
         _currentSpeed = playerSetup.speed;
         animator.speed = 1;
      }

      if(Input.GetKey(KeyCode.LeftArrow))
      {
         rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);
         if(rb.transform.localScale.x != -1)
         {
            rb.transform.DOScaleX(-1, playerSetup.playerSwipeDuration);
         }
         animator.SetBool(playerSetup.boolRun, true);
      }
      else if(Input.GetKey(KeyCode.RightArrow))
      {
         rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);
         if(rb.transform.localScale.x != 1)
         {
            rb.transform.DOScaleX(1, playerSetup.playerSwipeDuration);
         }
         animator.SetBool(playerSetup.boolRun, true);
      }
      else
      {
         animator.SetBool(playerSetup.boolRun, false);
      }

      if(rb.velocity.x > 0)
      {
         rb.velocity += playerSetup.friction;
      }
      else if(rb.velocity.x < 0)
      {
         rb.velocity -= playerSetup.friction;
      }
   }

   void HandleJump()
   {
      if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
      { 
         isOnGround = false;
         rb.velocity = Vector2.up * playerSetup.jumpForce;
         Vector3 s = rb.transform.localScale;
         rb.transform.localScale = new Vector3(s.x, 1f, s.z);
         DOTween.Kill(rb.transform);
         HandleJumpScale();
         PlayJumpFX();
      }
   }

   void PlayJumpFX()
   {
      if (jumpParticles != null)
      {
         jumpParticles.Play();
      }

      if (jumpSound != null)
      {
         AudioSource audioSource = Instantiate(jumpSound);
         audioSource.Play();
         Destroy(audioSource.gameObject, audioSource.clip.length);
      }
   }
   void HandleJumpScale()
   {
      float xSign = Mathf.Sign(rb.transform.localScale.x);
      rb.transform.DOScaleY(playerSetup.jumpScaleY, playerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(playerSetup.ease);
      rb.transform.DOScaleX(playerSetup.jumpScaleX * xSign, playerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(playerSetup.ease);
   }

   public void DestroyMe()
   {
      Destroy(gameObject);
   }
}
