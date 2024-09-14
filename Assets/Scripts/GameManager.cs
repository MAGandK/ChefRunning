using System.Collections;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField]
    private UIController _uIController;
    [SerializeField]
    private AnimatorController _animatorController;
    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private Transform _targetTransform;
    
    private bool _isGameStarted = false;
    private bool _isGameFinished = false;
    
    public bool IsGameStarted => _isGameStarted;
    public bool IsGameFinished => _isGameFinished;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isGameStarted)
        {
            StartGame();
        }
    }
    

    public void StartGame()
    {
        _isGameStarted = true;
        _uIController.ShowWindow(WindowType.MainWindow);
        _animatorController.Run(); 
    }

    public void FinishGame()
    {
        _isGameFinished = true;
        _uIController.ShowWindow(WindowType.FinishWindow);
        _animatorController.StopRun();
        _animatorController.Danced();
        RotatePlayerToTarget();
    }

    public void PlayerDied()
    {
        _playerController.Die();
        _animatorController.Died();
        _uIController.ShowWindow(WindowType.FailWindow);
    }

    public void RestartGame()
    {
        _isGameStarted = false;
        _isGameFinished = false;

        _playerController.ResetPlayerState(); 
    }
 
    private void RotatePlayerToTarget()
    {
        Vector3 direction = _targetTransform.position - _playerController.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        _playerController.transform.rotation = targetRotation;
    }
}
