using Managers;
using UnityEngine;
using Zenject;
using PlayerLogics;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _mainCamera;
    [SerializeField] private CinemachineVirtualCamera _failCamera;
    [SerializeField] private CinemachineVirtualCamera _finishCamera;
    
    private GameManager _gameManager;
    private Player _player;

    public Vector3 FinishCameraPosition => _finishCamera.transform.position;
    
    [Inject]
    private void Construct(GameManager gameManager, Player player)
    {
        _gameManager = gameManager;
        _player = player;
    }
    private void OnEnable()
    {
        _gameManager.GameStarted += GameManagerOnGameStarted;
        _gameManager.GameFinished += GameManagerOnGameFinished;
        _gameManager.GameExited += GameManagerOnGameExited;
        _player.Died += PlayerOnDied;
    }
    
    private void OnDisable()
    {
        _gameManager.GameStarted -= GameManagerOnGameStarted;
        _gameManager.GameFinished -= GameManagerOnGameFinished;
        _gameManager.GameExited -= GameManagerOnGameExited;
    }

    private void GameManagerOnGameStarted()
    {
        _mainCamera.Priority = 10;
        _failCamera.Priority = 0;
        _finishCamera.Priority = 0;
    }

    private void GameManagerOnGameFinished()
    {
        _mainCamera.Priority = 0;
        _failCamera.Priority = 0;
        _finishCamera.Priority = 10;
    }
    
    private void PlayerOnDied()
    {
        _mainCamera.Priority = 0;
        _failCamera.Priority = 10;
    }
    
    private void GameManagerOnGameExited()
    {
        _mainCamera.Priority = 10;
        _failCamera.Priority = 0;
        _finishCamera.Priority = 0;
    }
}