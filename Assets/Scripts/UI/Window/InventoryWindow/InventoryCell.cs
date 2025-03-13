using UnityEngine;
using UnityEngine.UI;

namespace UI.Window.InventoryWindow
{
    public class InventoryCell : MonoBehaviour
    {
        [SerializeField] private Image _back;
        [SerializeField] private Color _lockColor;
        [SerializeField] private Color _unlockColor;
        
        public void Setup(bool isLock)
        {
            _back.color = isLock ? _lockColor : _unlockColor;
        }
    }
}