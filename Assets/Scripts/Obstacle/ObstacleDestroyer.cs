using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    private bool _canDestroy;

    public void SetCanDestroy(bool canDestroy)
    {
        _canDestroy = canDestroy;
    }
    private void OnTriggerStay(Collider other)
    {
        if (!_canDestroy)
        {
            return;
        }
        //позже брать базовый класс препятствий
        if (other.TryGetComponent(out ObstacleBarrel obstacleBarrel))
        {
            obstacleBarrel.Destroy();
            
        }
    }
}
