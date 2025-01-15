using System;
using System.Collections;
using System.Collections.Generic;
using CustomNameSpase;
using UnityEngine;

public class ObstacleBarrel : ObstacleBase
{
    [SerializeField] private float _time;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private float _rotationSpeed;
    
    private List<GameObject> _obstacles = new List<GameObject>();

    private void OnEnable()
    {
        StartMovement();
        GameManager.IsRestartGame += ResetObstacle;
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

    public void ResetObstacle()
    {
        Debug.Log("ResetObstacle called");
        transform.position = _startPosition.position;
        transform.rotation = _startPosition.rotation;

        foreach (var obstacle in _obstacles)
        {
            obstacle.SetActive(true);
        }

        _obstacles.Clear();
        StartMovement();
    }
    
    public override void Destroy()
    {
        _obstacles.Add(gameObject);
        gameObject.SetActive(false);
        Debug.Log(gameObject.name);
        StopAllCoroutines();
    }

    private void OnDisable()
    {
        GameManager.IsRestartGame -= ResetObstacle;
    }
    
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_targetPosition.position, radius: 1);
        Gizmos.DrawWireSphere(_startPosition.position, radius: 2);
    }
#endif
}