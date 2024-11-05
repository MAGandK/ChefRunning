using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class ButtonHit : MonoBehaviour
{
    private GameManager _gameManager;
    public static bool IsHitPressed { get; private set; }
    
    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsHitPressed = true; 
            OnHitButtonPressed();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            IsHitPressed = false; 
        }
    }
    
    private void OnHitButtonPressed()
    {
        _gameManager.PlayerHit();
        IsHitPressed = true; 
    }
}
