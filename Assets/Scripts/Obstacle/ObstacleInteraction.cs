using System;
using UnityEngine;

public class ObstacleInteraction : MonoBehaviour
{
    public static event Action Interaction = delegate { };

    [SerializeField]
    private Obstacle _killPlayerCollider;

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
            Interaction();
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
