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
        Player player = other.GetComponent<Player>();

        if (player != null && player.IsDead == false)
        {
            player.Die();
           _gameManager.PlayerDied();
        }
    }
}