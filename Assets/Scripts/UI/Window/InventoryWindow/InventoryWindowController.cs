using Services.Inventory;

namespace UI.Window.InventoryWindow
{
    public class InventoryWindowController : AbstractWindowController<InventoryWindowView>
    {
        private IInventoryService _inventoryService;
        private InventoryWindowView _view;
        private InventoryConfig _inventoryConfig;

        public InventoryWindowController(InventoryWindowView view, IInventoryService inventoryService,
            InventoryConfig inventoryConfig) : base(view)
        {
            _inventoryConfig = inventoryConfig;
            _view = view;
            _inventoryService = inventoryService;
        }

        public override void Initialize()
        {
            base.Initialize();

            _view.PrepareCells(_inventoryService.GetMaxCellCount(), _inventoryService.GetUnlockCellCount());
        }
    }
}