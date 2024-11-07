using System;
using UnityEngine;
public class ObstacleHammer : MonoBehaviour
{
    [SerializeField] private Transform _objectHammer;
    [SerializeField] private float animationSpeed = 1.0f;
    private Animator animator;
    public delegate void ObstacleEventHandler(GameObject obstacleHammer);
    public static event ObstacleEventHandler HammerFall;
   
    void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.speed = animationSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            HammerFall?.Invoke(gameObject);
        }
    }
}
