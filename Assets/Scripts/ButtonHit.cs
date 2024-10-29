using System;
using UnityEngine;
using Zenject;

public class ButtonHit : MonoBehaviour
{
    private GameManager _gameManager;
    public static event Action IsPressHit;
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
            IsHitPressed = true; // Установите флаг, когда кнопка нажата
            OnHitButtonPressed();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            IsHitPressed = false; // Сбросьте флаг, когда кнопка отпущена
        }
    }
    public void OnHitButtonPressed()
    {
        Debug.Log("Hit button pressed.");
        _gameManager.PlayerHit();
        IsPressHit?.Invoke();
    }
}
