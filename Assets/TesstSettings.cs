using System;
using System.Collections.Generic;
using Services.Price;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Create TestSettings", fileName = "TestSettings", order = 0)]
    public class TesstSettings: ScriptableObject
    {
        [SerializeField] private List<TestSettingPrice> _settingPrices;
    }
}

[Serializable]
public class TestSettingPrice
{
    [SerializeField] private CurrencyType coin;
    [SerializeField] private string id;
}