using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DynamicJoystick : Joystick
{
    public float MoveThreshold { get { return moveThreshold; } set { moveThreshold = Mathf.Abs(value); } }

    [SerializeField] private float moveThreshold = 1;

    protected override void Start()
    {
        MoveThreshold = moveThreshold;
        base.Start();
        background.gameObject.SetActive(false);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        Vector2 newPosition = ScreenPointToAnchoredPosition(eventData.position);
        newPosition = ClampToScreenBounds(newPosition);
        background.anchoredPosition = newPosition;
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
    }

    protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (magnitude > moveThreshold)
        {
            Vector2 difference = normalised * (magnitude - moveThreshold) * radius;
            Vector2 newPosition = background.anchoredPosition + difference;
            background.anchoredPosition = ClampToScreenBounds(newPosition);
        }
        base.HandleInput(magnitude, normalised, radius, cam);
    }
    
    private Vector2 ClampToScreenBounds(Vector2 position)
    {
        Vector2 minPosition = Vector2.zero;
        Vector2 maxPosition = new Vector2(Screen.width, Screen.height);

        float joystickWidth = background.sizeDelta.x / 2;
        float joystickHeight = background.sizeDelta.y / 2;

        minPosition.x += joystickWidth;
        minPosition.y += joystickHeight;
        maxPosition.x -= joystickWidth;
        maxPosition.y -= joystickHeight;
        
        position.x = Mathf.Clamp(position.x, minPosition.x, maxPosition.x);
        position.y = Mathf.Clamp(position.y, minPosition.y, maxPosition.y);

        return position;
    }
}