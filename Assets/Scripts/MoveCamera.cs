using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset = Vector3.zero;
    [SerializeField]
    private float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;
    
    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
