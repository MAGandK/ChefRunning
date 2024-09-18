using System.Collections;
using UnityEngine;
public class MovingObstacle : MonoBehaviour
{
    [SerializeField]
    private Transform _object;
    [SerializeField]
    private float _time;
    [SerializeField]
    private Transform _targetPos; 
    [SerializeField]
    private float _rotetionSpeed;
    [SerializeField]
    private ObstacleCrush _obstacleCrush;
    
    private Vector3 _startPosition;

    private void OnEnable()
    {
        if (_obstacleCrush != null)
        {
            _obstacleCrush.ObstacleCrushs += ObstacleCrush_Push;
        }
    }

    private void OnDisable()
    {
        if (_obstacleCrush != null)
        {
            _obstacleCrush.ObstacleCrushs -= ObstacleCrush_Push;
        }
    }

    private void ObstacleCrush_Push()
    {
       StopAllCoroutines();
    }

    private void Start()
    {
        _startPosition = _object.transform.position;
        StartCoroutine(ObstacleMovement(_object, _targetPos.position, _time));
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
                angle += _rotetionSpeed;
                obj.rotation = Quaternion.AngleAxis(angle, obj.up);
                obj.position = Vector3.Lerp(startPosition, targetPosition, progress);
                yield return null;
            }

            time = 0;
            while (time <= executionTime)
            {
                time += Time.deltaTime; 
                progress = time / executionTime;
                angle += _rotetionSpeed;
                obj.rotation = Quaternion.AngleAxis(angle, obj.up);
                obj.position = Vector3.Lerp(targetPosition, startPosition, progress);
                yield return null;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_targetPos.position, radius: 1);
    }
}
