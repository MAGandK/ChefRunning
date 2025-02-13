using System.Collections.Generic;
using UnityEngine;

namespace Obstacle
{
    public class ObstacleController : MonoBehaviour
    {
        [SerializeField] private List<ObstacleBase> obstacles = new List<ObstacleBase>();

        public void ResetObstacle()
        {
            foreach (var obstacle in obstacles)
            {
                obstacle.ResetObstacle();
            }
        }
    }
}