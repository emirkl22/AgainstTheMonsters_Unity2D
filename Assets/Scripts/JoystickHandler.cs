using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    

    public void OnPointerDown(PointerEventData eventData)
    {
        gameManager.isJoystickPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        gameManager.isJoystickPressed = false;
    }
}
