using UnityEngine;
using Zenject;

public class ObstacleKillCollider : MonoBehaviour
{
    [SerializeField]
    private ObstacleCrush _obstacle;
    private Collider _collider;
    private bool _isKilleble;

    private GameManager _gameManager;

    [Inject]
    private void Constract(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    private void Awake()
    {
        _isKilleble = true;
        _collider = GetComponent<Collider>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            if (_isKilleble)
            {
                Time.timeScale = 1;
                playerController.Die();
                _gameManager.PlayerDied();
            }
            else
            {
                _obstacle.Push();
                playerController.Hit();
            }
        }
    }
    internal void DisableKillAbility()
    {
        _isKilleble = false;
    }
}
