using UnityEngine;

public abstract class WindowBase : MonoBehaviour
{
    public bool IsActive
    {
        get
        {
            return gameObject.activeSelf;
        }
    }

    public abstract WindowType Type
    {
        get ;
    } 

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
