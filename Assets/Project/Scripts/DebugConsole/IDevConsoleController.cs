namespace DebugConsole
{
    public interface IDevConsoleController
    {
        int GroupPriority { get; }

        void Init();
        void Build();
    }
}