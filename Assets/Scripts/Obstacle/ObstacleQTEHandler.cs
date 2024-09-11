using System;
using UnityEngine;

public class ObstacleQTEHandler : MonoBehaviour
{
    public static event Action ObstacleQTEs = delegate { };

    [SerializeField]
    private ObstacleKillCollider _killPlayerCollider;

    private bool _isInteracted;

    private void OnEnable()
    {
        Joystick.Click += JoystickClick;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            Time.timeScale = 0.7f;
            _isInteracted = true;
            ObstacleQTEs();
        }
    }
    private void JoystickClick()
    {
        if (_isInteracted)
        {
            Time.timeScale = 1;
            _killPlayerCollider.DisableKillAbility();
        }
    }
    
    private void OnDisable()
    {
        Joystick.Click -= JoystickClick;
    }
}
