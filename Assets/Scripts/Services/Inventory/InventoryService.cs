using System;
using Constants;
using Services.Storage;
using UnityEngine;

namespace Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        public event Action CellCountChanged;

        private InventoryConfig _configs;
        private InventoryData _inventoryData;
        
        public InventoryService(InventoryConfig configs, IStorageService storageService)
        {
            _configs = configs;
            _inventoryData = storageService.GetData<InventoryData>(StorageDataNames.INVENTORY_DATA);
        }

        public void AddItem(string id)
        {
        }

        public void AddItem(string id, Vector2Int position)
        {
        }

        public void RemoveItem(string id, Vector2Int position)
        {
        }

        public int GetMaxCellCount()
        {
            return _configs.MaxCellLine;
        }

        public int GetUnlockCellCount()
        {
            return _configs.StartLockCellCount + _inventoryData.AdditionalCellCount;
        }

        public void UnlockCell()
        {
            if (GetUnlockCellCount() >= GetMaxCellCount())
            {
                return;
            }

            _inventoryData.UnlockCell();
            CellCountChanged?.Invoke();
        }
    }
}