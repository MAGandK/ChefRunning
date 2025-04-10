using System.Collections;
using Pool;
using UnityEngine;

public class TestPool : MonoBehaviour, IPoolObject
{
    private bool _isFree;
    public bool IsFree => _isFree;
    private void OnEnable()
    {
        StartCoroutine(DisableCor());
    }

    private IEnumerator DisableCor()
    {
        yield return new WaitForSeconds(5f);
        SetIsFree(true);
        
        gameObject.SetActive(false);
    }
    public void SetIsFree(bool isFree)
    {
        _isFree = isFree;
    }
}
