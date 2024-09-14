using UnityEngine;

public class ObstacleElementas : MonoBehaviour
{
    private float _force = 20;
    private Rigidbody _rb;
    private int _ignorePlayerObstacleLayer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Setup(int layer)
    {
        _ignorePlayerObstacleLayer = layer;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController playerController))
        {
            var direction = (collision.contacts[0].point - playerController.transform.position).normalized;
            _rb.AddForce(direction * _force, ForceMode.Impulse);
            gameObject.layer = _ignorePlayerObstacleLayer;
        }
    }

    public void Disable()
    {
        _rb.velocity = Vector3.zero;
        _rb.isKinematic = true;
        _rb.useGravity = false;
    }

    public void Enable()
    {
        _rb.isKinematic = false;
        _rb.useGravity = true;
        _rb.velocity = Vector3.zero;
    }
}
