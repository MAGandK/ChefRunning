using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Other.Joystick
{
    public interface IJoystickController : IDragHandler, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
    {
        const float CLICK_DURATION = 0.5f;

        event Action DoubleClick;
        event Action PointerUp;
        event Action PointerDown;
        Vector2 Direction { get; }
        Vector2 Position { get; }
    }
}
