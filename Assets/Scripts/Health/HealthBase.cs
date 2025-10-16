using System.Collections;
using System;
using DG.Tweening;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public Action OnKill;
    
    public int startLife = 10;
    public bool destroyOnKill;
    public float delayToKill = .5f;
    
    private int _currentLife;
    private bool _isDead;
    
    [SerializeField] FlashColor _flashColor;

    void Awake()
    {
        Init();
        if (_flashColor == null)
        {
            _flashColor = GetComponent<FlashColor>();
        }
    }

    void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }
    public void Damage(int damage)
    {
        if(_isDead) return;
        
        _currentLife -= damage;
        
        if (_flashColor != null)
        {
            _flashColor.Flash();
        }
        
        if (_currentLife <= 0)
        {
            Kill();    
        }
    }

    private void Kill()
    {
        _isDead = true;
        if (_flashColor != null)
        {
            DOTween.Kill(gameObject);
        }
        
        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }

        if (OnKill != null)
        {
            OnKill.Invoke();
        }
    }
}
