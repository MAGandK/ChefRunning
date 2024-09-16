using UnityEngine;
using Zenject;

public class TriggerObstacle : MonoBehaviour
{
    private GameManager _gameManager;
    
    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null && player.IsDaed == false)
        {
            player.Die();
            _gameManager.PlayerDied();
        }
    }
}