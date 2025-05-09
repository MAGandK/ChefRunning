using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace DebugConsole
{
    public class DevConsole : IDevConsole, IInitializable
    {
        private readonly IEnumerable<IDevConsoleController> _devConsoleControllers;

        public DevConsole(IEnumerable<IDevConsoleController> devConsoleControllers)
        {
            _devConsoleControllers = devConsoleControllers;
        }

        public void Initialize()
        {
            var sorted = _devConsoleControllers.OrderBy(x => x.GroupPriority);

            foreach (var controller in sorted)
            {
                controller.Init();
                controller.Build();
            }
        }
    }
}