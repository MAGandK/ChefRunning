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
    private float _rotationSpeed;

    [SerializeField]
    private GameObject _explosionEffect; 
    
    private Vector3 _startMovementPosition; 
    private Quaternion _startMovementRotation;
    
    private bool _isKilleble;
    public event Action ObstacleCrushs = delegate { };
    
    private GameManager _gameManager;
    
    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    
    private void Awake()
    {
        _isKilleble = true;
    }
    private void OnEnable()
    {
        ObstacleCrushs += ObstacleCrush_Push;

        _startMovementPosition = _object.transform.position;
        _startMovementRotation = _object.transform.rotation;

        StartMovement();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (_isKilleble)
            {
                Time.timeScale = 1;
                player.Die();
                _gameManager.PlayerDied();
            }
            else
            {
                Push();
                player.TakeHit();
                Debug.Log("HIT");
            }
        }
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
        Vector3 startPosition = obj.transform.position;
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

    private void ObstacleCrush_Push()
    {
        StopAllCoroutines();
    }

    public void Push()
    {
        if (_explosionEffect != null)
        {
            Instantiate(_explosionEffect, _object.position, Quaternion.identity);
        }
        
        _object.gameObject.SetActive(false);

        ObstacleCrushs();
    }

    public void ResetObstacle()
    {
        _object.position = _startMovementPosition; 
        _object.rotation = _startMovementRotation; 
        _object.gameObject.SetActive(true);

        StartMovement();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_targetPosition.position, radius: 1);
    }
    
    private void OnDisable()
    {
        ObstacleCrushs -= ObstacleCrush_Push;
    }
}
