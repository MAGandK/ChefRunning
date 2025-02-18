using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Services.Storage
{
    [Serializable] [JsonObject(MemberSerialization.OptIn)]
    public class UserData : IStorageData<UserData>
    {
        public event Action<string> Changed;
        
        [SerializeField] [JsonProperty] private string _userName;
        [SerializeField] [JsonProperty] private int _purHaseCount;

        public string UserName => _userName;
        public int PurHaseCount => _purHaseCount;

        [JsonIgnore]public string Key => "user.data";

        public void Load(UserData data)
        {
            _userName = data._userName;
            _purHaseCount = data._purHaseCount;
        }

        public void SetUserName(string newUserName)
        {
            _userName = newUserName;
            Changed?.Invoke(Key);
        }
    }
}