using UnityEngine;
using UnityEngine.Serialization;

namespace Environment
{
    [ExecuteAlways]
    public class CreateEnviroment : MonoBehaviour
    {
        [FormerlySerializedAs("RoadPartCount")]
        [Header("Environment Settings")]
        [Min(1)] [SerializeField] private int _roadPartCount; 
        [SerializeField] private float _roadOffset; 
        [SerializeField] private GameObject _roadPrefab;
        
        [FormerlySerializedAs("FinishPrefab")]
        [Header("Finish Settings")]
        [SerializeField] private GameObject _finishPrefab;
        
        private void Update()
        {
            if (!_roadPrefab)
            {
                return;
            }

            if (transform.childCount < _roadPartCount)
            {
                CreateRoadPart();
            }

            else if (transform.childCount > _roadPartCount)
            {
                DeleteRoadParts(transform.childCount - _roadPartCount);
                UpdateRoadPositions();
                UpdateFinishPosition();
            }
        }

        private void CreateRoadPart()
        {
            var transformPosition = transform.position;

            for (int i = 0; i < _roadPartCount; i++)
            {
                transformPosition = new Vector3(transformPosition.x, transformPosition.y, +(i * _roadOffset));

                var instantiate = Instantiate(_roadPrefab, transformPosition, Quaternion.identity, transform);
            }
        }

        private void DeleteRoadParts(int count)
        {
            for (int i = transform.childCount - 1; i >= _roadPartCount; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }

        private void UpdateRoadPositions()
        {
            var transformChildCount = transform.childCount;

            for (int i = 0; i < transformChildCount; i++)
            {
                var roadPart = transform.GetChild(i);
                roadPart.localPosition = new Vector3(0, 0, i * _roadOffset);
            }
        }
        
        private void UpdateFinishPosition()
        {
            if (!_finishPrefab)
            {
                return;
            }
            
            _finishPrefab.transform.localPosition = new Vector3(0, 0, _roadPartCount * _roadOffset);
        }

        private void OnValidate()
        {
            UpdateRoadPositions();
            UpdateFinishPosition();
        }
    }
}