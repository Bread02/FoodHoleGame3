using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class RightButtonManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool rightButtonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        rightButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rightButtonPressed = false;
    }
}
