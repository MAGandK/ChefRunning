using LevelLogic;
using UI.UIController;
using UI.WinodwsLogic.Window.FailWindow;
using UI.WinodwsLogic.Window.GameWindow;
using UI.WinodwsLogic.Window.StartWindow;
using UI.WinodwsLogic.Window.WinWindow;
using Zenject;

namespace UI
{
    public class LevelStateStateWindowHandler : ILevelStateWindowHandler, IInitializable
    {
        private readonly ILevelModel _levelModel;
        private readonly IUIController _uiController;

        public LevelStateStateWindowHandler(ILevelModel levelModel, IUIController uiController)
        {
            _uiController = uiController;
            _levelModel = levelModel;
        }

        public void Initialize()
        {
            _levelModel.StateChanged += LevelModelOnStateChanged;

            LevelModelOnStateChanged(LevelState.Start);
        }

        private void LevelModelOnStateChanged(LevelState levelState)
        {
            switch (levelState)
            {
                case LevelState.Loaded:
                    _uiController.ShowWindow<StartWindowController>();
                    break;
                case LevelState.Start:
                    _uiController.ShowWindow<GameWindowController>();
                    break;
                case LevelState.Win:
                    _uiController.ShowWindow<WinWindowController>();
                    break;
                case LevelState.Fail:
                    _uiController.ShowWindow<FailWindowController>();
                    break;
                case LevelState.Pause:
                    break;
            }
        }
    }
}