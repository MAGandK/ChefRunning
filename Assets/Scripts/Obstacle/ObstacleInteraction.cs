using System;
using UnityEngine;
using Zenject;
public class ObstacleInteraction : MonoBehaviour
{
    public static event Action Interaction;
    public static event Action InteractionWithHammer;
    public static event Action ExitInteractionWithHammer;
    public static event Action ExitInteraction;
    
    internal bool _isInteracted;

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
            _isInteracted = true;
            if (gameObject.layer == LayerMask.NameToLayer("Barrel"))
            {
                Interaction?.Invoke();
            }
            else if (gameObject.layer == LayerMask.NameToLayer("Hammer"))
            {
                InteractionWithHammer?.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player.gameObject)
        {
            if (gameObject.layer == LayerMask.NameToLayer("Barrel"))
            {
                ExitInteraction?.Invoke();
            }
            else if (gameObject.layer == LayerMask.NameToLayer("Hammer"))
            {
                ExitInteractionWithHammer.Invoke();
            }
        }
    }  
}
