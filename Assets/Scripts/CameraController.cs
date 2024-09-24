using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private Transform _playerTransform;

    public void SetPlayer(Transform playerTransform)
    {
        _playerTransform = playerTransform;
        virtualCamera.Follow = _playerTransform;
        virtualCamera.LookAt = _playerTransform;
    }
}
