using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPadRotation : MonoBehaviour, IPointerDownHandler,IDragHandler,IPointerUpHandler
{
    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    float multiplyRot=1;

    Vector2 touchPosition;
    Vector2 nowPos;
    bool isTouching = false;

    

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouching = true;
        SetTouchPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isTouching)
        {
            nowPos = eventData.position;
            Vector2 dir = nowPos - touchPosition;
            playerTransform.rotation = 
                Quaternion.Euler(playerTransform.eulerAngles.x, 
                playerTransform.eulerAngles.y + dir.x*multiplyRot, 
                playerTransform.eulerAngles.z);
            SetTouchPosition(eventData);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouching = false;
    }

    private void SetTouchPosition(PointerEventData eventData)
    {
        touchPosition = eventData.position;
    }

}
