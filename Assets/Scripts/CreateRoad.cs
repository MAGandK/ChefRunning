using UnityEngine;

[ExecuteAlways]

public class CreateRoad : MonoBehaviour
{
    [Min(1)]
    public int RoadPartCount;

    public float _offset;

    public GameObject RoadPrefab;

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
        }
    }

    private void CreateRoadPart()
    {
        var transformPosition = transform.position;

        for (int i = 0; i < RoadPartCount; i++)
        {
            transformPosition = new Vector3(transformPosition.x, transformPosition.y, +(i * _offset));

            var instatiate = Instantiate(RoadPrefab, transformPosition, Quaternion.identity, transform);
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
        var transformPosition = transform.position;

        for (int i = 0; i < RoadPartCount; i++)
        {
            var roadPart = transform.GetChild(i);
            roadPart.position = new Vector3(transformPosition.x, transformPosition.y, i * _offset);
        }
    }
}

