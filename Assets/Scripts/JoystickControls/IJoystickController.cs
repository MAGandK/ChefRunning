using System;
using System.Numerics;
using Vector2 = UnityEngine.Vector2;

namespace JoystickControls
{
    public interface IJoystickController 
    {
        event Action PointerUp;
        event Action PointerDown;
        Vector2 Position { get; }
    }
}
