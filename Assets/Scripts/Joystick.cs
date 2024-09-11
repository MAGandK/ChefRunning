using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public static event Action Click = delegate { };

    public Vector2 EventDataDelta
    {
        get;
        private set;
    }

    public void OnDrag(PointerEventData eventData)
    {
        EventDataDelta = eventData.delta;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Click();
        EventDataDelta = eventData.delta;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        EventDataDelta = Vector2.zero;
    }
}
