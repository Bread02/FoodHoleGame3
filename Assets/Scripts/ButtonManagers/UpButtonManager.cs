using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UpButtonManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool upButtonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        upButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        upButtonPressed = false;
    }
}
