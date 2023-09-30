using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    private Vector2 movementVector = Vector2.zero;

    public Rigidbody2D rb;
    private CustomInput input = null;

    public Vector2 facing = Vector2.left;

    public DetectPocketsRaycast scriptDP;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = new CustomInput();
        EnableInput();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate() 
    {
        if(movementVector != Vector2.zero)
        {
            rb.MovePosition(rb.position + movementVector * speed * Time.fixedDeltaTime);
            if (movementVector != facing)
            {
                ChangeFacing(movementVector);
            }
        }
    }

    private void EnableInput()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
    }

    private void DisableInput()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value) 
    {
        movementVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        movementVector = Vector2.zero;
    }

    private void ChangeFacing(Vector2 newFacing)
    {
        facing = newFacing;
        scriptDP.facing = newFacing;
    }
}
