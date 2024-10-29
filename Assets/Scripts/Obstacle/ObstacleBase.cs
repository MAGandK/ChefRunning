using System.Collections;
using UnityEngine;
using Zenject;
public abstract class ObstacleBase : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _explosionEffects;
    private GameManager _gameManager;
    private LevelPrefabManager _levelPrefabManager;
    private bool _isKillable;
    
    [Inject]
    private void Construct(GameManager gameManager, LevelPrefabManager levelPrefabManager)
    {
        _gameManager = gameManager;
        _levelPrefabManager = levelPrefabManager;
    }

    public void Awake()
    {
        _isKillable = true;

    }
    
    public virtual void OnTriggerEnter(Collider other)
    {
        if (_isKillable)
        {
            Debug.Log("Player died.");
            _gameManager.PlayerDied();
        }
        else
        {
            Debug.Log("Player hit, but not dead.");
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
        _isKillable = false;
    }
    
    public virtual void Push()
    {
        foreach (var effect in _explosionEffects)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }

    public virtual void ResetObstacle()
    {
        _isKillable = true;
    }
}
