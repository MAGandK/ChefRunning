using UnityEngine;
public class ObstacleHammer : ObstacleBase
{
    [SerializeField]
    private Transform _objectHammer;
    
    public override void ResetObstacle()
    {
        base.ResetObstacle();
        _objectHammer.gameObject.SetActive(true);
    }
}
