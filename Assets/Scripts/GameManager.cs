using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using DG.Tweening;
using Cinemachine;
using UnityEngine.UI;
public class GameManager : Singleton<GameManager>
{
    [Header("Camera")]
    public CinemachineVirtualCamera vcam;
    
    [Header("Player")]
    public GameObject playerPrefab;
    
    [Header("Enemy")]
    public List<GameObject> enemies;
    
    [Header("References")]
    public Transform startPoint;
    
    [Header("Animation")]
    public float duration = 0.5f;
    public float delay = 0.1f;
    public Ease ease = Ease.OutBack;
    
    private GameObject _currentPlayer;

    private void Start()
    {
        Init();
        _currentPlayer = GameObject.Find("Player");
    }
    public void Init()
    {
        SpawnPlayer();
        // Assign the clone to the virtual camera
        vcam.Follow = _currentPlayer.transform;
    }

    void SpawnPlayer()
    {
        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.position = startPoint.transform.position;
        _currentPlayer.transform.DOScale(Vector3.one, duration).SetEase(ease); 
    }
}
