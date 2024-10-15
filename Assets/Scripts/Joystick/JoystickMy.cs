using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickMy : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform _image; 
    
    [SerializeField] private RectTransform _imageHandle; 
    public Vector2 EventDataDelta
    {
        get;
        private set;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPointerPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_image, eventData.position, eventData.pressEventCamera, out localPointerPosition);
        
        Vector2 offset = localPointerPosition - _image.anchoredPosition;
        
        float handleRadius = _image.rect.width / 2; 
        offset = Vector2.ClampMagnitude(offset, handleRadius); 

        _imageHandle.anchoredPosition = offset; 
        EventDataDelta = offset;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        EventDataDelta = Vector2.zero;
        _imageHandle.anchoredPosition = Vector2.zero; 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        EventDataDelta = Vector2.zero;
        _imageHandle.anchoredPosition = Vector2.zero;
    }
}
