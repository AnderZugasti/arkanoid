using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class direccion : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public bool pulsado;
    public void OnPointerDown(PointerEventData eventData)
    {
        pulsado = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        pulsado = false;
    }
}
