using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
{
    private const float CLICK_DURATION = 0.5f;

    public event Action DoubleClick;

    private int _clickCount;
    private float _oldClickTime;

    public Vector2 Direction { get; private set; }

    public void OnDrag(PointerEventData eventData)
    {
        Direction = eventData.delta.normalized;
        _clickCount = 0;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Direction = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _clickCount++;
            
        if (_clickCount > 1)
        {
            if (_oldClickTime + CLICK_DURATION >= Time.time)
            {
                DoubleClick?.Invoke();
            }

            _clickCount = 0;
        }
            
        _oldClickTime = Time.time;
    }
}

