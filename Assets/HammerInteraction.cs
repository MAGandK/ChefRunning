using System;
using UnityEngine;

public class HammerInteraction : MonoBehaviour
{
    public static event Action InteractionHammer;
    
    [SerializeField]
    private TriggerHammer _killPlayerCollider;

    private bool _isInteracted;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            Time.timeScale = 0.7f;
            _isInteracted = true;
            InteractionHammer?.Invoke(); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            Time.timeScale = 1;
            _isInteracted = false; 
        }
    }  
}

