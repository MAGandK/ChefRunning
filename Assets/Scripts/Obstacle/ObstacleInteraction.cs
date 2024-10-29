using System;
using UnityEngine;
using Zenject;
public class ObstacleInteraction : MonoBehaviour
{
    public static event Action Interaction;

    private bool _isInteracted;

    private Player _player;

   [Inject]
    private void Construct(Player player)
    {
        _player = player;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player.gameObject && !_isInteracted)
        {
            //Time.timeScale = 0.7f;
            _isInteracted = true;
            Interaction?.Invoke(); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player.gameObject)
        {
           // Time.timeScale = 1;
            _isInteracted = false; 
        }
    }  
}
