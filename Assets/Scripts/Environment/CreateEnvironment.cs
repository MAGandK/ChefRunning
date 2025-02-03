using UnityEngine;

namespace Environment
{
    [ExecuteAlways]
    public class CreateEnvironment : MonoBehaviour
    {
        [Header("Road Settings")]
        [Min(1)] [SerializeField] private int _roadPartCount; 
        [SerializeField] private float _roadOffset; 
        [SerializeField] private GameObject _roadPrefab;
        [SerializeField] private Transform _transformRoad;
        
        [Header("Environment Settings")]
        [Min(1)] [SerializeField] private int _envPartCount; 
        [SerializeField] private float _envOffset; 
        [SerializeField] private GameObject _envPrefab;
        [SerializeField] private Transform _transformEnv;
        
        // [Header("Finish Settings")]
        // [SerializeField] private GameObject _finishPrefab;
        // [SerializeField] private float _finishOffset;
        
        private void Update()
        {
            if (!_roadPrefab)
            {
                return;
            }

            if (_roadPrefab)
            {
                CreatePart(_transformRoad, _roadPrefab, _roadPartCount, _roadOffset);
                DeletePart(_transformRoad, _roadPartCount);
            }

            if (_envPrefab)
            {
                CreatePart(_transformEnv, _envPrefab, _envPartCount, _envOffset);
                DeletePart(_transformEnv, _envPartCount);
            }

            UpdateRoadPositions();
           // UpdateFinishPosition();
        }

        private void CreatePart(Transform container, GameObject prefab, int partCount, float offset)
        {
            var transformPosition = container.position;

            for (int i = container.childCount; i < partCount; i++)
            {
                transformPosition = new Vector3(transformPosition.x, transformPosition.y, +(i * offset));

                var instantiate = Instantiate(prefab, transformPosition, Quaternion.identity, container);
            }
        }

        private void DeletePart(Transform container,int count)
        {
            for (int i = container.childCount - 1; i >= count; i--)
            {
                DestroyImmediate(container.GetChild(i).gameObject);
            }
        }

        private void UpdateRoadPositions()
        {
            var transformChildCount = _transformRoad.childCount;

            for (int i = 0; i < transformChildCount; i++)
            {
                var roadPart = _transformRoad.GetChild(i);
                roadPart.localPosition = new Vector3(0, 0, i * _roadOffset);
            }
        }
        
        // private void UpdateFinishPosition()
        // {
        //     if (!_finishPrefab)
        //     {
        //         return;
        //     }
        //     
        //     _finishPrefab.transform.localPosition = new Vector3(0, 0, _roadPartCount * _roadOffset +  _finishOffset);
        //     _finishPrefab.transform.SetParent(transform);
        // }

        private void OnValidate()
        {
            UpdateRoadPositions();
           // UpdateFinishPosition();
        }
    }
}