using UnityEngine;
using Zenject;

public class TriggerHammer : MonoBehaviour
{
    [SerializeField]
    private Transform _objectHammer;
    private bool _isKilleble;
    
    [SerializeField]
    private GameObject[] _explosionEffects;
    
    private GameManager _gameManager;
    private LevelPrefabManager _levelPrefabManager;
    
    [Inject]
    private void Construct(GameManager gameManager, LevelPrefabManager levelPrefabManager)
    {
        _gameManager = gameManager;
        _levelPrefabManager = levelPrefabManager;
    }
    private void Awake()
    {
        _isKilleble = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
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
    internal void DisableKillAbility()
    {
        _isKilleble = false;
    }
    
    public void Push()
    {
        foreach (var effect in _explosionEffects)
        {
            Instantiate(effect, _objectHammer.position, Quaternion.identity);
        }
    }

    public void ResetHammer()
    {
        _objectHammer.gameObject.SetActive(true);
    }
}
