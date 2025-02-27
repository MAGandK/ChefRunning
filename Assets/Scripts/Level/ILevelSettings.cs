namespace Level
{
    public interface ILevelSettings
    {
        string[] SceneNames { get; }
        string GetSceneName(int levelIndex);
    }
}