using UnityEngine;

namespace Obstacle
{
    public class ObstacleHammer : ObstacleBase
    {
        [SerializeField] private Transform _objectHammer;
        [SerializeField] private float animationSpeed = 1.0f;

        private Animator animator;

        void OnEnable()
        {
            animator = GetComponent<Animator>();
            animator.speed = animationSpeed;
        }
    }
}