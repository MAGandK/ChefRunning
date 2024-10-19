using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private Transform _object;
    [SerializeField]
    private float _time;
    [SerializeField]
    private Transform _targetPosition;
    [SerializeField]
    private Transform _startPosition;
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private GameObject[] _explosionEffects; 
    
    private bool _isKilleble;
    
    private GameManager _gameManager;
    private LevelPrefabManager _levelPrefabManager;
    private Player _player;
    
    [Inject]
    private void Construct(GameManager gameManager, LevelPrefabManager levelPrefabManager, Player player)
    {
        _gameManager = gameManager;
        _levelPrefabManager = levelPrefabManager;
        _player = player;
    }
    
    private void Awake()
    {
        _isKilleble = true;
    }
    
    private void OnEnable()
    {
        StartMovement();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (_player.IsHitting && !_isKilleble)
        {
            Debug.Log(" hit ");
            _gameManager.PlayerHit(); 
            Push(); 
            _levelPrefabManager._obstacle.Add(gameObject);
            gameObject.SetActive(false);
        }
        else if (!_player.IsDead && _isKilleble) 
        {
            _gameManager.PlayerDied(); 
        }
            
        StopAllCoroutines();
        DisableKillAbility();
    }
    internal void DisableKillAbility()
    {
        _isKilleble = false;
    }
    
    private void StartMovement()
    {
        StartCoroutine(ObstacleMovement(_object, _targetPosition.position, _time));
    }

    private IEnumerator ObstacleMovement(Transform obj, Vector3 targetPosition, float executionTime)
    {
        Vector3 startPosition = _startPosition.position;
        float angle = 0;

        while (true)
        {
            float time = 0;
            float progress = 0;
            while (time <= executionTime)
            {
                time += Time.deltaTime; 
                progress = time / executionTime;
                angle += _rotationSpeed;
                obj.rotation = Quaternion.AngleAxis(angle, obj.up);
                obj.position = Vector3.Lerp(startPosition, targetPosition, progress);
                yield return null;
            }

            time = 0;
            while (time <= executionTime)
            {
                time += Time.deltaTime; 
                progress = time / executionTime;
                angle += _rotationSpeed;
                obj.rotation = Quaternion.AngleAxis(angle, obj.up);
                obj.position = Vector3.Lerp(targetPosition, startPosition, progress);
                yield return null;
            }
        }
    }
    public void Push()
    {
        foreach (var effect in _explosionEffects)
        {
            Instantiate(effect, _object.position, Quaternion.identity);
        }
    }

    public void ResetObstacle()
    {
        _object.position = _startPosition.position; 
        _object.rotation = _startPosition.rotation;  
        _object.gameObject.SetActive(true);
        _isKilleble = true;
        StartMovement();
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_targetPosition.position, radius: 1);
        Gizmos.DrawWireSphere(_startPosition.position, radius: 2);
    }
}
