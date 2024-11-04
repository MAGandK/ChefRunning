using UnityEngine;
public class ObstacleHammer : ObstacleBase
{
    [SerializeField] private Transform _objectHammer;
    [SerializeField] private float animationSpeed = 1.0f;
    private Animator animator;
    
    public override void ResetObstacle()
    {
        base.ResetObstacle();
        _objectHammer.gameObject.SetActive(true);
    }
    void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.speed = animationSpeed;
    }
}
