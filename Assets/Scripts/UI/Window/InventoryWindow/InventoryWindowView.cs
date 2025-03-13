using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Window.InventoryWindow
{
    public class InventoryWindowView : AbstractWindowView
    {
        [SerializeField] private ScrollRect _scrollView;
        [SerializeField] private InventoryCell _inventoryCellPrefab;
        [SerializeField] private InventoryItemView _inventoryItemViewPrefab;

        [SerializeField] private Transform _cellParent;

        private readonly List<InventoryCell> _cells = new List<InventoryCell>();

        public void PrepareCells(int cellCount, int unlockCellCount)
        {
            for (int i = 0; i < cellCount; i++)
            {
                _cells.Add(Instantiate(_inventoryCellPrefab, _cellParent));

                _cells[i].Setup(i > unlockCellCount);
            }
        }
    }
}