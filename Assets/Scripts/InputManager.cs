using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerMovement;

public class InputManager : MonoBehaviour, PlayerMovement.IMovementActionsActions
{
    private PlayerMovement playerMovement;
    public GameManager gameManager;
    void Awake()
    {
        playerMovement = new PlayerMovement();
        playerMovement.movementActions.Enable();
        playerMovement.movementActions.SetCallbacks(this);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Actions.moveEvent?.Invoke(context.ReadValue<Vector2>());
    }
    
}
public static class Actions
{
    public static Action<Vector2> moveEvent;
}