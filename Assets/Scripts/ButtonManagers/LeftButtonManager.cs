using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class LeftButtonManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool leftButtonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        leftButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        leftButtonPressed = false;
    }
}
