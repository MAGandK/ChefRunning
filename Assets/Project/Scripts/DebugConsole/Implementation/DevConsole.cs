using System.Collections.Generic;
using Zenject;

namespace DebugConsole
{
    public class DevConsole : IDevConsole, IInitializable
    {
        private readonly IEnumerable<IDevConsoleController> _consoleControllers;

        public DevConsole(IEnumerable<IDevConsoleController> consoleControllers)
        {
            _consoleControllers = consoleControllers;
        }

        public void Initialize()
        {
            foreach (var controller in _consoleControllers)
            {
                controller.Init();
            }
        }
    }
}