using System.Collections;
using UnityEngine;

namespace Obstacle
{
    public class ObstacleBarrel : ObstacleBase
    {
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

        public override void ResetObstacle()
        {
            base.ResetObstacle();
            transform.position = _startPosition.position;
            transform.rotation = _startPosition.rotation;
            StartMovement();
        }

        public override void Destroy()
        {
            gameObject.SetActive(false);
            StopAllCoroutines();
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_targetPosition.position, radius: 1);
            Gizmos.DrawWireSphere(_startPosition.position, radius: 2);
        }
#endif
    }
}