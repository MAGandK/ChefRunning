using UI.Window.StartWindow;
using UnityEngine;

public abstract class AbstractWindowView : MonoBehaviour, IWindowView
{
    public void Show()
    {
        gameObject.SetActive(true);
    }


    protected virtual void OnShow()
    {
        
    }
}