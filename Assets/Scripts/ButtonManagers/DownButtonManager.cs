using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DownButtonManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool downButtonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        downButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        downButtonPressed = false;
    }
}
