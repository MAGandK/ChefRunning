using UnityEngine;

namespace Services.Inventory
{
    [CreateAssetMenu(menuName = "Create InventoryConfig", fileName = "InventoryConfig", order = 0)]
    public class InventoryConfig : ScriptableObject
    {
        [SerializeField] private int _maxCellLine;
        [SerializeField] private int _cellLineItemCount;
        [SerializeField] private int _startLockCellCount;
        [SerializeField] private InventoryItemConfig[] _itemConfigs;

        public int MaxCellLine => _maxCellLine;
        public InventoryItemConfig[] ItemConfigs => _itemConfigs;
        public int StartLockCellCount => _startLockCellCount;
    }
}