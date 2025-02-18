using Newtonsoft.Json;
using Services.Storage;
using UnityEngine;

public class TestData : MonoBehaviour
{
    [SerializeField] private UserData _userData;
    [SerializeField] private string  _serializeObject;
    [SerializeField] private UserData _data;

    [ContextMenu("Serialise")]
    private void Serialise()
    {
        _serializeObject = JsonConvert.SerializeObject(_userData);
    }
    
    [ContextMenu("Deserialise")]
    private void DesSerialise()
    {
        var deserializeObject = JsonConvert.DeserializeObject<UserData>(_serializeObject);
        _data = deserializeObject;
    }
}