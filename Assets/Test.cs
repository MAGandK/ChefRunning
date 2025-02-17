using Services.Storage;
using UI;
using UI.Window;
using UI.Window.StartWindow;
using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
    private IUIController _uiController;
    private IStorageService _storageService;
    private PlayerStorageData _playerStorage;

    [Inject]
    private void Counstruct(IStorageService storageService)
    {
        _storageService = storageService;
        // _uiController = uiController;

        _playerStorage = _storageService.GetData<PlayerStorageData>(StorageDataNames.PLAYER_STORAGE_DATA_KEY);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            _uiController.ShowWindow<StartWindowController>();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            _playerStorage.IncrementLevelIndex();

            Debug.Log(_playerStorage.LevelIndex);
        }
    }
}
