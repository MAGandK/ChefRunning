namespace LevelLogic.Settings
{
    public interface ILevelSettings
    {
        string[] SceneNames { get; }
        string GetSceneName(int levelIndex);
    }
}