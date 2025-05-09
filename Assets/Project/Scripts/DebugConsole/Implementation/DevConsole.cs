using System.Collections.Generic;
using Zenject;

namespace DebugConsole.Implementation
{
    public class DevConsole : IDevConsole, IInitializable
    {
        private IEnumerable<IDevConsoleController> _devConsoleControllers;

        public DevConsole(IEnumerable<IDevConsoleController> devConsoleControllers)
        {
            _devConsoleControllers = devConsoleControllers;
        }

        public void Initialize()
        {
            foreach (var controller in _devConsoleControllers)
            {
                controller.Init();
                controller.Build();
            }
        }
    }
}