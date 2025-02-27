using System.Collections;

namespace Level
{
    public interface ILevelLoader
    {
        IEnumerator LoadCurrentLevel();
        IEnumerator LoadNextLevel();
    }
}