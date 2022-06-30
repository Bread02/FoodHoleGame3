using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DownRightButtonManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool downRightButtonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        downRightButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        downRightButtonPressed = false;
    }
}
