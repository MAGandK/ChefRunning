using System;
using UnityEngine;
public enum ColliderType
{
    ObstacleBarrel,
    ObstacleHammer
}
public class ObstacleInteraction : MonoBehaviour
{
    public static event Action Interaction;
    
    [SerializeField]
    private ColliderType _colliderType;

    private bool _isInteracted;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            Time.timeScale = 0.7f;
            _isInteracted = true;
            Interaction?.Invoke(); 
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
