using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(-.1f, 0);
    public float speed;
    public float runSpeed;
    public float jumpForce = 15;

    [Header("Animation Setup")] 
    public float jumpScaleY;
    public float jumpScaleX;
    public float animationDuration;
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")] 
    public string boolRun = "Run";
    public string triggerDeath = "Death";
    public float playerSwipeDuration = 0.3f;
}
