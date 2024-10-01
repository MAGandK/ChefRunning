using UnityEngine;
using Zenject;

public class TriggerFinish : MonoBehaviour
{
    private GameManager _gameManager;
    private Player _player;

    [Inject]
    private void Construct(GameManager gameManager, Player player)
    {
        _gameManager = gameManager;
        _player = player;
    }

    private void OnTriggerEnter(Collider other)
    {
        _gameManager.FinishGame();
        Debug.Log("Finish");
        _player.RotatePlayerToTarget();
        Debug.Log("Повернули игрока");
        
    }
}
