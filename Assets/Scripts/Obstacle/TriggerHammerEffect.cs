using UnityEngine;

public class TriggerHammerEffect : MonoBehaviour
{
    [SerializeField] private GameObject _effectPrefab;
    [SerializeField] private Transform _effectHammerTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Road"))
        {
            Instantiate(_effectPrefab, _effectHammerTransform.position, Quaternion.identity);
        }
    }
}