using UnityEngine;

namespace Environment
{
    [ExecuteAlways]
    public class CreateRoad : MonoBehaviour
    {
        [Header("Environment Settings")]
        [Min(1)] public int RoadPartCount;
        public float RoadOffset;
        public GameObject RoadPrefab;
        
        [Header("Finish Settings")]
        public GameObject FinishPrefab;
        
        private void Update()
        {
            if (RoadPrefab == null)
            {
                return;
            }

            if (transform.childCount < RoadPartCount)
            {
                CreateRoadPart();
            }

            else if (transform.childCount > RoadPartCount)
            {
                DeleteRoadParts(transform.childCount - RoadPartCount);
                UpdateRoadPositions();
                UpdateFinishPosition();
            }
        }

        private void CreateRoadPart()
        {
            var transformPosition = transform.position;

            for (int i = 0; i < RoadPartCount; i++)
            {
                transformPosition = new Vector3(transformPosition.x, transformPosition.y, +(i * RoadOffset));

                var instantiate = Instantiate(RoadPrefab, transformPosition, Quaternion.identity, transform);
            }
        }

        private void DeleteRoadParts(int count)
        {
            for (int i = transform.childCount - 1; i >= RoadPartCount; i--)
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
                roadPart.localPosition = new Vector3(0, 0, i * RoadOffset);
            }
        }
        
        private void UpdateFinishPosition()
        {
            if (FinishPrefab == null)
            {
                return;
            }
            
           FinishPrefab.transform.localPosition = new Vector3(0, 0, RoadPartCount * RoadOffset);
        }

        private void OnValidate()
        {
            UpdateRoadPositions();
            UpdateFinishPosition();
        }
    }
}