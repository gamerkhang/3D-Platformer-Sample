using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public Vector2 movementValue;
    public bool didJump;
    
    void OnMove(InputValue value)
    {
        movementValue = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        didJump = value.isPressed;
    }
}
