using System.Collections.Generic;
using Newtonsoft.Json;
using Services.Storage;

namespace Services.Inventory
{
    public class InventoryData : AbstractStorageData<InventoryData>
    {
        [JsonProperty("inventoryItems")]
        private List<InventoryItemData> _inventoryItems = new();
        [JsonProperty] 
        private int _additionalCellCount;

        public int AdditionalCellCount => _additionalCellCount;

        public InventoryData(string key) : base(key)
        {
        }

        public override void Load(InventoryData data)
        {
            _inventoryItems = data._inventoryItems;
        }

        public void UnlockCell()
        {
            _additionalCellCount++;
            
            OnChanged();
        }
    }
}