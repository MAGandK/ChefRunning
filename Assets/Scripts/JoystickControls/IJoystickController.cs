using System;
using Vector2 = UnityEngine.Vector2;

namespace JoystickControls
{
    public interface IJoystickController 
    {
        event Action PointerUp;
        event Action PointerDown; 
        event Action DoubleClick;
        Vector2 Position { get; }
    }
}
