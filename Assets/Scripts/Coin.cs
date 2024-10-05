using System.Collections;
using UnityEngine;
using Zenject;

public class Coin : MonoBehaviour
{
    private Transform _transform;
    private float _rotationSpeed = 200f;    
    public float rotationDelay = 0f;
    private UIController _uiController;
    private LevelPrefabManager _levelPrefabManager;
    
    [Inject]
    public void Construct(UIController uiController, LevelPrefabManager levelPrefabManager)
    {
        _uiController = uiController;
        _levelPrefabManager = levelPrefabManager;
    }
    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        StartCoroutine(StartRotationWithDelay());
    }

    private IEnumerator StartRotationWithDelay()
    {
        yield return new WaitForSeconds(rotationDelay);

        while (true)
        {
            _transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
            yield return null; 
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        CollectCoin();
        _levelPrefabManager._coins.Add(gameObject);
        gameObject.SetActive(false);
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
