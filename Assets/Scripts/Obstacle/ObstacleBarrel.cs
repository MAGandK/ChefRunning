using System.Collections;
using UnityEngine;
public class ObstacleBarrel : ObstacleBase
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
    
    private void OnEnable()
    {
        StartMovement();
    }
    
    private void StartMovement()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(ObstacleMovement(_object, _targetPosition.position, _time));
        }
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
    public override void ResetObstacle()
    {
        base.ResetObstacle();
        _object.gameObject.SetActive(true);
        _object.position = _startPosition.position;
        _object.rotation = _startPosition.rotation;
 
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
