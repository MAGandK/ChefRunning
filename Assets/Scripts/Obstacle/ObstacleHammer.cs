using System;
using CustomNameSpase;
using UnityEngine;

public class ObstacleHammer : ObstacleBase
{
    //public static event Action HammerFall;

    [SerializeField] private Transform _objectHammer;
    [SerializeField] private float animationSpeed = 1.0f;

    private Animator animator;

    void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.speed = animationSpeed;
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
    //     {
    //         HammerFall?.Invoke();
    //     }
    // }
}