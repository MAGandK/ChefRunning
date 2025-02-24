using System.Collections.Generic;
using Services.Price;
using UnityEngine;

namespace UI.Other
{
    public class BalanceView : MonoBehaviour
    {
        [SerializeField] private List<CurrencyView> _views;

        public void Setup(params CurrencyType[] types)
        {
            foreach (var currencyView in _views)
            {
                currencyView.gameObject.SetActive(false);

                foreach (var currencyType in types)
                {
                    if (currencyView.Type == currencyType)
                    {
                        currencyView.gameObject.SetActive(true);
                    }
                }
            }
        }

        public void Refresh(CurrencyType type, int value)
        {
            foreach (var currencyView in _views)
            {
                if (currencyView.Type == type)
                {
                    currencyView.Refresh(value);
                    return;
                }
            }
        }
    }
}