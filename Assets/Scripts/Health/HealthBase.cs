using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;
    public bool destroyOnKill;
    private int _currentLife;
    private bool _isDead;

    void Awake()
    {
        Init();
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
        
        if (_currentLife <= 0)
        {
         Kill();    
        }
    }

    private void Kill()
    {
        _isDead = true;
        if (destroyOnKill)
        {
            Destroy(gameObject);
        }
    }
}
