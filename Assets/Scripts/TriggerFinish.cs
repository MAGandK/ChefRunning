using System;
using UnityEngine;
using Zenject;

public class TriggerFinish : MonoBehaviour
{
    private GameManager _gameManager;
   
    
    
    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_gameManager.IsGameFinished)
        {
            _gameManager.FinishGame();
            
        }
    }
}
