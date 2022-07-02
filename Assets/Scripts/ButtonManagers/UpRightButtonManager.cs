using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UpRightButtonManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool upRightButtonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        upRightButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        upRightButtonPressed = false;
    }
}
