using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mov_Botao : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPressed;
    public bool IsPressionado => isPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
