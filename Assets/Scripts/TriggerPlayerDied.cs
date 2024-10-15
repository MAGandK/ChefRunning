using UnityEngine;
using Zenject;

public class TriggerPlayerDied : MonoBehaviour
{
    private GameManager _gameManager;

    [Inject]
    public void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null && !player.IsDead)
        {
            _gameManager.PlayerDied(); 
        }
    }
}