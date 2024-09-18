using UnityEngine;
using Zenject;

public class TriggerCoins : MonoBehaviour
{
    private UIController _uiController;
    
    [Inject]
    public void Construct(UIController uiController)
    {
        _uiController = uiController;
    }
    
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
        var mainWindow = _uiController.GetWindow(WindowType.MainWindow) as MainWindow;
        if (mainWindow != null)
        {
            mainWindow.OnCoinCollected();
        }
    }
}