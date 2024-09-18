using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class Coin : MonoBehaviour
{
    private Transform _transform;
    private float _rotationSpeed = 200f;    
    public float rotationDelay = 0f;
    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        StartCoroutine(StartRotationWithDelay());
    }

    private IEnumerator StartRotationWithDelay()
    {
        yield return new WaitForSeconds(rotationDelay);

        while (true)
        {
            _transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
            yield return null; 
        }
    }
}
