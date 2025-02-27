using Level;
using UnityEngine;

public class LevelSettingController : MonoBehaviour
{
    [field: SerializeField]
    public LevelSettings LevelSettings
    {
        get;
        private set;
    }
}
