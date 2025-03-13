using System;
using UnityEngine;

namespace Services.Inventory
{
    public interface IInventoryService
    {
        event Action CellCountChanged;
        
        void AddItem(string id);
        void AddItem(string id, Vector2Int position);

        void RemoveItem(string id, Vector2Int position);
        int GetMaxCellCount();
        int GetUnlockCellCount();

        void UnlockCell();
    }
}