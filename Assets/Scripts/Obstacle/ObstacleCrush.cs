using System;
using UnityEngine;

public class ObstacleCrush : MonoBehaviour
{
    public event Action ObstacleCrushs = delegate { };

    [SerializeField]
    private string _ignorePlayerCollisionObstacleLayer;

    private ObstacleElementas[] _elements;

    private void Start()
    {
        _elements = GetComponentsInChildren<ObstacleElementas>();

        for (int i = 0; i < _elements.Length; i++)
        {
            _elements[i].Setup(LayerMask.NameToLayer(_ignorePlayerCollisionObstacleLayer));
            _elements[i].Disable();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            for (int i = 0; i < _elements.Length; i++)
            {
                _elements[i].Enable();

            }
        }
    }

    public void Push()
    {
        for (int i = 0; i < _elements.Length; i++)
        {
            _elements[i].Enable();
        }

        ObstacleCrushs();
    }
}