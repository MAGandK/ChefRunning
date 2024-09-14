using UnityEngine;
public class ObstacleKillCollider : MonoBehaviour
{
    [SerializeField]
    private ObstacleCrush _obstacle;
    private Collider _collider;
    private bool _isKilleble;

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
                GameManager.Instance.PlayerDied();
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
