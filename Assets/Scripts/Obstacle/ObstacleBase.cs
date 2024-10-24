using UnityEngine;
using Zenject;
public abstract class ObstacleBase : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _explosionEffects;
    private GameManager _gameManager;
    private LevelPrefabManager _levelPrefabManager;
    private bool _isKilleble;

    [Inject]
    private void Construct(GameManager gameManager, LevelPrefabManager levelPrefabManager)
    {
        _gameManager = gameManager;
        _levelPrefabManager = levelPrefabManager;
    }

    public void Awake()
    {
        _isKilleble = true;
    }
    
    public virtual void OnTriggerEnter(Collider other)
    {
        if (_isKilleble)
        {
            _gameManager.PlayerDied();
        }
        else
        {
            _gameManager.PlayerHit();
            Push();
            _levelPrefabManager._obstacle.Add(gameObject);
            gameObject.SetActive(false);
        }
        StopAllCoroutines();
        DisableKillAbility();
    }
    
    public virtual void DisableKillAbility()
    {
        _isKilleble = false;
    }
    
    public  virtual void Push()
    {
        foreach (var effect in _explosionEffects)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }

    public virtual void ResetObstacle()
    {
        _isKilleble = true;
    }
}
