using System;
using SRDebugger;

namespace DebugConsole.Controllers
{
    public abstract class AbstractDevConsoleController : IDevConsoleController
    {
        private readonly DynamicOptionContainer _container = new();

        protected abstract string GroupName { get; }
        public abstract int GroupPriority { get; }
        
        public void Build()
        {
            if (_container.Options.Count > 0)
            {
                SRDebug.Instance.AddOptionContainer(_container);
            }
        }

        protected void AddButton(string name, Action action, int sortPriority = 0)
        {
            _container.AddOption(OptionDefinition.FromMethod(name, action, GroupName, sortPriority));
        }

        protected void AddSlider<T>(string name, Func<T> getter, Action<T> setter, int sortPriority = 0)
        {
            _container.AddOption(OptionDefinition.Create(name, getter, setter, GroupName, sortPriority));
        }

        protected void AddInfo<T>(string name, Func<T> getter, int sortPriority = 0)
        {
            _container.AddOption(OptionDefinition.Create(name, getter, category: GroupName,
                sortPriority: sortPriority));
        }

        public abstract void Init();
    }
}