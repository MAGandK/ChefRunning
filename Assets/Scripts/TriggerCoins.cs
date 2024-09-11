using UnityEngine;

public class TriggerCoins : MonoBehaviour
{
    [SerializeField]
    private MainWindow _mainWindow;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            CollectCoin();
            Destroy(gameObject);
        }
    }
    private void CollectCoin()
    {
        _mainWindow.OnCoinCollected();
    }
}