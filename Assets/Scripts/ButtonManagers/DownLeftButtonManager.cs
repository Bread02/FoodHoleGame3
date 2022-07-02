using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DownLeftButtonManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool downLeftButtonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        downLeftButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        downLeftButtonPressed = false;
    }
}
