using Services.Price;
using TMPro;
using UnityEngine;

namespace UI.Other
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private CurrencyType _type;

        public CurrencyType Type => _type;

        [SerializeField] private TMP_Text _value;
        
        public void Refresh(int value)
        {
            _value.SetText(value.ToString());
        }
    }
}