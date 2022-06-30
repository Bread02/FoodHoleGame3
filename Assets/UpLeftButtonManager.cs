using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UpLeftButtonManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool upLeftButtonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        upLeftButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        upLeftButtonPressed = false;
    }
}
