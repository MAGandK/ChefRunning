using System.Collections;
using UnityEngine;
public class ObstacleBarrel : MonoBehaviour
{
    public delegate void ObstacleEventHandler(GameObject obstacleBarrel);
    public static event ObstacleEventHandler OnGameObjectTrigerred;
    
    [SerializeField] private float _time;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _rotationSpeed;
    
    private void OnEnable()
    {
        StartMovement();
    }
    
    private void StartMovement()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(ObstacleMovement(_targetPosition.position, _time));
        }
    }

    private IEnumerator ObstacleMovement(Vector3 targetPosition, float executionTime)
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
                transform.rotation = Quaternion.AngleAxis(angle, transform.up);
                transform.position = Vector3.Lerp(startPosition, targetPosition, progress);
                yield return null;
            }

            time = 0;
            while (time <= executionTime)
            {
                time += Time.deltaTime;
                progress = time / executionTime;
                angle += _rotationSpeed;
                transform.rotation = Quaternion.AngleAxis(angle, transform.up);
                transform.position = Vector3.Lerp(targetPosition, startPosition, progress);
                yield return null;
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        OnGameObjectTrigerred?.Invoke(gameObject);
    }
    
    private void ResetPosition()
    {
        transform.position = _startPosition.position;
        transform.rotation = _startPosition.rotation;
    }

    public void ResetObstacle()
    {
        ResetPosition();
        StartMovement();
    }

#if UNITY_EDITOR 
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_targetPosition.position, radius: 1);
        Gizmos.DrawWireSphere(_startPosition.position, radius: 2);
    }
#endif
}
